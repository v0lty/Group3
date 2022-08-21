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
                                        IdentityUserToken<string>>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationParticipation> ConversationParticipations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserGroupEnlistment> UserGroupEnlistments { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.Author)
                .HasForeignKey(post => post.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(user => user.Pictures)
                .WithOne(picture => picture.User)
                .HasForeignKey(picture => picture.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Topic>()
                .HasOne(topic => topic.Category)
                .WithMany(category => category.Topics)
                .HasForeignKey(topic => topic.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
                .HasOne(subject => subject.Topic)
                .WithMany(topic => topic.Subjects)
                .HasForeignKey(subject => subject.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(post => post.Subject)
                .WithMany(subject => subject.Posts)
                .HasForeignKey(post => post.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConversationParticipation>()
                .HasKey(cp => new { cp.UserId, cp.ConversationId });

            modelBuilder.Entity<ConversationParticipation>()
                .HasOne(cp => cp.Conversation)
                .WithMany(c => c.ConversationParticipations)
                .HasForeignKey(cp => cp.ConversationId);

            modelBuilder.Entity<ConversationParticipation>()
                .HasOne(cp => cp.User)
                .WithMany(u => u.ConversationParticipations)
                .HasForeignKey(cp => cp.UserId);

            modelBuilder.Entity<Message>()
                .HasKey(m => new { m.AuthorId, m.ConversationId });

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Author)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.AuthorId);

            // TODO: User can't be deleted if there are message references to Author. 
            // rebuild database with this fix to see if it works..
            // It's not one-to-many or many-to-one RS so it should be something other then ForeignKey
            //modelBuilder.Entity<Message>()
            //    .HasMany(m => m.Chats)
            //    .WithOne(x => x.Message)
            //    .HasForeignKey(c => c.MessageId)
            //    .HasPrincipalKey(c => c.AuthorId)
            //    .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Category>()
                .HasOne(c => c.UserGroup)
                .WithOne(g => g.Category)
                .HasForeignKey<UserGroup>(b => b.CategoryId);

            modelBuilder.Entity<UserGroupEnlistment>()
                .HasKey(ur => new { ur.UserId, ur.UserGroupId });

            modelBuilder.Entity<UserGroupEnlistment>()
                .HasOne(m => m.UserGroup)
                .WithMany(g => g.UserGroupEnlistments)
                .HasForeignKey(m => m.UserGroupId);

            modelBuilder.Entity<UserGroupEnlistment>()
                .HasOne(e => e.User)
                .WithMany(u => u.UserGroupEnlistments)
                .HasForeignKey(e => e.UserId);

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
            var moderatorRole = new ApplicationRole() { Id = Guid.NewGuid().ToString(), Name = "Moderator", NormalizedName = "MODERATOR" };

            var adminUserRole = new ApplicationUserRole() { RoleId = adminRole.Id, UserId = Guid.NewGuid().ToString() };
            var user1UserRole = new ApplicationUserRole() { RoleId = userRole.Id, UserId = Guid.NewGuid().ToString() };
            var user2UserRole = new ApplicationUserRole() { RoleId = moderatorRole.Id, UserId = Guid.NewGuid().ToString() };

            var user1 = new ApplicationUser()
            {
                Id = adminUserRole.UserId,
                Email = "admin@fakemail.net",
                NormalizedEmail = "ADMIN@FAKEMAIL.NET",
                UserName = "admin@fakemail.net",
                NormalizedUserName = "ADMIN@FAKEMAIL.NET",
                FirstName = "John",
                LastName = "Doe",
                Location = "America",
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
                Location = "Danmark",
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
                Location = "Sweden",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password")
            };

            var category1 = new Category { Id = -1, Name = "News", Description = "Breaking news here!" };
            var category2 = new Category { Id = -2, Name = "Frontend", Description = "Javascript, React and more." };
            var category3 = new Category { Id = -3, Name = "Backend", Description = "C++ and C#" };
            var category4 = new Category { Id = -4, Name = "Testgruppen", Description = "En grupp av testare." };
            var category5 = new Category { Id = -5, Name = "Systems", Description = "Systems, programs & other tools for software development." };
            var category6 = new Category { Id = -6, Name = "Projects", Description = "Our own projects and ideas." };
            var category7 = new Category { Id = -7, Name = "Other", Description = "Anything else." };

            var userGroup1 = new UserGroup { Id = -1, CategoryId = category4.Id };

            var userGroupMember1 = new UserGroupEnlistment { Id = -1, UserId = user1.Id, UserGroupId = userGroup1.Id };
            var userGroupMember2 = new UserGroupEnlistment { Id = -2, UserId = user3.Id, UserGroupId = userGroup1.Id };

            var topic1 = new Topic { Id = -1, Name = "Trending", Description = "What's hot right now?", CategoryId = category1.Id, AuthorId = adminUserRole.UserId };
            var topic2 = new Topic { Id = -2, Name = "HTML", Description = "Tag TAG <b>TAG!</b>", CategoryId = category2.Id, AuthorId = user1.Id };
            var topic3 = new Topic { Id = -3, Name = "CSS", Description = "The necessary evil?", CategoryId = category2.Id, AuthorId = user2.Id };
            var topic4 = new Topic { Id = -4, Name = "Entity Framework", Description = "Because SQL is even worse.", CategoryId = category3.Id, AuthorId = user2.Id };
            var topic5 = new Topic { Id = -5, Name = "Events", Description = "Planned occasions.", CategoryId = category1.Id, AuthorId = adminUserRole.UserId };
            var topic6 = new Topic { Id = -6, Name = "User Group Test", Description = "For random testing.", CategoryId = category4.Id, AuthorId = user2.Id };
            var topic7 = new Topic { Id = -7, Name = "Backend", Description = "Backend news", CategoryId = category1.Id, AuthorId = adminUserRole.UserId };
            var topic8 = new Topic { Id = -8, Name = "Frontend", Description = "News about frontend subjects", CategoryId = category1.Id, AuthorId = adminUserRole.UserId };
            var topic9 = new Topic { Id = -9, Name = "Other", Description = "Other news", CategoryId = category1.Id, AuthorId = adminUserRole.UserId };
            var topic10 = new Topic { Id = -10, Name = "Unreal Engine", Description = "A 3D computer graphics game engine developed by Epic Games.", CategoryId = category5.Id, AuthorId = adminUserRole.UserId };
            var topic11 = new Topic { Id = -11, Name = "This Forum", Description = "About developing this very forum.", CategoryId = category6.Id, AuthorId = adminUserRole.UserId };
            var topic12 = new Topic { Id = -12, Name = "Games", Description = "Computer games.", CategoryId = category7.Id, AuthorId = adminUserRole.UserId };
            var topic13 = new Topic { Id = -13, Name = "Random Talk", Description = "Where we can talk about anything.", CategoryId = category7.Id, AuthorId = adminUserRole.UserId };

            var subject1 = new Subject { Id = -1, Name = "HTML Tables?", TopicId = topic2.Id, AuthorId = user1.Id };
            var subject2 = new Subject { Id = -2, Name = "Visual Studio 2022", TopicId = topic1.Id, AuthorId = user2.Id, UrlSlug = "Visual-Studio-2022" };
            var subject3 = new Subject { Id = -3, Name = "Am I'm the chosen one?", TopicId = topic3.Id, AuthorId = user2.Id };
            var subject4 = new Subject { Id = -4, Name = "Site launch", TopicId = topic5.Id, AuthorId = user1.Id, UrlSlug = "Site-launch" };
            var subject5 = new Subject { Id = -5, Name = "Site presentation", TopicId = topic5.Id, AuthorId = user1.Id, UrlSlug = "Site-presentation" };
            var subject6 = new Subject { Id = -6, Name = "What?.", TopicId = topic6.Id, AuthorId = user2.Id };
            var subject7 = new Subject { Id = -7, Name = "Say Hello Party", TopicId = topic5.Id, AuthorId = user1.Id, UrlSlug = "Say-Hello-Party" };

            var post1 = new Post { Id = -1, Text = "Is this version any good?", Time = DateTime.Now.AddDays(-2), SubjectId = subject2.Id, AuthorId = user2.Id, Reports = 0, Votes = 1 };
            var post2 = new Post { Id = -2, Text = "Maybe, but I'll stick with 2019!", Time = DateTime.Now.AddDays(-1), SubjectId = subject2.Id, AuthorId = user1.Id, Reports = 2, Votes = 0 };
            var post3 = new Post { Id = -3, Text = "How do I make a <b>table?</b>", Time = DateTime.Now.AddDays(-5), SubjectId = subject1.Id, AuthorId = user1.Id, Reports = 0, Votes = 3 };
            var post4 = new Post { Id = -4, Text = "I dont know..", Time = DateTime.Now.AddDays(-4), SubjectId = subject1.Id, AuthorId = user2.Id, Reports = 1, Votes = 0 };
            var post5 = new Post { Id = -5, Text = "Me neither..", Time = DateTime.Now.AddHours(-3), SubjectId = subject1.Id, AuthorId = user3.Id, Reports = 0, Votes = 1 };
            var post6 = new Post { Id = -6, Text = "WoW first post?!?", Time = DateTime.Now.AddYears(-3), SubjectId = subject3.Id, AuthorId = user2.Id, Reports = 0, Votes = 1 };
            var post7 = new Post { Id = -7, Text = "Day for site launch. We will see if it is possible to host the site on freeasphosting.net", Time = DateTime.Now.AddDays(-7), SubjectId = subject4.Id, AuthorId = user1.Id, Reports = 0, Votes = 0, EventDate = DateTime.Now.AddDays(2).Date };
            var post8 = new Post { Id = -8, Text = "Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", Time = DateTime.Now.AddDays(-7), SubjectId = subject5.Id, AuthorId = user1.Id, Reports = 0, Votes = 0, EventDate = DateTime.Now.AddDays(3).Date };
            var post9 = new Post { Id = -9, Text = "What should we talk about in our user group test forum?", Time = DateTime.Now.AddDays(-2), SubjectId = subject6.Id, AuthorId = user2.Id, Reports = 0, Votes = 0 };
            var post10 = new Post { Id = -10, Text = "Anything.", Time = DateTime.Now.AddDays(-1), SubjectId = subject6.Id, AuthorId = user3.Id, Reports = 0, Votes = 0 };
            var post11 = new Post { Id = -11, Text = "We will celebrate the completion of  our studies with a Say Hello Party on Tuesday 2022-08-23. We're starting a new category that we're naming Other. In that category, we create a topic that we call random talk. In that topic we start a 'Say Hello Party' subject. We will invite the students in the other groups to our forum. If they want, they can register and can contribute a hello in our 'Say Hello Party'.", Time = DateTime.Now.AddDays(-6), SubjectId = subject7.Id, AuthorId = user1.Id, Reports = 0, Votes = 0, EventDate = DateTime.Now.AddDays(3).Date };

            var picture1 = new Picture { Id = -1, Path = string.Format($"{user1.Email}/picture1.jpg"), UserId = user1.Id };
            var picture2 = new Picture { Id = -2, Path = string.Format($"{user2.Email}/picture2.jpg"), UserId = user2.Id };
            var picture3 = new Picture { Id = -3, Path = string.Format($"{user3.Email}/picture3.jpg"), UserId = user3.Id };

            var conversation1 = new Conversation { Id = -1 };
            var conversation2 = new Conversation { Id = -2 };
            var conversation3 = new Conversation { Id = -3 };

            var conversationParticipation1 = new ConversationParticipation { Id = -1, UserId = user1.Id, ConversationId = conversation1.Id };
            var conversationParticipation2 = new ConversationParticipation { Id = -2, UserId = user2.Id, ConversationId = conversation1.Id };
            var conversationParticipation3 = new ConversationParticipation { Id = -3, UserId = user3.Id, ConversationId = conversation1.Id };
            var conversationParticipation4 = new ConversationParticipation { Id = -4, UserId = user1.Id, ConversationId = conversation2.Id };
            var conversationParticipation5 = new ConversationParticipation { Id = -5, UserId = user2.Id, ConversationId = conversation2.Id };
            var conversationParticipation6 = new ConversationParticipation { Id = -6, UserId = user3.Id, ConversationId = conversation2.Id };
            var conversationParticipation7 = new ConversationParticipation { Id = -7, UserId = user2.Id, ConversationId = conversation3.Id };
            var conversationParticipation8 = new ConversationParticipation { Id = -8, UserId = user3.Id, ConversationId = conversation3.Id };

            var message1 = new Message { Id = -1, AuthorId = user1.Id, ConversationId = conversation1.Id, Time = DateTime.Now.AddDays(-3), Text = $"Hello {user2.FirstName} and {user3.FirstName} my name is {user1.FirstName}!" };
            var message2 = new Message { Id = -2, AuthorId = user2.Id, ConversationId = conversation1.Id, Time = DateTime.Now.AddDays(-2), Text = $"Hello {user1.FirstName}!" };
            var message3 = new Message { Id = -3, AuthorId = user3.Id, ConversationId = conversation2.Id, Time = DateTime.Now.AddDays(-1), Text = $"What's up??" };
            var message4 = new Message { Id = -4, AuthorId = user1.Id, ConversationId = conversation2.Id, Time = DateTime.Now.AddDays(-1), Text = $"Umm.." };
            var message5 = new Message { Id = -5, AuthorId = user3.Id, ConversationId = conversation3.Id, Time = DateTime.Now.AddDays(-1), Text = $"Message from {user3.FirstName} to {user2.FirstName}" };

            modelBuilder.Entity<ApplicationRole>().HasData(adminRole);
            modelBuilder.Entity<ApplicationRole>().HasData(userRole);
            modelBuilder.Entity<ApplicationRole>().HasData(moderatorRole);
            modelBuilder.Entity<ApplicationUserRole>().HasData(adminUserRole);
            modelBuilder.Entity<ApplicationUserRole>().HasData(user1UserRole);
            modelBuilder.Entity<ApplicationUserRole>().HasData(user2UserRole);
            modelBuilder.Entity<ApplicationUser>().HasData(user1);
            modelBuilder.Entity<ApplicationUser>().HasData(user2);
            modelBuilder.Entity<ApplicationUser>().HasData(user3);
            modelBuilder.Entity<Message>().HasData(message1);
            modelBuilder.Entity<Message>().HasData(message2);
            modelBuilder.Entity<Message>().HasData(message3);
            modelBuilder.Entity<Message>().HasData(message4);
            modelBuilder.Entity<Message>().HasData(message5);
            modelBuilder.Entity<Conversation>().HasData(conversation1);
            modelBuilder.Entity<Conversation>().HasData(conversation2);
            modelBuilder.Entity<Conversation>().HasData(conversation3);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation1);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation2);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation3);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation4);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation5);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation6);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation7);
            modelBuilder.Entity<ConversationParticipation>().HasData(conversationParticipation8);
            modelBuilder.Entity<Category>().HasData(category1);
            modelBuilder.Entity<Category>().HasData(category2);
            modelBuilder.Entity<Category>().HasData(category3);
            modelBuilder.Entity<Category>().HasData(category4);
            modelBuilder.Entity<Category>().HasData(category5);
            modelBuilder.Entity<Category>().HasData(category6);
            modelBuilder.Entity<Category>().HasData(category7);
            modelBuilder.Entity<Topic>().HasData(topic1);
            modelBuilder.Entity<Topic>().HasData(topic2);
            modelBuilder.Entity<Topic>().HasData(topic3);
            modelBuilder.Entity<Topic>().HasData(topic4);
            modelBuilder.Entity<Topic>().HasData(topic5);
            modelBuilder.Entity<Topic>().HasData(topic6);
            modelBuilder.Entity<Topic>().HasData(topic7);
            modelBuilder.Entity<Topic>().HasData(topic8);
            modelBuilder.Entity<Topic>().HasData(topic9);
            modelBuilder.Entity<Topic>().HasData(topic10);
            modelBuilder.Entity<Topic>().HasData(topic11);
            modelBuilder.Entity<Topic>().HasData(topic12);
            modelBuilder.Entity<Topic>().HasData(topic13);
            modelBuilder.Entity<Subject>().HasData(subject1);
            modelBuilder.Entity<Subject>().HasData(subject2);
            modelBuilder.Entity<Subject>().HasData(subject3);
            modelBuilder.Entity<Subject>().HasData(subject4);
            modelBuilder.Entity<Subject>().HasData(subject5);
            modelBuilder.Entity<Subject>().HasData(subject6);
            modelBuilder.Entity<Subject>().HasData(subject7);
            modelBuilder.Entity<Post>().HasData(post1);
            modelBuilder.Entity<Post>().HasData(post2);
            modelBuilder.Entity<Post>().HasData(post3);
            modelBuilder.Entity<Post>().HasData(post4);
            modelBuilder.Entity<Post>().HasData(post5);
            modelBuilder.Entity<Post>().HasData(post6);
            modelBuilder.Entity<Post>().HasData(post7);
            modelBuilder.Entity<Post>().HasData(post8);
            modelBuilder.Entity<Post>().HasData(post9);
            modelBuilder.Entity<Post>().HasData(post10);
            modelBuilder.Entity<Post>().HasData(post11);
            modelBuilder.Entity<Picture>().HasData(picture1);
            modelBuilder.Entity<Picture>().HasData(picture2);
            modelBuilder.Entity<Picture>().HasData(picture3);
            modelBuilder.Entity<UserGroup>().HasData(userGroup1);
            modelBuilder.Entity<UserGroupEnlistment>().HasData(userGroupMember1);
            modelBuilder.Entity<UserGroupEnlistment>().HasData(userGroupMember2);
        }
    }
}