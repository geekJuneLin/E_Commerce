using E_Commerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data
{
    public static class PreDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeeData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeeData(AppDbContext context)
        {
            if (context.Database != null)
            {
                Console.WriteLine("Seeding data");

                context.ProductItems.AddRange
                    (
                        new ProductItem()
                        {
                            Id = Guid.NewGuid(),
                            ProductName = "iPhone 12 Pro",
                            Description = "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020",
                            Price = 1399,
                            QtyAvailable = 1,
                            Images = new List<ProductImage>()
                            {
                                new ProductImage()
                                {
                                    Id = 1,
                                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/IPhone_12_Pro_Gold.svg/220px-IPhone_12_Pro_Gold.svg.png"
                                }
                            }
                        },
                        new ProductItem()
                        {
                            Id = Guid.NewGuid(),
                            ProductName = "iPhone 12 Pro Max",
                            Description = "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020",
                            Price = 1599,
                            QtyAvailable = 10,
                            Images = new List<ProductImage>()
                            {
                                new ProductImage()
                                {
                                    Id = 2,
                                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/IPhone_12_Pro_Gold.svg/220px-IPhone_12_Pro_Gold.svg.png"
                                }
                            }
                        },
                        new ProductItem()
                        {
                            Id = Guid.NewGuid(),
                            ProductName = "iPad Pro",
                            Description = "iPad Pro is a premium edition of the iPad tablet computers developed by Apple. It initially ran iOS,[12] but was later switched to a derivation of the same equivalent that is optimized for the iPad, iPadOS.[13] The first iPad Pro was introduced on September 9, 2015, running iOS 9.",
                            Price = 1399,
                            QtyAvailable = 99,
                            Images = new List<ProductImage>()
                            {
                                new ProductImage()
                                {
                                    Id = 3,
                                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/IPad_Pro_5th_generation.png/250px-IPad_Pro_5th_generation.png"
                                }
                            }
                        }
                    );

                var adminRoleId = Guid.NewGuid().ToString();
                context.Roles.Add
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

                // Admin user
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

                context.Users.AddRange
                    (
                        user,
                        admin
                    );

                // Add the admin relation
                context.UserRoles.Add
                    (
                        new IdentityUserRole<string>
                        {
                            RoleId = adminRoleId,
                            UserId = adminId
                        }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data");
            }
        }
    }
}
