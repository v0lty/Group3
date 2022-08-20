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
                    { "67bf8721-6ad0-4d4d-9822-7cb4373c41b8", "df294bdb-f297-4930-a984-faa9c29d5d3d", "Admin", "ADMIN" },
                    { "f5f0a206-49eb-4853-b6a3-1b9ec6437ba6", "8c88a157-5ae5-4574-9b7b-cfdacec085f1", "User", "USER" },
                    { "e986e211-f357-47e9-ac2b-cd2d0d483ecf", "6c2a0d6a-3a75-4c0c-87cb-e254dea5f441", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0aeba54a-dee9-4bde-bc69-c8e36b84ce9c", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEMhcTG5fGGgN+haWmYMusDBwwA8nT+xtK+OZ5V3yN9CLi+leH4Mwr+PmOJmqASCjQA==", null, false, "04ce9277-d46a-4d9a-9f11-80a7a26aa240", false, "admin@fakemail.net" },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "5dd6c39a-39d4-43f1-b4b7-0b99f011025c", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEJdaw2umCVVfGiZ1ly3j6J2Z91cqWxvw1spNRXYeauUFAs/AdtD8QQaXl9oRfsmpSg==", null, false, "960d8f11-2955-4bcf-93de-b10e524f8001", false, "sara@fakemail.net" },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "95cf66b6-38ac-42f5-96f8-62b588a39889", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEJP5BwcKn7TGJvMeKYnp+EEhgj2K1+x73xEDKK88F/3SBmYO6GV/lAIshteWg2XVVQ==", null, false, "4918714a-b19d-43d6-b6f4-d1808a443f73", false, "bertil@fakemail.net" }
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
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", "67bf8721-6ad0-4d4d-9822-7cb4373c41b8" },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", "f5f0a206-49eb-4853-b6a3-1b9ec6437ba6" },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", "e986e211-f357-47e9-ac2b-cd2d0d483ecf" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 17, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(7238) },
                    { -4, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", "Umm..", new DateTime(2022, 8, 19, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(8041) },
                    { -5, "b0c60512-94cc-473c-abef-54bc748c8c6d", "Message from Bertil to Sara", new DateTime(2022, 8, 19, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(8044) },
                    { -2, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", "Hello John!", new DateTime(2022, 8, 18, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(8008) },
                    { -3, "b0c60512-94cc-473c-abef-54bc748c8c6d", "What's up??", new DateTime(2022, 8, 19, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(8037) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -3, "bertil@fakemail.net/picture3.jpg", null, "b0c60512-94cc-473c-abef-54bc748c8c6d" },
                    { -1, "admin@fakemail.net/picture1.jpg", null, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -6, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -4, "For random testing.", "User Group Test" },
                    { -1, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, "What's hot right now?", "Trending" },
                    { -5, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, "Planned occasions.", "Events" },
                    { -7, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, "Backend news", "Backend" },
                    { -8, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, "News about frontend subjects", "Frontend" },
                    { -9, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, "Other news", "Other" },
                    { -2, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -2, "The necessary evil?", "CSS" },
                    { -4, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -3, "Because SQL is even worse.", "Entity Framework" }
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
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, -1 },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", -5, -3 },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -5, -3 },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", -3, -2 },
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -3, -2 },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", -2, -1 },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -2, -1 },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -3, -2 },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", -4, -2 },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -4, -2 },
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -4, -2 },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", -1, -1 },
                    { "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", -1, -1 },
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AurthorId", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -2, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", "Site launch", -5, "Site-launch" },
                    { -5, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", "Site presentation", -5, "Site-presentation" },
                    { -1, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", "HTML Tables?", -2, null },
                    { -3, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", "Am I'm the chosen one?", -3, null },
                    { -6, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "UserId", "UserGroupId", "Id" },
                values: new object[,]
                {
                    { "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", -1, -1 },
                    { "b0c60512-94cc-473c-abef-54bc748c8c6d", -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 18, 10, 57, 35, 284, DateTimeKind.Local).AddTicks(9485), 1 },
                    { -2, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 19, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(4331), 0 },
                    { -7, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Site launch.<br><br>Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 13, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(4521), 0 },
                    { -8, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Site presentation.<br><br>Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 13, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(5020), 0 },
                    { -3, "a720d3e2-d05e-4ebc-94da-b27675bb7d1d", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 15, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(4449), 3 },
                    { -4, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", null, 1, -1, "I dont know..", new DateTime(2022, 8, 16, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(4455), 0 },
                    { -5, "b0c60512-94cc-473c-abef-54bc748c8c6d", null, 0, -1, "Me neither..", new DateTime(2022, 8, 20, 7, 57, 35, 287, DateTimeKind.Local).AddTicks(4459), 1 },
                    { -6, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 20, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(4485), 1 },
                    { -9, "0088cce0-b87c-4f12-a73c-ef4c0ed74e7f", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 18, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(5050), 0 },
                    { -10, "b0c60512-94cc-473c-abef-54bc748c8c6d", null, 0, -6, "Anything.", new DateTime(2022, 8, 19, 10, 57, 35, 287, DateTimeKind.Local).AddTicks(5054), 0 }
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
