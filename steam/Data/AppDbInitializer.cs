using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using steam.Data.Static;
using steam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Developpers
                if (!context.Developpers.Any())
                {
                    context.Developpers.AddRange(new List<Developper>()
                    {
                        new Developper()
                        {
                            StudioName = "Developper 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/Developper/Developper-1.jpeg"

                        },
                        new Developper()
                        {
                            StudioName = "Developper 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/Developper/Developper-2.jpeg"
                        },
                        new Developper()
                        {
                            StudioName = "Developper 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/Developper/Developper-3.jpeg"
                        },
                        new Developper()
                        {
                            StudioName = "Developper 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/Developper/Developper-4.jpeg"
                        },
                        new Developper()
                        {
                            StudioName = "Developper 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/Developper/Developper-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Publishers
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            StudioName = "Publisher 1",
                            Bio = "This is the Bio of the first Publisher",
                            ProfilePictureURL = "http://dotnethow.net/images/Publishers/Publisher-1.jpeg"

                        },
                        new Publisher()
                        {
                            StudioName = "Publisher 2",
                            Bio = "This is the Bio of the second Publisher",
                            ProfilePictureURL = "http://dotnethow.net/images/Publishers/Publisher-2.jpeg"
                        },
                        new Publisher()
                        {
                            StudioName = "Publisher 3",
                            Bio = "This is the Bio of the second Publisher",
                            ProfilePictureURL = "http://dotnethow.net/images/Publishers/Publisher-3.jpeg"
                        },
                        new Publisher()
                        {
                            StudioName = "Publisher 4",
                            Bio = "This is the Bio of the second Publisher",
                            ProfilePictureURL = "http://dotnethow.net/images/Publishers/Publisher-4.jpeg"
                        },
                        new Publisher()
                        {
                            StudioName = "Publisher 5",
                            Bio = "This is the Bio of the second Publisher",
                            ProfilePictureURL = "http://dotnethow.net/images/Publishers/Publisher-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Games
                if (!context.Games.Any())
                {
                    context.Games.AddRange(new List<Game>()
                    {
                        new Game()
                        {
                            Name = "Life",
                            Description = "This is the Life Game description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/Games/Game-3.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DevelopperId = 7,
                            GameCategory = GameCategory.Action
                        },
                        new Game()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/Games/Game-1.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DevelopperId = 7,
                            GameCategory = GameCategory.Adventure
                        },
                        new Game()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost Game description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/Games/Game-4.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DevelopperId = 7,
                            GameCategory = GameCategory.Indie
                        },
                        new Game()
                        {
                            Name = "Race",
                            Description = "This is the Race Game description",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DevelopperId = 7,
                            GameCategory = GameCategory.MMORPG
                        },
                        new Game()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob Game description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/Games/Game-7.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DevelopperId = 7,
                            GameCategory = GameCategory.FPS
                        },
                        new Game()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles Game description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/Games/Game-8.jpeg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            DevelopperId = 7,
                            GameCategory = GameCategory.Action
                        }
                    }); ;
                    context.SaveChanges();
                }
                //Games Publishers
                if (!context.Games_Publishers.Any())
                {
                    context.Games_Publishers.AddRange(new List<Game_Publisher>()
                    {
                        new Game_Publisher()
                        {
                            PublisherId = 8,
                            GameId = 16
                        },
                        new Game_Publisher()
                        {
                            PublisherId = 8,
                            GameId = 17
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@steam.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "William@!123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@steam.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "William@!123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
