using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

using Group3.Models;

namespace Group3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
                                        ApplicationUserRole, 
                                        IdentityUserLogin<string>,
                                        IdentityRoleClaim<string>, 
                                        IdentityUserToken<string>> {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User)
                .HasForeignKey(post => post.UserId);

            modelBuilder.Entity<Post>()
                .HasOne(post => post.Topic)
                .WithMany(topic => topic.Posts)
                .HasForeignKey(post => post.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Topic>()
                .HasOne(topic => topic.Category)
                .WithMany(category => category.Topics)
                .HasForeignKey(topic => topic.CategoryId);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });

            var adminRole = new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" };
            var userRole = new ApplicationRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" };

            modelBuilder.Entity<ApplicationRole>().HasData(adminRole);
            modelBuilder.Entity<ApplicationRole>().HasData(userRole);

            var adminUserRole = new ApplicationUserRole() { RoleId = adminRole.Id, UserId = Guid.NewGuid().ToString() };
            var userUserRole = new ApplicationUserRole() { RoleId = userRole.Id, UserId = Guid.NewGuid().ToString() };

            modelBuilder.Entity<ApplicationUserRole>().HasData(adminUserRole);
            modelBuilder.Entity<ApplicationUserRole>().HasData(userUserRole);

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = adminUserRole.UserId,
                Email = "admin@fakemail.net",
                NormalizedEmail = "ADMIN@FAKEMAIL.NET",
                UserName = "admin@fakemail.net",
                NormalizedUserName = "ADMIN@FAKEMAIL.NET",
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(1964, 07, 15),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password")
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = userUserRole.UserId,
                Email = "user@fakemail.net",
                NormalizedEmail = "USER@FAKEMAIL.NET",
                UserName = "user@fakemail.net",
                NormalizedUserName = "USER@FAKEMAIL.NET",
                FirstName = "Johan",
                LastName = "Svensson",
                Birthdate = new DateTime(1993, 10, 18),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password")
            });

            var category1 = new Category { Id = -1, Name = "News" };
            var category2 = new Category { Id = -2, Name = "Frontend" };
            var category3 = new Category { Id = -3, Name = "Backend" };
            var category4 = new Category { Id = -4, Name = "Random" };

            var topic1 = new Topic { Id = -1, Name = "Trending", Description = "Upgrade your project to 6.0", CategoryId = category1.Id, UserId = adminUserRole.UserId };
            var topic2 = new Topic { Id = -2, Name = "HTML", Description = "What ever about HTML", CategoryId = category2.Id, UserId = userUserRole.UserId };
            var topic3 = new Topic { Id = -3, Name = "CSS", Description = "Do it with style", CategoryId = category2.Id, UserId = userUserRole.UserId };
            var topic4 = new Topic { Id = -4, Name = "Entity Framework", Description = "Your prefered database", CategoryId = category3.Id, UserId = userUserRole.UserId };

            var post1 = new Post { Id = -1, Text = "<b>Visual Studio 6.0</b> news news news more news", Time = DateTime.Now.AddDays(-1), TopicId = topic1.Id, UserId = userUserRole.UserId };
            var post2 = new Post { Id = -2, Text = "What is header for?", Time = DateTime.Now.AddDays(-2), TopicId = topic2.Id, UserId = adminUserRole.UserId };
            var post3 = new Post { Id = -3, Text = "HoW do I make a table?", Time = DateTime.Now.AddDays(-5), TopicId = topic2.Id, UserId = adminUserRole.UserId };

            var message1 = new Message { Id = -1, UserId = adminUserRole.UserId, ReceiverId = userUserRole.UserId, Text = "Hello there", Time = DateTime.Now.AddDays(-3) };
            var message2 = new Message { Id = -2, UserId = userUserRole.UserId, ReceiverId = adminUserRole.UserId, Text = "Hello yourself", Time = DateTime.Now.AddDays(-9) };

            modelBuilder.Entity<Category>().HasData(category1);
            modelBuilder.Entity<Category>().HasData(category2);
            modelBuilder.Entity<Topic>().HasData(topic1);
            modelBuilder.Entity<Topic>().HasData(topic2);
            modelBuilder.Entity<Post>().HasData(post1);
            modelBuilder.Entity<Post>().HasData(post2);
            modelBuilder.Entity<Post>().HasData(post3);
            modelBuilder.Entity<Message>().HasData(message1);
            modelBuilder.Entity<Message>().HasData(message2);
        }
    }
}