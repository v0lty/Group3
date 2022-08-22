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
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(nullable: true),
                    ConversationId = table.Column<int>(nullable: false),
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
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
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
                    { "d3512c4d-928f-45f8-9537-048a2845d498", "7a1c173d-3629-451f-a6ba-f1094185a1ff", "Admin", "ADMIN" },
                    { "e3e8fae8-9bdd-4f66-ac0d-ff6b5b15bf27", "9e65105d-c38e-46ff-88fc-52b06b87c207", "User", "USER" },
                    { "3991ffee-8584-44c6-8a06-26c5de1103f4", "bfc725e0-9239-4377-aeeb-df1d663752ff", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b22c4502-8189-4ec2-a0a3-4455523c3611", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2440e29d-54cb-4772-b985-21a5776cd3df", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEJsAm0vYl262l2/4KYmuuTBhrVuKihy/AP0pzB5i5b/562/yddMqdNbdLUOtyeYEgA==", null, false, "baed9521-a744-4d3d-a8fd-d78ca556377d", false, "admin@fakemail.net" },
                    { "667f8bd6-2e63-4d17-a16e-6cd0857843c1", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "2377499c-95d4-4da4-a0c3-4e31338ab611", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEK1+CHPs+YB2IvmA+fa1ihkYU4LFI4S6YFZKpPyQ2mma0AplXddfZF7Cxl2aSnc5xg==", null, false, "419c9583-497b-4b09-8f74-d543ace59ac4", false, "sara@fakemail.net" },
                    { "d77955c1-26d7-4bcc-89b2-c0810599414d", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "169bdb2c-7102-4ffb-9ab8-c61b343d8e3a", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAENdIkw4FOQeD2LYWxNEKefCcK8eGychqbk/7+HX6qhVx7eISzacqIkYpA82vhK9Qxw==", null, false, "d5112de6-c7aa-4a5e-8fcc-2ba4eb6838fc", false, "bertil@fakemail.net" }
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
                    { "b22c4502-8189-4ec2-a0a3-4455523c3611", "d3512c4d-928f-45f8-9537-048a2845d498" },
                    { "667f8bd6-2e63-4d17-a16e-6cd0857843c1", "e3e8fae8-9bdd-4f66-ac0d-ff6b5b15bf27" },
                    { "d77955c1-26d7-4bcc-89b2-c0810599414d", "3991ffee-8584-44c6-8a06-26c5de1103f4" }
                });

            migrationBuilder.InsertData(
                table: "ConversationParticipations",
                columns: new[] { "UserId", "ConversationId", "Id" },
                values: new object[,]
                {
                    { "667f8bd6-2e63-4d17-a16e-6cd0857843c1", -3, -7 },
                    { "d77955c1-26d7-4bcc-89b2-c0810599414d", -2, -6 },
                    { "b22c4502-8189-4ec2-a0a3-4455523c3611", -2, -4 },
                    { "d77955c1-26d7-4bcc-89b2-c0810599414d", -1, -3 },
                    { "667f8bd6-2e63-4d17-a16e-6cd0857843c1", -1, -2 },
                    { "b22c4502-8189-4ec2-a0a3-4455523c3611", -1, -1 },
                    { "d77955c1-26d7-4bcc-89b2-c0810599414d", -3, -8 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AuthorId", "ConversationId", "Text", "Time" },
                values: new object[,]
                {
                    { -4, "b22c4502-8189-4ec2-a0a3-4455523c3611", -2, "Umm..", new DateTime(2022, 8, 21, 22, 51, 59, 877, DateTimeKind.Local).AddTicks(9737) },
                    { -3, "d77955c1-26d7-4bcc-89b2-c0810599414d", -2, "What's up??", new DateTime(2022, 8, 21, 22, 51, 59, 877, DateTimeKind.Local).AddTicks(9712) },
                    { -2, "667f8bd6-2e63-4d17-a16e-6cd0857843c1", -1, "Hello John!", new DateTime(2022, 8, 20, 22, 51, 59, 877, DateTimeKind.Local).AddTicks(9573) },
                    { -1, "b22c4502-8189-4ec2-a0a3-4455523c3611", -1, "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 19, 22, 51, 59, 877, DateTimeKind.Local).AddTicks(4844) },
                    { -5, "d77955c1-26d7-4bcc-89b2-c0810599414d", -3, "Message from Bertil to Sara", new DateTime(2022, 8, 21, 22, 51, 59, 877, DateTimeKind.Local).AddTicks(9751) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -1, "admin@fakemail.net/picture1.jpg", null, "b22c4502-8189-4ec2-a0a3-4455523c3611" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "667f8bd6-2e63-4d17-a16e-6cd0857843c1" },
                    { -3, "bertil@fakemail.net/picture3.jpg", null, "d77955c1-26d7-4bcc-89b2-c0810599414d" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -4, -3, "Because SQL is even worse.", "Entity Framework" },
                    { -1, -1, "What's hot right now?", "Trending" },
                    { -5, -1, "Planned occasions.", "Events" },
                    { -7, -1, "Backend news", "Backend" },
                    { -6, -4, "For random testing.", "User Group Test" },
                    { -8, -1, "News about frontend subjects", "Frontend" },
                    { -2, -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, -2, "The necessary evil?", "CSS" },
                    { -13, -7, "Where we can talk about anything.", "Random Talk" },
                    { -12, -7, "Computer games.", "Games" },
                    { -11, -6, "About developing this very forum.", "This Forum" },
                    { -10, -5, "A 3D computer graphics game engine developed by Epic Games.", "Unreal Engine" },
                    { -9, -1, "Other news", "Other" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId" },
                values: new object[] { -1, null, -4 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -2, "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "Site launch", -5, "Site-launch" },
                    { -5, "Site presentation", -5, "Site-presentation" },
                    { -7, "Say Hello Party", -5, "Say-Hello-Party" },
                    { -1, "HTML Tables?", -2, null },
                    { -3, "Am I'm the chosen one?", -3, null },
                    { -6, "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "UserId", "UserGroupId", "Id" },
                values: new object[,]
                {
                    { "b22c4502-8189-4ec2-a0a3-4455523c3611", -1, -1 },
                    { "d77955c1-26d7-4bcc-89b2-c0810599414d", -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "667f8bd6-2e63-4d17-a16e-6cd0857843c1", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 20, 22, 51, 59, 856, DateTimeKind.Local).AddTicks(8871), 1 },
                    { -2, "b22c4502-8189-4ec2-a0a3-4455523c3611", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 21, 22, 51, 59, 874, DateTimeKind.Local).AddTicks(5739), 0 },
                    { -7, "b22c4502-8189-4ec2-a0a3-4455523c3611", new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 15, 22, 51, 59, 874, DateTimeKind.Local).AddTicks(7318), 0 },
                    { -8, "b22c4502-8189-4ec2-a0a3-4455523c3611", new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 15, 22, 51, 59, 875, DateTimeKind.Local).AddTicks(1279), 0 },
                    { -11, "b22c4502-8189-4ec2-a0a3-4455523c3611", new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), 0, -7, "We will celebrate the completion of  our studies with a Say Hello Party on Tuesday 2022-08-23. We're starting a new category that we're naming Other. In that category, we create a topic that we call random talk. In that topic we start a 'Say Hello Party' subject. We will invite the students in the other groups to our forum. If they want, they can register and can contribute a hello in our 'Say Hello Party'.", new DateTime(2022, 8, 16, 22, 51, 59, 875, DateTimeKind.Local).AddTicks(1577), 0 },
                    { -3, "b22c4502-8189-4ec2-a0a3-4455523c3611", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 17, 22, 51, 59, 874, DateTimeKind.Local).AddTicks(6762), 3 },
                    { -4, "667f8bd6-2e63-4d17-a16e-6cd0857843c1", null, 1, -1, "I dont know..", new DateTime(2022, 8, 18, 22, 51, 59, 874, DateTimeKind.Local).AddTicks(6830), 0 },
                    { -5, "d77955c1-26d7-4bcc-89b2-c0810599414d", null, 0, -1, "Me neither..", new DateTime(2022, 8, 22, 19, 51, 59, 874, DateTimeKind.Local).AddTicks(6855), 1 },
                    { -6, "667f8bd6-2e63-4d17-a16e-6cd0857843c1", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 22, 22, 51, 59, 874, DateTimeKind.Local).AddTicks(7036), 1 },
                    { -9, "667f8bd6-2e63-4d17-a16e-6cd0857843c1", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 20, 22, 51, 59, 875, DateTimeKind.Local).AddTicks(1504), 0 },
                    { -10, "d77955c1-26d7-4bcc-89b2-c0810599414d", null, 0, -6, "Anything.", new DateTime(2022, 8, 21, 22, 51, 59, 875, DateTimeKind.Local).AddTicks(1545), 0 }
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
                name: "IX_ConversationParticipations_ConversationId",
                table: "ConversationParticipations",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages",
                column: "AuthorId");

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
                name: "IX_Subjects_TopicId",
                table: "Subjects",
                column: "TopicId");

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
                name: "ConversationParticipations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "UserGroupEnlistments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
