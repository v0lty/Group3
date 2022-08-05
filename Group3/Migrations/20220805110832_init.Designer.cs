﻿// <auto-generated />
using System;
using Group3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Group3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220805110832_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Group3.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "3ba57f22-cadf-42e1-9aca-f7aa4eb1d145",
                            ConcurrencyStamp = "679856e9-85a8-4122-abc1-ad4bcb988676",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "6de84da1-d6fd-4f17-84a0-39d098eeac43",
                            ConcurrencyStamp = "b3ea367a-a484-4a53-ab48-3c3af6627b02",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "87b24ab2-7440-48f1-b18b-d51453cde95e",
                            ConcurrencyStamp = "b4ecfbe7-1ab0-41e2-bd82-4628decd23a5",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        });
                });

            modelBuilder.Entity("Group3.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "f81759a6-4263-4da5-9e80-fffca2051e41",
                            Email = "admin@fakemail.net",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@FAKEMAIL.NET",
                            NormalizedUserName = "ADMIN@FAKEMAIL.NET",
                            PasswordHash = "AQAAAAEAACcQAAAAEF3rkHL/9ULWZXFSm/HCsZrE6cm1fS50GYJyaSvBh49YOVwUgvAnxjenCik3TolzIQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2d8464dd-4724-413a-bac8-74d4547473f9",
                            TwoFactorEnabled = false,
                            UserName = "admin@fakemail.net"
                        },
                        new
                        {
                            Id = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "58039ac2-4d04-496c-a099-e0609a6bf54d",
                            Email = "sara@fakemail.net",
                            EmailConfirmed = false,
                            FirstName = "Sara",
                            LastName = "Svensson",
                            LockoutEnabled = false,
                            NormalizedEmail = "SARA@FAKEMAIL.NET",
                            NormalizedUserName = "SARA@FAKEMAIL.NET",
                            PasswordHash = "AQAAAAEAACcQAAAAECNZ+a1quVGXJ0X87/9mTtFnpt6AOYEUw6z7O0Bv9GDanLzGguPgE25MkUkkzVqayQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ff6dd937-b3b6-4a3c-9514-0c3a59337895",
                            TwoFactorEnabled = false,
                            UserName = "sara@fakemail.net"
                        },
                        new
                        {
                            Id = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            AccessFailedCount = 0,
                            Birthdate = new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "4bff0ade-5250-4f37-b101-be540ede5234",
                            Email = "bertil@fakemail.net",
                            EmailConfirmed = false,
                            FirstName = "Bertil",
                            LastName = "Johansson",
                            LockoutEnabled = false,
                            NormalizedEmail = "BERTIL@FAKEMAIL.NET",
                            NormalizedUserName = "BERTIL@FAKEMAIL.NET",
                            PasswordHash = "AQAAAAEAACcQAAAAEGH1+8uiId5vn5A4FpPWUlF9xR8eVu8HCLlPtmBCeQqOwjfGfqIxSUHWHalLuYO7uA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4b241ebf-c679-4003-8bf8-bfefe3bffe37",
                            TwoFactorEnabled = false,
                            UserName = "bertil@fakemail.net"
                        });
                });

            modelBuilder.Entity("Group3.Models.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            RoleId = "3ba57f22-cadf-42e1-9aca-f7aa4eb1d145"
                        },
                        new
                        {
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            RoleId = "6de84da1-d6fd-4f17-84a0-39d098eeac43"
                        },
                        new
                        {
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            RoleId = "87b24ab2-7440-48f1-b18b-d51453cde95e"
                        });
                });

            modelBuilder.Entity("Group3.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Breaking news here!",
                            Name = "News"
                        },
                        new
                        {
                            Id = -2,
                            Description = "Javascript, React and more.",
                            Name = "Frontend"
                        },
                        new
                        {
                            Id = -3,
                            Description = "C++ and C#",
                            Name = "Backend"
                        });
                });

            modelBuilder.Entity("Group3.Models.Chat", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            UserId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            MessageId = -1,
                            Id = -1
                        },
                        new
                        {
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            MessageId = -1,
                            Id = -1
                        },
                        new
                        {
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            MessageId = -1,
                            Id = -1
                        },
                        new
                        {
                            UserId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            MessageId = -2,
                            Id = -1
                        },
                        new
                        {
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            MessageId = -2,
                            Id = -1
                        },
                        new
                        {
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            MessageId = -2,
                            Id = -1
                        },
                        new
                        {
                            UserId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            MessageId = -3,
                            Id = -2
                        },
                        new
                        {
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            MessageId = -3,
                            Id = -2
                        },
                        new
                        {
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            MessageId = -3,
                            Id = -2
                        },
                        new
                        {
                            UserId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            MessageId = -4,
                            Id = -2
                        },
                        new
                        {
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            MessageId = -4,
                            Id = -2
                        },
                        new
                        {
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            MessageId = -4,
                            Id = -2
                        },
                        new
                        {
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            MessageId = -5,
                            Id = -3
                        },
                        new
                        {
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            MessageId = -5,
                            Id = -3
                        });
                });

            modelBuilder.Entity("Group3.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AurthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(10000);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AurthorId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            Text = "Hello Sara and Bertil my name is John!",
                            Time = new DateTime(2022, 8, 2, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(8149)
                        },
                        new
                        {
                            Id = -2,
                            AurthorId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            Text = "Hello John!",
                            Time = new DateTime(2022, 8, 3, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9041)
                        },
                        new
                        {
                            Id = -3,
                            AurthorId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            Text = "What's up??",
                            Time = new DateTime(2022, 8, 4, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9070)
                        },
                        new
                        {
                            Id = -4,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            Text = "Umm..",
                            Time = new DateTime(2022, 8, 4, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9074)
                        },
                        new
                        {
                            Id = -5,
                            AurthorId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b",
                            Text = "Message from Bertil to Sara",
                            Time = new DateTime(2022, 8, 4, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9078)
                        });
                });

            modelBuilder.Entity("Group3.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Pictures");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Path = "admin@fakemail.net/picture1.jpg",
                            UserId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6"
                        },
                        new
                        {
                            Id = -2,
                            Path = "sara@fakemail.net/picture2.jpg",
                            UserId = "4c9712e9-1359-439a-b161-e4f4d5047148"
                        },
                        new
                        {
                            Id = -3,
                            Path = "admin@fakemail.net/picture3.jpg",
                            UserId = "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b"
                        });
                });

            modelBuilder.Entity("Group3.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AurthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Reports")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(10000);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AurthorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AurthorId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            Reports = 0,
                            Text = "<b>Visual Studio 6.0</b> news news news more news",
                            Time = new DateTime(2022, 8, 4, 13, 8, 31, 847, DateTimeKind.Local).AddTicks(669),
                            TopicId = -1,
                            Votes = 1
                        },
                        new
                        {
                            Id = -2,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            Reports = 2,
                            Text = "My head is empty, should I fill it with something?",
                            Time = new DateTime(2022, 8, 3, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(5783),
                            TopicId = -1,
                            Votes = 0
                        },
                        new
                        {
                            Id = -3,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            Reports = 0,
                            Text = "How do I make a table?",
                            Time = new DateTime(2022, 7, 31, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(5887),
                            TopicId = -2,
                            Votes = 3
                        },
                        new
                        {
                            Id = -4,
                            AurthorId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            Reports = 1,
                            Text = "I dont know..",
                            Time = new DateTime(2022, 8, 1, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(5896),
                            TopicId = -2,
                            Votes = 0
                        });
                });

            modelBuilder.Entity("Group3.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AurthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AurthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            CategoryId = -1,
                            Name = "Trending"
                        },
                        new
                        {
                            Id = -2,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            CategoryId = -2,
                            Name = "HTML"
                        },
                        new
                        {
                            Id = -3,
                            AurthorId = "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6",
                            CategoryId = -2,
                            Name = "CSS"
                        },
                        new
                        {
                            Id = -4,
                            AurthorId = "4c9712e9-1359-439a-b161-e4f4d5047148",
                            CategoryId = -3,
                            Name = "Entity Framework"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Group3.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("Group3.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group3.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Group3.Models.Chat", b =>
                {
                    b.HasOne("Group3.Models.Message", "Message")
                        .WithMany("Chats")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group3.Models.ApplicationUser", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Group3.Models.Message", b =>
                {
                    b.HasOne("Group3.Models.ApplicationUser", "Aurthor")
                        .WithMany()
                        .HasForeignKey("AurthorId");
                });

            modelBuilder.Entity("Group3.Models.Picture", b =>
                {
                    b.HasOne("Group3.Models.Post", null)
                        .WithMany("Pictures")
                        .HasForeignKey("PostId");

                    b.HasOne("Group3.Models.ApplicationUser", "User")
                        .WithMany("Pictures")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Group3.Models.Post", b =>
                {
                    b.HasOne("Group3.Models.ApplicationUser", "Aurthor")
                        .WithMany("Posts")
                        .HasForeignKey("AurthorId");

                    b.HasOne("Group3.Models.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Group3.Models.Topic", b =>
                {
                    b.HasOne("Group3.Models.ApplicationUser", "Aurthor")
                        .WithMany()
                        .HasForeignKey("AurthorId");

                    b.HasOne("Group3.Models.Category", "Category")
                        .WithMany("Topics")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Group3.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Group3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Group3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Group3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}