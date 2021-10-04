using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            Console.WriteLine("Seeding data");


            // Categoris
            var electricalId = Guid.NewGuid();

            var electricalCategory = new Category
            {
                CategoryId = electricalId,
                CategoryName = "Electrical"
            };

            var iphone12P = new ProductItem()
            {
                Id = Guid.NewGuid(),
                ProductName = "iPhone 12 Pro",
                Description = "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020",
                Price = 1399,
                QtyAvailable = 1,
                Images = null,
                CategoryId = electricalId,
                Badge = "New",
                Ratings = 5
            };

            var iphone12PM = new ProductItem()
            {
                Id = Guid.NewGuid(),
                ProductName = "iPhone 12 Pro Max",
                Description = "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020",
                Price = 1599,
                QtyAvailable = 10,
                Images = null,
                CategoryId = electricalId,
                Badge = "New",
                Ratings = 5
            };

            var ipad = new ProductItem()
            {
                Id = Guid.NewGuid(),
                ProductName = "iPad Pro",
                Description = "iPad Pro is a premium edition of the iPad tablet computers developed by Apple. It initially ran iOS,[12] but was later switched to a derivation of the same equivalent that is optimized for the iPad, iPadOS.[13] The first iPad Pro was introduced on September 9, 2015, running iOS 9.",
                Price = 1399,
                QtyAvailable = 99,
                Images = null,
                CategoryId = electricalId,
                SalePercetage = 0.75,
                Badge = "Sale",
                Ratings = 4
            };

            builder.Entity<Category>()
                .HasData(electricalCategory);


            builder.Entity<ProductItem>().HasData
                (
                    iphone12P,
                    iphone12PM,
                    ipad
                );
            

            var adminRoleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole()
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    }
                );

            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "test@test.com",
                NormalizedUserName = "test@test.com".ToUpper(),
                Email = "test@test.com",
                NormalizedEmail = "test@test.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true
            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123.");

            var adminId = Guid.NewGuid().ToString();
            var admin = new ApplicationUser()
            {
                Id = adminId,
                UserName = "admin@appstore.com",
                NormalizedUserName = "admin@appstore.com".ToUpper(),
                Email = "admin@appstore.com",
                NormalizedEmail = "admin@appstore.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123.");

            builder.Entity<ApplicationUser>().HasData
                (
                    user,
                    admin
                );

            builder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = adminRoleId,
                        UserId = adminId
                    }
                );

            base.OnModelCreating(builder);
        }
    }
}
