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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Picture> Pictures { get; set; }        
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Post>()
                .HasOne(p => p.Reference)
                .WithMany()
                .HasForeignKey(e => e.ReferenceId) ;

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.Aurthor)
                .HasForeignKey(post => post.AurthorId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Pictures)
                .WithOne(picture => picture.User)
                .HasForeignKey(picture => picture.UserId);

            modelBuilder.Entity<Topic>()
                .HasOne(topic => topic.Category)
                .WithMany(category => category.Topics)
                .HasForeignKey(topic => topic.CategoryId);

            modelBuilder.Entity<Post>()
                .HasMany(post => post.Pictures)
                .WithOne(picture => picture.Post)
                .HasForeignKey(picture => picture.PostId);

            modelBuilder.Entity<Post>()
                .HasOne(post => post.Topic)
                .WithMany(topic => topic.Posts)
                .HasForeignKey(post => post.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Chat>()
                .HasKey(ur => new { ur.UserId, ur.MessageId });

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Message)
                .WithMany(m => m.Chats)
                .HasForeignKey(ur => ur.MessageId);


            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            var adminRole = new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" };
            var userRole = new ApplicationRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" };

            modelBuilder.Entity<ApplicationRole>().HasData(adminRole);
            modelBuilder.Entity<ApplicationRole>().HasData(userRole);

            var adminUserRole = new ApplicationUserRole() { RoleId = adminRole.Id, UserId = Guid.NewGuid().ToString() };
            var user1UserRole = new ApplicationUserRole() { RoleId = userRole.Id, UserId = Guid.NewGuid().ToString() };
            var user2UserRole = new ApplicationUserRole() { RoleId = userRole.Id, UserId = Guid.NewGuid().ToString() };

            modelBuilder.Entity<ApplicationUserRole>().HasData(adminUserRole);
            modelBuilder.Entity<ApplicationUserRole>().HasData(user1UserRole);
            modelBuilder.Entity<ApplicationUserRole>().HasData(user2UserRole);

            var user1 = new ApplicationUser()
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
            };

            var user2 = new ApplicationUser()
            {
                Id = user1UserRole.UserId,
                Email = "sara@fakemail.net",
                NormalizedEmail = "SARA@FAKEMAIL.NET",
                UserName = "sara@fakemail.net",
                NormalizedUserName = "SARA@FAKEMAIL.NET",
                FirstName = "Sara",
                LastName = "Svensson",
                Birthdate = new DateTime(1993, 10, 18),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password")
            };

            var user3 = new ApplicationUser()
            {
                Id = user2UserRole.UserId,
                Email = "bertil@fakemail.net",
                NormalizedEmail = "BERTIL@FAKEMAIL.NET",
                UserName = "bertil@fakemail.net",
                NormalizedUserName = "BERTIL@FAKEMAIL.NET",
                FirstName = "Bertil",
                LastName = "Johansson",
                Birthdate = new DateTime(1985, 10, 10),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password")
            };

            var category1 = new Category { Id = -1, Name = "News" };
            var category2 = new Category { Id = -2, Name = "Frontend" };
            var category3 = new Category { Id = -3, Name = "Backend" };
            var category4 = new Category { Id = -4, Name = "Random" };

            var topic1 = new Topic { Id = -1, Name = "Trending", Description = "Upgrade your project to 6.0", CategoryId = category1.Id, AurthorId = adminUserRole.UserId };
            var topic2 = new Topic { Id = -2, Name = "HTML", Description = "What ever about HTML", CategoryId = category2.Id, AurthorId = user1UserRole.UserId };
            var topic3 = new Topic { Id = -3, Name = "CSS", Description = "Do it with style", CategoryId = category2.Id, AurthorId = user1UserRole.UserId };
            var topic4 = new Topic { Id = -4, Name = "Entity Framework", Description = "Your prefered database", CategoryId = category3.Id, AurthorId = user2UserRole.UserId };

            var post1 = new Post { Id = -1, Text = "<b>Visual Studio 6.0</b> news news news more news", Time = DateTime.Now.AddDays(-1), TopicId = topic1.Id, AurthorId = user2.Id };
            var post2 = new Post { Id = -2, Text = "My head is empty, should I fill it with something?", Time = DateTime.Now.AddDays(-2), TopicId = topic2.Id, AurthorId = user1.Id };
            var post3 = new Post { Id = -3, Text = "HoW do I make a table?", Time = DateTime.Now.AddDays(-5), TopicId = topic2.Id, AurthorId = user1.Id };
            var post4 = new Post { Id = -4, Text = "I dont know", Time = DateTime.Now.AddDays(-4), TopicId = topic2.Id, AurthorId = user1.Id, ReferenceId = post3.Id };

            var picture1 = new Picture { Id = -1, Path = string.Format($"{user1.Email}/picture1.jpg"), UserId = user1.Id, PostId = null };
            var picture2 = new Picture { Id = -2, Path = string.Format($"{user2.Email}/picture2.jpg"), UserId = user2.Id, PostId = null };
            var picture3 = new Picture { Id = -3, Path = string.Format($"{user1.Email}/picture3.jpg"), UserId = user1.Id, PostId = post1.Id };
            var picture4 = new Picture { Id = -4, Path = string.Format($"{user2.Email}/picture4.jpg"), UserId = user2.Id, PostId = post2.Id };
            var picture5 = new Picture { Id = -5, Path = string.Format($"{user3.Email}/picture5.jpg"), UserId = user3.Id, PostId = null };

            var message1 = new Message { Id = -1, AurthorId = user1.Id, Time = DateTime.Now.AddDays(-3), Text = $"Hello {user2.FirstName} and {user3.FirstName} my name is {user1.FirstName}!" };
            var message2 = new Message { Id = -2, AurthorId = user2.Id, Time = DateTime.Now.AddDays(-2), Text = $"Hello {user1.FirstName}!" };


            var message3 = new Message { Id = -3, AurthorId = user3.Id, Time = DateTime.Now.AddDays(-1), Text = $"What's up??" };
            var message4 = new Message { Id = -4, AurthorId = user1.Id, Time = DateTime.Now.AddDays(-1), Text = $"Umm.." };
            var message5 = new Message { Id = -5, AurthorId = user3.Id, Time = DateTime.Now.AddDays(-1), Text = $"Message from {user3.FirstName} to {user2.FirstName}" };

            modelBuilder.Entity<ApplicationUser>().HasData(user1);
            modelBuilder.Entity<ApplicationUser>().HasData(user2);
            modelBuilder.Entity<ApplicationUser>().HasData(user3);

            modelBuilder.Entity<Message>().HasData(message1);
            modelBuilder.Entity<Message>().HasData(message2);
            modelBuilder.Entity<Message>().HasData(message3);
            modelBuilder.Entity<Message>().HasData(message4);
            modelBuilder.Entity<Message>().HasData(message5);

            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -1, UserId = user1.Id, MessageId = message1.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -1, UserId = user2.Id, MessageId = message1.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -1, UserId = user3.Id, MessageId = message1.Id });

            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -1, UserId = user1.Id, MessageId = message2.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -1, UserId = user2.Id, MessageId = message2.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -1, UserId = user3.Id, MessageId = message2.Id });

            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -2, UserId = user1.Id, MessageId = message3.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -2, UserId = user2.Id, MessageId = message3.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -2, UserId = user3.Id, MessageId = message3.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -2, UserId = user1.Id, MessageId = message4.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -2, UserId = user2.Id, MessageId = message4.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -2, UserId = user3.Id, MessageId = message4.Id });

            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -3, UserId = user2.Id, MessageId = message5.Id });
            modelBuilder.Entity<Chat>().HasData(new Chat() { Id = -3, UserId = user3.Id, MessageId = message5.Id });

            modelBuilder.Entity<Category>().HasData(category1);
            modelBuilder.Entity<Category>().HasData(category2);
            modelBuilder.Entity<Category>().HasData(category3);
            modelBuilder.Entity<Category>().HasData(category4);

            modelBuilder.Entity<Topic>().HasData(topic1);
            modelBuilder.Entity<Topic>().HasData(topic2);

            modelBuilder.Entity<Post>().HasData(post1);
            modelBuilder.Entity<Post>().HasData(post2);
            modelBuilder.Entity<Post>().HasData(post3);
            modelBuilder.Entity<Post>().HasData(post4);

            modelBuilder.Entity<Picture>().HasData(picture1);
            modelBuilder.Entity<Picture>().HasData(picture2);
            modelBuilder.Entity<Picture>().HasData(picture3);
            modelBuilder.Entity<Picture>().HasData(picture4);
            modelBuilder.Entity<Picture>().HasData(picture5);
        }
    }
}