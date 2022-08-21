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
                    AuthorId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
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
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
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
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
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
                    AuthorId = table.Column<string>(nullable: true),
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
                        name: "FK_Posts_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
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
                    { "a58e458f-2945-4cad-94c5-1028f7110590", "18367f50-83c1-4e82-9c48-7cc40ecdc518", "Admin", "ADMIN" },
                    { "93603bd9-65d6-4907-ac82-c125e2e1a2f5", "e0fa134b-8685-4676-b55f-02d9011ae4a5", "User", "USER" },
                    { "c2daeab1-dfdb-474b-9755-f089c01c8fcd", "d3fce48c-06f0-44df-9b23-ff5afde6633d", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "5ab34ac7-e381-4b98-a3e9-53e7157611cd", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEPBiOBY0+nHlhsZ9cIXOFKGZbXm+FAlXccXLhUpRVG3/9tDJJ52X9ic2R1HK8qd0fg==", null, false, "e4d50f2c-359e-4817-86a3-e360b2388fb9", false, "admin@fakemail.net" },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "499846c3-d818-425d-8779-1e0bb79aee77", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEP5FrcFkYnWG2THiBsxV7p9oyYegi82crVjFYDHoZfvxmZLroQDSeJVPNWE6DZpxLw==", null, false, "bb1fc9f1-5a54-4c18-acb6-7be801f33634", false, "sara@fakemail.net" },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ffe37309-2c36-48be-a7b8-adff441bc488", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEER/fw+/aFlFUdpJDr9/eZEF+PzhVYc1WCXpWsnYq3ZdrdedgrjQyjU7SS5ZkERC1g==", null, false, "485f1296-6214-4ffd-9a13-ea23f3a41033", false, "bertil@fakemail.net" }
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
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", "a58e458f-2945-4cad-94c5-1028f7110590" },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", "93603bd9-65d6-4907-ac82-c125e2e1a2f5" },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", "c2daeab1-dfdb-474b-9755-f089c01c8fcd" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AuthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 18, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(2063) },
                    { -4, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", "Umm..", new DateTime(2022, 8, 20, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(2850) },
                    { -5, "5f89f8bb-742f-4fdf-9a50-3431742816ea", "Message from Bertil to Sara", new DateTime(2022, 8, 20, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(2854) },
                    { -2, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", "Hello John!", new DateTime(2022, 8, 19, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(2817) },
                    { -3, "5f89f8bb-742f-4fdf-9a50-3431742816ea", "What's up??", new DateTime(2022, 8, 20, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(2846) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -3, "bertil@fakemail.net/picture3.jpg", null, "5f89f8bb-742f-4fdf-9a50-3431742816ea" },
                    { -1, "admin@fakemail.net/picture1.jpg", null, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -6, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -4, "For random testing.", "User Group Test" },
                    { -1, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, "What's hot right now?", "Trending" },
                    { -5, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, "Planned occasions.", "Events" },
                    { -7, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, "Backend news", "Backend" },
                    { -8, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, "News about frontend subjects", "Frontend" },
                    { -9, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, "Other news", "Other" },
                    { -2, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -2, "The necessary evil?", "CSS" },
                    { -4, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -3, "Because SQL is even worse.", "Entity Framework" }
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
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, -1 },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", -5, -3 },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -5, -3 },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", -3, -2 },
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -3, -2 },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", -2, -1 },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -2, -1 },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -3, -2 },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", -4, -2 },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -4, -2 },
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -4, -2 },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", -1, -1 },
                    { "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", -1, -1 },
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AuthorId", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -2, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", "Site launch", -5, "Site-launch" },
                    { -5, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", "Site presentation", -5, "Site-presentation" },
                    { -1, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", "HTML Tables?", -2, null },
                    { -3, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", "Am I'm the chosen one?", -3, null },
                    { -6, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "UserId", "UserGroupId", "Id" },
                values: new object[,]
                {
                    { "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", -1, -1 },
                    { "5f89f8bb-742f-4fdf-9a50-3431742816ea", -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 19, 22, 16, 46, 876, DateTimeKind.Local).AddTicks(6699), 1 },
                    { -2, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 20, 22, 16, 46, 880, DateTimeKind.Local).AddTicks(9575), 0 },
                    { -7, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 14, 22, 16, 46, 880, DateTimeKind.Local).AddTicks(9741), 0 },
                    { -8, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 14, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(177), 0 },
                    { -3, "c399a4e0-286f-4750-bd7e-f40c86bdfaa7", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 16, 22, 16, 46, 880, DateTimeKind.Local).AddTicks(9673), 3 },
                    { -4, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", null, 1, -1, "I dont know..", new DateTime(2022, 8, 17, 22, 16, 46, 880, DateTimeKind.Local).AddTicks(9680), 0 },
                    { -5, "5f89f8bb-742f-4fdf-9a50-3431742816ea", null, 0, -1, "Me neither..", new DateTime(2022, 8, 21, 19, 16, 46, 880, DateTimeKind.Local).AddTicks(9684), 1 },
                    { -6, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 21, 22, 16, 46, 880, DateTimeKind.Local).AddTicks(9705), 1 },
                    { -9, "ce7d56d0-af41-4c7a-922e-bf98f4f22cad", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 19, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(207), 0 },
                    { -10, "5f89f8bb-742f-4fdf-9a50-3431742816ea", null, 0, -6, "Anything.", new DateTime(2022, 8, 20, 22, 16, 46, 881, DateTimeKind.Local).AddTicks(211), 0 }
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
                name: "IX_Messages_AuthorId",
                table: "Messages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PostId",
                table: "Pictures",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_UserId",
                table: "Pictures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubjectId",
                table: "Posts",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AuthorId",
                table: "Subjects",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TopicId",
                table: "Subjects",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_AuthorId",
                table: "Topics",
                column: "AuthorId");

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
