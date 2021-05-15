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
                        Description = "new model ASUS",
                    },

                    new Note
                    {
                        Name = "Acer",
                        Description = "new model Acer",
                    },
                    new Note
                    {
                        Name = "MSI",
                        Description = "new model MSI",
                    },
                    new Note
                    {
                        Name = "Dell",
                        Description = "new model Dell",
                    });
                context.SaveChanges();
            }
        }
    }
}
