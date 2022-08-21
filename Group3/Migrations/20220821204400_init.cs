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
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
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
                name: "ConversationParticipations",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ConversationId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationParticipations", x => new { x.UserId, x.ConversationId });
                    table.ForeignKey(
                        name: "FK_ConversationParticipations_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationParticipations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    AuthorId = table.Column<string>(nullable: false),
                    ConversationId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => new { x.AuthorId, x.ConversationId });
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
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
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MessageId = table.Column<int>(nullable: false),
                    MessageAuthorId = table.Column<string>(nullable: false),
                    MessageConversationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_Messages_MessageAuthorId_MessageConversationId",
                        columns: x => new { x.MessageAuthorId, x.MessageConversationId },
                        principalTable: "Messages",
                        principalColumns: new[] { "AuthorId", "ConversationId" },
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
                    { "fc43b598-9198-4c71-8a1e-0d5cf76a89c6", "58d07abb-83b1-40bc-be76-65af4ea21381", "Admin", "ADMIN" },
                    { "1c9ceab9-5128-47f0-a3d4-c897bbbacfde", "47683e54-bb97-40c8-913c-b378578c08d4", "User", "USER" },
                    { "5d845df1-891b-4c4a-b842-45cc2e61a062", "0ed1896b-e248-4ed1-89fa-7bc5c55d879f", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21f94a80-8673-4807-aba9-60f7b0250293", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "21c471ba-cd3e-4642-b809-80af0491325b", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEExOFAkTB6ErMQWZK4ZYZbdyyGfCcMSkp71KMS2vP8GLmja6Ic5NqNBNrpR4NRMEmg==", null, false, "36998398-657c-4e39-8a43-5747dc90d458", false, "admin@fakemail.net" },
                    { "abc95e0f-15ea-4558-8485-d8c87b7677c8", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "74c25336-f581-4088-8221-8d699d77bbeb", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEG64dKQIQmqrv+0Ob8/JO9tONN6ttElzj+ozuK+3jiIMkqw9J7YBUIS1/CTE418ygg==", null, false, "7ba4ef3f-f31a-46fe-88f6-6bc9fbbca7f0", false, "sara@fakemail.net" },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "acc1a547-8ca2-405a-ba5f-76bacf389574", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEFVK1nuE0rHPfIhvSGsl/xj9H5H/GWcTMvX9oXiAthgAi2oNT2AEJrWpFSCBcXZiug==", null, false, "dedd24d6-80e0-4b3c-bf4b-4258e9fc4c99", false, "bertil@fakemail.net" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UserGroupId" },
                values: new object[,]
                {
                    { -1, "Breaking news here!", "News", 0 },
                    { -2, "Javascript, React and more.", "Frontend", 0 },
                    { -3, "C++ and C#", "Backend", 0 },
                    { -4, "En grupp av testare.", "Testgruppen", 0 },
                    { -5, "Systems, programs & other tools for software development.", "Systems", 0 },
                    { -6, "Our own projects and ideas.", "Projects", 0 },
                    { -7, "Anything else.", "Other", 0 }
                });

            migrationBuilder.InsertData(
                table: "Conversations",
                column: "Id",
                values: new object[]
                {
                    -1,
                    -2,
                    -3
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "21f94a80-8673-4807-aba9-60f7b0250293", "fc43b598-9198-4c71-8a1e-0d5cf76a89c6" },
                    { "abc95e0f-15ea-4558-8485-d8c87b7677c8", "1c9ceab9-5128-47f0-a3d4-c897bbbacfde" },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", "5d845df1-891b-4c4a-b842-45cc2e61a062" }
                });

            migrationBuilder.InsertData(
                table: "ConversationParticipations",
                columns: new[] { "UserId", "ConversationId", "Id" },
                values: new object[,]
                {
                    { "abc95e0f-15ea-4558-8485-d8c87b7677c8", -3, -7 },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", -2, -6 },
                    { "abc95e0f-15ea-4558-8485-d8c87b7677c8", -2, -5 },
                    { "21f94a80-8673-4807-aba9-60f7b0250293", -2, -4 },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", -1, -3 },
                    { "abc95e0f-15ea-4558-8485-d8c87b7677c8", -1, -2 },
                    { "21f94a80-8673-4807-aba9-60f7b0250293", -1, -1 },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", -3, -8 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "AuthorId", "ConversationId", "Id", "Text", "Time" },
                values: new object[,]
                {
                    { "21f94a80-8673-4807-aba9-60f7b0250293", -2, -4, "Umm..", new DateTime(2022, 8, 20, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(8391) },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", -2, -3, "What's up??", new DateTime(2022, 8, 20, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(8388) },
                    { "abc95e0f-15ea-4558-8485-d8c87b7677c8", -1, -2, "Hello John!", new DateTime(2022, 8, 19, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(8366) },
                    { "21f94a80-8673-4807-aba9-60f7b0250293", -1, -1, "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 18, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(7845) },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", -3, -5, "Message from Bertil to Sara", new DateTime(2022, 8, 20, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(8393) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -1, "admin@fakemail.net/picture1.jpg", null, "21f94a80-8673-4807-aba9-60f7b0250293" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "abc95e0f-15ea-4558-8485-d8c87b7677c8" },
                    { -3, "bertil@fakemail.net/picture3.jpg", null, "268f2d5f-0bd0-4e51-b3ba-ce653eab541b" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -6, "abc95e0f-15ea-4558-8485-d8c87b7677c8", -4, "For random testing.", "User Group Test" },
                    { -1, "21f94a80-8673-4807-aba9-60f7b0250293", -1, "What's hot right now?", "Trending" },
                    { -5, "21f94a80-8673-4807-aba9-60f7b0250293", -1, "Planned occasions.", "Events" },
                    { -7, "21f94a80-8673-4807-aba9-60f7b0250293", -1, "Backend news", "Backend" },
                    { -8, "21f94a80-8673-4807-aba9-60f7b0250293", -1, "News about frontend subjects", "Frontend" },
                    { -2, "21f94a80-8673-4807-aba9-60f7b0250293", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "abc95e0f-15ea-4558-8485-d8c87b7677c8", -2, "The necessary evil?", "CSS" },
                    { -4, "abc95e0f-15ea-4558-8485-d8c87b7677c8", -3, "Because SQL is even worse.", "Entity Framework" },
                    { -13, "21f94a80-8673-4807-aba9-60f7b0250293", -7, "Where we can talk about anything.", "Random Talk" },
                    { -12, "21f94a80-8673-4807-aba9-60f7b0250293", -7, "Computer games.", "Games" },
                    { -11, "21f94a80-8673-4807-aba9-60f7b0250293", -6, "About developing this very forum.", "This Forum" },
                    { -9, "21f94a80-8673-4807-aba9-60f7b0250293", -1, "Other news", "Other" },
                    { -10, "21f94a80-8673-4807-aba9-60f7b0250293", -5, "A 3D computer graphics game engine developed by Epic Games.", "Unreal Engine" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId" },
                values: new object[] { -1, null, -4 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AuthorId", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -2, "abc95e0f-15ea-4558-8485-d8c87b7677c8", "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "21f94a80-8673-4807-aba9-60f7b0250293", "Site launch", -5, "Site-launch" },
                    { -5, "21f94a80-8673-4807-aba9-60f7b0250293", "Site presentation", -5, "Site-presentation" },
                    { -7, "21f94a80-8673-4807-aba9-60f7b0250293", "Say Hello Party", -5, "Say-Hello-Party" },
                    { -1, "21f94a80-8673-4807-aba9-60f7b0250293", "HTML Tables?", -2, null },
                    { -3, "abc95e0f-15ea-4558-8485-d8c87b7677c8", "Am I'm the chosen one?", -3, null },
                    { -6, "abc95e0f-15ea-4558-8485-d8c87b7677c8", "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "UserId", "UserGroupId", "Id" },
                values: new object[,]
                {
                    { "21f94a80-8673-4807-aba9-60f7b0250293", -1, -1 },
                    { "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "abc95e0f-15ea-4558-8485-d8c87b7677c8", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 19, 22, 43, 59, 669, DateTimeKind.Local).AddTicks(3076), 1 },
                    { -2, "21f94a80-8673-4807-aba9-60f7b0250293", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 20, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4144), 0 },
                    { -7, "21f94a80-8673-4807-aba9-60f7b0250293", new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 14, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4279), 0 },
                    { -8, "21f94a80-8673-4807-aba9-60f7b0250293", new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 14, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4717), 0 },
                    { -11, "21f94a80-8673-4807-aba9-60f7b0250293", new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), 0, -7, "We will celebrate the completion of  our studies with a Say Hello Party on Tuesday 2022-08-23. We're starting a new category that we're naming Other. In that category, we create a topic that we call random talk. In that topic we start a 'Say Hello Party' subject. We will invite the students in the other groups to our forum. If they want, they can register and can contribute a hello in our 'Say Hello Party'.", new DateTime(2022, 8, 15, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4745), 0 },
                    { -3, "21f94a80-8673-4807-aba9-60f7b0250293", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 16, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4226), 3 },
                    { -4, "abc95e0f-15ea-4558-8485-d8c87b7677c8", null, 1, -1, "I dont know..", new DateTime(2022, 8, 17, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4232), 0 },
                    { -5, "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", null, 0, -1, "Me neither..", new DateTime(2022, 8, 21, 19, 43, 59, 671, DateTimeKind.Local).AddTicks(4234), 1 },
                    { -6, "abc95e0f-15ea-4558-8485-d8c87b7677c8", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 21, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4253), 1 },
                    { -9, "abc95e0f-15ea-4558-8485-d8c87b7677c8", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 19, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4739), 0 },
                    { -10, "268f2d5f-0bd0-4e51-b3ba-ce653eab541b", null, 0, -6, "Anything.", new DateTime(2022, 8, 20, 22, 43, 59, 671, DateTimeKind.Local).AddTicks(4742), 0 }
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
                name: "IX_Chat_UserId",
                table: "Chat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_MessageAuthorId_MessageConversationId",
                table: "Chat",
                columns: new[] { "MessageAuthorId", "MessageConversationId" });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipations_ConversationId",
                table: "ConversationParticipations",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

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
                name: "Chat");

            migrationBuilder.DropTable(
                name: "ConversationParticipations");

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
                name: "Conversations");

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
