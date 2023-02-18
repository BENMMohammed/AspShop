using Microsoft.EntityFrameworkCore;
using AspShop.Models;

namespace AspShop.Data
{
        public class SeedData
        {
                public static void SeedDatabase(DataContext context)
                {
                        context.Database.Migrate();

                        if (!context.Products.Any())
                        {
                                Category telephone = new Category { Name = "Telephone", Slug = "telephone" };
                                Category accesoires = new Category { Name = "Accesoires", Slug = "accesoires" };
                        }
                }
        }
}