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
                    UserGroup = table.Column<bool>(nullable: false)
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
                name: "UserGroupEnlistments",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ApplicationUserID = table.Column<string>(nullable: false),
                    UserGroupEnlistmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupEnlistments", x => new { x.ApplicationUserID, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_UserGroupEnlistments_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupEnlistments_Categories_CategoryId",
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
                    { "025d26ee-d9ad-4772-88b6-858171ae1816", "b4159dad-a5e5-4025-864e-a864e23f4075", "Admin", "ADMIN" },
                    { "ac4d534e-ea1e-4c5f-9474-52ff83581044", "c4bc9e14-fa19-43a2-b4ca-7e3a37a74627", "User", "USER" },
                    { "7111b311-d2f4-4dfd-b08e-f466033535f7", "d12f8a9d-8907-4895-8438-87f4ddaf7da6", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "68610bcc-36fc-4c58-aa7c-77a918fecf03", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "840e81b7-03ad-45bb-96fe-74a58c919af6", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEHclCOyrMNNO9OINmTiQwR6tBnuK178pWx7zyOOgNb0L4hgYsmuc8tyMcZZuZsTaZA==", null, false, "2bfa1ca7-39f5-4d19-9881-6f0bdf9bc6a9", false, "admin@fakemail.net" },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "8ef0caab-dd64-4445-b513-b877fd9a0aad", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEJOZ2gL3Q3qAuITPSooSWA+hDu+vPEmwxRsFAPipRxg77SNRwrlRscBvfY7aySlATw==", null, false, "6c6865c4-4ac0-43c7-b7f8-0ffdb3d3572d", false, "sara@fakemail.net" },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "4f4fe8c2-b660-45ad-8e31-1fd4cd423c9f", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEKTykMraMhN61O10opkXCtTUaUMhYfElL0lNJvceFFe3RpJlzBTtes5iWyJ22cqQVw==", null, false, "36bf3c9c-f9a1-407f-89ec-fc0bf1cc53b5", false, "bertil@fakemail.net" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UserGroup" },
                values: new object[,]
                {
                    { -1, "Breaking news here!", "News", false },
                    { -2, "Javascript, React and more.", "Frontend", false },
                    { -3, "C++ and C#", "Backend", false },
                    { -4, "En grupp av testare.", "Testgruppen", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "68610bcc-36fc-4c58-aa7c-77a918fecf03", "025d26ee-d9ad-4772-88b6-858171ae1816" },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", "7111b311-d2f4-4dfd-b08e-f466033535f7" },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", "ac4d534e-ea1e-4c5f-9474-52ff83581044" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -3, "435b23a4-d154-4f63-b83e-143c84e6a609", "What's up??", new DateTime(2022, 8, 11, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(9978) },
                    { -2, "50d630d5-d69f-4a7d-bc22-cf9758c91778", "Hello John!", new DateTime(2022, 8, 10, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(9957) },
                    { -5, "435b23a4-d154-4f63-b83e-143c84e6a609", "Message from Bertil to Sara", new DateTime(2022, 8, 11, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(9984) },
                    { -4, "68610bcc-36fc-4c58-aa7c-77a918fecf03", "Umm..", new DateTime(2022, 8, 11, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(9981) },
                    { -1, "68610bcc-36fc-4c58-aa7c-77a918fecf03", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 9, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(9446) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -2, "sara@fakemail.net/picture2.jpg", null, "50d630d5-d69f-4a7d-bc22-cf9758c91778" },
                    { -3, "admin@fakemail.net/picture3.jpg", null, "435b23a4-d154-4f63-b83e-143c84e6a609" },
                    { -1, "admin@fakemail.net/picture1.jpg", null, "68610bcc-36fc-4c58-aa7c-77a918fecf03" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -1, "68610bcc-36fc-4c58-aa7c-77a918fecf03", -1, "What's hot right now?", "Trending" },
                    { -5, "68610bcc-36fc-4c58-aa7c-77a918fecf03", -1, "Planned occasions.", "Events" },
                    { -2, "68610bcc-36fc-4c58-aa7c-77a918fecf03", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "50d630d5-d69f-4a7d-bc22-cf9758c91778", -2, "The necessary evil?", "CSS" },
                    { -4, "50d630d5-d69f-4a7d-bc22-cf9758c91778", -3, "Because SQL is even worse.", "Entity Framework" },
                    { -6, "50d630d5-d69f-4a7d-bc22-cf9758c91778", -4, "For random testing.", "User Group Test" }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "ApplicationUserID", "CategoryId", "UserGroupEnlistmentID" },
                values: new object[,]
                {
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", -4, -1 },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", -4, -2 }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "68610bcc-36fc-4c58-aa7c-77a918fecf03", -1, -1 },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", -5, -3 },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", -5, -3 },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", -3, -2 },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", -3, -2 },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", -2, -1 },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", -2, -1 },
                    { "68610bcc-36fc-4c58-aa7c-77a918fecf03", -3, -2 },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", -4, -2 },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", -4, -2 },
                    { "68610bcc-36fc-4c58-aa7c-77a918fecf03", -4, -2 },
                    { "435b23a4-d154-4f63-b83e-143c84e6a609", -1, -1 },
                    { "50d630d5-d69f-4a7d-bc22-cf9758c91778", -1, -1 },
                    { "68610bcc-36fc-4c58-aa7c-77a918fecf03", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AurthorId", "Name", "TopicId" },
                values: new object[,]
                {
                    { -3, "50d630d5-d69f-4a7d-bc22-cf9758c91778", "Am I'm the chosen one?", -3 },
                    { -2, "50d630d5-d69f-4a7d-bc22-cf9758c91778", "Visual Studio 2022", -1 },
                    { -4, "68610bcc-36fc-4c58-aa7c-77a918fecf03", "Site launch.", -5 },
                    { -5, "68610bcc-36fc-4c58-aa7c-77a918fecf03", "Site presentation.", -5 },
                    { -1, "68610bcc-36fc-4c58-aa7c-77a918fecf03", "HTML Tables?", -2 },
                    { -6, "50d630d5-d69f-4a7d-bc22-cf9758c91778", "What?.", -6 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "50d630d5-d69f-4a7d-bc22-cf9758c91778", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 10, 15, 33, 55, 415, DateTimeKind.Local).AddTicks(218), 1 },
                    { -2, "68610bcc-36fc-4c58-aa7c-77a918fecf03", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 11, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(7446), 0 },
                    { -7, "68610bcc-36fc-4c58-aa7c-77a918fecf03", new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Site launch.<br><br>Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 5, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(7674), 0 },
                    { -8, "68610bcc-36fc-4c58-aa7c-77a918fecf03", new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Site presentation.<br><br>Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 5, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(7985), 0 },
                    { -3, "68610bcc-36fc-4c58-aa7c-77a918fecf03", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 7, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(7500), 3 },
                    { -4, "50d630d5-d69f-4a7d-bc22-cf9758c91778", null, 1, -1, "I dont know..", new DateTime(2022, 8, 8, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(7504), 0 },
                    { -5, "435b23a4-d154-4f63-b83e-143c84e6a609", null, 0, -1, "Me neither..", new DateTime(2022, 8, 12, 12, 33, 55, 416, DateTimeKind.Local).AddTicks(7507), 1 },
                    { -6, "50d630d5-d69f-4a7d-bc22-cf9758c91778", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 12, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(7525), 1 },
                    { -9, "50d630d5-d69f-4a7d-bc22-cf9758c91778", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 10, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(8005), 0 },
                    { -10, "435b23a4-d154-4f63-b83e-143c84e6a609", null, 0, -6, "Anything.", new DateTime(2022, 8, 11, 15, 33, 55, 416, DateTimeKind.Local).AddTicks(8009), 0 }
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
                name: "IX_UserGroupEnlistments_CategoryId",
                table: "UserGroupEnlistments",
                column: "CategoryId");
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
