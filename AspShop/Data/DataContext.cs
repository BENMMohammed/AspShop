using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspShop.Models;

namespace AspShop.Data
{
        public class DataContext : IdentityDbContext<AppUser>
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options)
                { }
                public DbSet<Product> Products { get; set; }
                public DbSet<Category> Categories { get; set; }
                public DbSet<CartLineOrder> CartLineOrder { get; set; }
                public DbSet<CartItem> CartItem { get; set; }
                public DbSet<User> User { get; set; }
                public DbSet<Order> Order { get; set; }


        }
}
