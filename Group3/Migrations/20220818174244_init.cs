using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Group3.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    UserGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AurthorId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_AurthorId",
                        column: x => x.AurthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    AurthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_AspNetUsers_AurthorId",
                        column: x => x.AurthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => new { x.UserId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_Chats_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    UrlSlug = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: false),
                    AurthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_AspNetUsers_AurthorId",
                        column: x => x.AurthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupEnlistments",
                columns: table => new
                {
                    UserGroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupEnlistments", x => new { x.UserId, x.UserGroupId });
                    table.ForeignKey(
                        name: "FK_UserGroupEnlistments_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupEnlistments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AurthorId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 10000, nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Reports = table.Column<int>(nullable: false),
                    Votes = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AurthorId",
                        column: x => x.AurthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad9a9e0e-aaec-4797-80bc-ea0013a6351e", "8608006d-238e-49f7-a74d-5fe3e65b83e2", "Admin", "ADMIN" },
                    { "112357d5-067b-4cac-83eb-a9056aeb67ff", "343a46c9-7c93-433b-99d9-c8fc67898ed1", "User", "USER" },
                    { "df31ae63-4754-4ef3-b3ba-0580967d64fa", "0a1ea8be-7bcb-4aa1-8278-915bf10bc2c9", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "3b0a20db-dd0b-4250-a380-c99495f9e9af", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEAytaUOG9sb6S1mMDiVsMVVRtvGUq04e2InCqK47c/m3rBwfcgs4i85/YJKlnAOItw==", null, false, "7726a5f3-3366-4615-87bd-1a3fece8ba2d", false, "admin@fakemail.net" },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "32ff525a-d505-4670-9251-0c4642a0bd3f", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEMfmyHTCUK6/Z1fdn0MSyyMQ9WCnfenohdy3FWlC+Ym/i2wTx2Q1FjqRvJwXZJJQFQ==", null, false, "21f166bc-a54e-4a1d-bf0f-67264f59285c", false, "sara@fakemail.net" },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2633a0a1-baa7-43fc-bc26-cba468b52150", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEHkiV0TRADcOhBo3a9UO1ZibOl1iJBRLNSdg02wqgLhNv8zD8YAX4XORypIvWmqmZA==", null, false, "974b689d-5065-4b6f-994e-4b71f923a3bb", false, "bertil@fakemail.net" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UserGroupId" },
                values: new object[,]
                {
                    { -1, "Breaking news here!", "News", 0 },
                    { -2, "Javascript, React and more.", "Frontend", 0 },
                    { -3, "C++ and C#", "Backend", 0 },
                    { -4, "En grupp av testare.", "Testgruppen", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", "ad9a9e0e-aaec-4797-80bc-ea0013a6351e" },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", "112357d5-067b-4cac-83eb-a9056aeb67ff" },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", "df31ae63-4754-4ef3-b3ba-0580967d64fa" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 15, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(7791) },
                    { -4, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", "Umm..", new DateTime(2022, 8, 17, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(8582) },
                    { -5, "ad822b3e-9397-4236-b5bc-4d8fbad3935f", "Message from Bertil to Sara", new DateTime(2022, 8, 17, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(8585) },
                    { -2, "8312c899-ee18-4d2b-bc99-9f188ec471de", "Hello John!", new DateTime(2022, 8, 16, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(8549) },
                    { -3, "ad822b3e-9397-4236-b5bc-4d8fbad3935f", "What's up??", new DateTime(2022, 8, 17, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(8577) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -3, "bertil@fakemail.net/picture3.jpg", null, "ad822b3e-9397-4236-b5bc-4d8fbad3935f" },
                    { -1, "admin@fakemail.net/picture1.jpg", null, "eced1adc-6f6e-44d7-8e37-cb1b768aceea" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "8312c899-ee18-4d2b-bc99-9f188ec471de" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -6, "8312c899-ee18-4d2b-bc99-9f188ec471de", -4, "For random testing.", "User Group Test" },
                    { -1, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, "What's hot right now?", "Trending" },
                    { -5, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, "Planned occasions.", "Events" },
                    { -7, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, "Backend news", "Backend" },
                    { -8, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, "News about frontend subjects", "Frontend" },
                    { -9, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, "Other news", "Other" },
                    { -2, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "8312c899-ee18-4d2b-bc99-9f188ec471de", -2, "The necessary evil?", "CSS" },
                    { -4, "8312c899-ee18-4d2b-bc99-9f188ec471de", -3, "Because SQL is even worse.", "Entity Framework" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId" },
                values: new object[] { -1, null, -4 });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, -1 },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", -5, -3 },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", -5, -3 },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", -3, -2 },
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -3, -2 },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", -2, -1 },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", -2, -1 },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", -3, -2 },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", -4, -2 },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", -4, -2 },
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -4, -2 },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", -1, -1 },
                    { "8312c899-ee18-4d2b-bc99-9f188ec471de", -1, -1 },
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AurthorId", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -2, "8312c899-ee18-4d2b-bc99-9f188ec471de", "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", "Site launch", -5, "Site-launch" },
                    { -5, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", "Site presentation", -5, "Site-presentation" },
                    { -1, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", "HTML Tables?", -2, null },
                    { -3, "8312c899-ee18-4d2b-bc99-9f188ec471de", "Am I'm the chosen one?", -3, null },
                    { -6, "8312c899-ee18-4d2b-bc99-9f188ec471de", "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "UserId", "UserGroupId", "Id" },
                values: new object[,]
                {
                    { "eced1adc-6f6e-44d7-8e37-cb1b768aceea", -1, -1 },
                    { "ad822b3e-9397-4236-b5bc-4d8fbad3935f", -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "8312c899-ee18-4d2b-bc99-9f188ec471de", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 16, 19, 42, 43, 723, DateTimeKind.Local).AddTicks(4130), 1 },
                    { -2, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 17, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(5440), 0 },
                    { -7, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Site launch.<br><br>Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 11, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(5577), 0 },
                    { -8, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Site presentation.<br><br>Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 11, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(5989), 0 },
                    { -3, "eced1adc-6f6e-44d7-8e37-cb1b768aceea", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 13, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(5516), 3 },
                    { -4, "8312c899-ee18-4d2b-bc99-9f188ec471de", null, 1, -1, "I dont know..", new DateTime(2022, 8, 14, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(5522), 0 },
                    { -5, "ad822b3e-9397-4236-b5bc-4d8fbad3935f", null, 0, -1, "Me neither..", new DateTime(2022, 8, 18, 16, 42, 43, 725, DateTimeKind.Local).AddTicks(5526), 1 },
                    { -6, "8312c899-ee18-4d2b-bc99-9f188ec471de", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 18, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(5546), 1 },
                    { -9, "8312c899-ee18-4d2b-bc99-9f188ec471de", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 16, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(6021), 0 },
                    { -10, "ad822b3e-9397-4236-b5bc-4d8fbad3935f", null, 0, -6, "Anything.", new DateTime(2022, 8, 17, 19, 42, 43, 725, DateTimeKind.Local).AddTicks(6025), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_MessageId",
                table: "Chats",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AurthorId",
                table: "Messages",
                column: "AurthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PostId",
                table: "Pictures",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_UserId",
                table: "Pictures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AurthorId",
                table: "Posts",
                column: "AurthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubjectId",
                table: "Posts",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AurthorId",
                table: "Subjects",
                column: "AurthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TopicId",
                table: "Subjects",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_AurthorId",
                table: "Topics",
                column: "AurthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CategoryId",
                table: "Topics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupEnlistments_UserGroupId",
                table: "UserGroupEnlistments",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_ApplicationUserId",
                table: "UserGroups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_CategoryId",
                table: "UserGroups",
                column: "CategoryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "UserGroupEnlistments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
