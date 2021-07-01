using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace OnlineNotepad.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
            if (!context.Notes.Any())
            {
                context.Notes.AddRange(
                    new Note
                    {
                        Name = "ASUS",
                    },
                    new Note
                    {
                        Name = "Acer",
                    },
                    new Note
                    {
                        Name = "MSI",
                    },
                    new Note
                    {
                        Name = "Dell",
                    });
                context.SaveChanges();
            }
        }
    }
}
