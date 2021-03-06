using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineNotepad.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OnlineNotepad
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:Notepad:ConnectionString"]));
            
            // Identity configure
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:NotepadIdentity:ConnectionString"]));
            // Identity register the services
   
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // ??????????? ?????
                opts.Password.RequireNonAlphanumeric = false;   // ????????? ?? ?? ?????????-???????? ???????
                opts.Password.RequireLowercase = false; // ????????? ?? ??????? ? ?????? ????????
                opts.Password.RequireUppercase = false; // ????????? ?? ??????? ? ??????? ????????
                opts.Password.RequireDigit = false; // ????????? ?? ?????
                opts.User.RequireUniqueEmail = true; // ?????????? email
                opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz1234567890-_"; // ?????????? ???????
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
            services.AddTransient<INoteRepository, EFNoteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    "default",
                    "{controller=Notes}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
