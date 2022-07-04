using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

using Group3.Models;

// DELETE DATABASE:
// remove migration folder
// sqllocaldb stop
// sqllocaldb delete
// remove C:\Users\%USER%\MyDB.mdf
// remove C:\Users\%USER%\MyDB_log.ldf

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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User)
                .HasPrincipalKey(user => user.Id)
                .HasForeignKey(post => post.UserId);

            modelBuilder.Entity<ApplicationUser>()
                 .HasMany(user => user.Messages)
                 .WithOne(message => message.User)
                 .HasPrincipalKey(user => user.Id)
                 .HasForeignKey(message => message.UserId);

            modelBuilder.Entity<Post>()
                .HasOne(post => post.Topic)
                .WithMany(topic => topic.Posts)
                .HasPrincipalKey(topic => topic.Id)
                .HasForeignKey(post => post.TopicId);

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

            var category1 = new Category { Id = Guid.NewGuid().ToString(), Name = "Category 1" };
            var category2 = new Category { Id = Guid.NewGuid().ToString(), Name = "Category 2" };

            var topic1 = new Topic { Id = Guid.NewGuid().ToString(), Name = "Topic 2", CategoryId = category1.Id, UserId = adminUserRole.UserId };
            var topic2 = new Topic { Id = Guid.NewGuid().ToString(), Name = "Topic 1", CategoryId = category2.Id, UserId = userUserRole.UserId };

            var post1 = new Post { Id = Guid.NewGuid().ToString(), Text = "Test in post 1", Time = DateTime.Now.AddDays(-1), TopicId = topic1.Id, UserId = userUserRole.UserId };
            var post2 = new Post { Id = Guid.NewGuid().ToString(), Text = "Text in post 2", Time = DateTime.Now.AddDays(-2), TopicId = topic2.Id, UserId = adminUserRole.UserId };
            var post3 = new Post { Id = Guid.NewGuid().ToString(), Text = "Text in post 3", Time = DateTime.Now.AddDays(-5), TopicId = topic2.Id, UserId = adminUserRole.UserId };

            var message1 = new Message { Id = Guid.NewGuid().ToString(), UserId = adminUserRole.UserId, ReceiverId = userUserRole.UserId, Text = "Message 1", Time = DateTime.Now.AddDays(-3) };
            var message2 = new Message { Id = Guid.NewGuid().ToString(), UserId = userUserRole.UserId, ReceiverId = adminUserRole.UserId, Text = "Message 2", Time = DateTime.Now.AddDays(-9) };

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