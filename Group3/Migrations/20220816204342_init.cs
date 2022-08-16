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
                    { "fb84d6f4-7126-41b5-9278-a375210f6ead", "5fe57383-3d90-4564-a2a6-6e3a6e964dae", "Admin", "ADMIN" },
                    { "829110b9-32d1-4007-ba22-040555b2172c", "257c3037-750c-4e99-9dbf-125bab989065", "User", "USER" },
                    { "0eefc918-792b-4d44-a3d6-e63b1cd92baf", "56ebf87d-5645-4ee2-9b04-4bc9ddd9b608", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "309a8b3b-c944-4288-9d9c-3660e1f96e1c", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEE1NNJKF+7MGYPXoahpdZXZcEijdeRPCQwTfly9kpRW7SCyj3eRTddeqq9pPF6RIKQ==", null, false, "80dc67b2-ac6d-468f-995b-cb358b9e1edb", false, "admin@fakemail.net" },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "35810d4b-0e10-428f-96cf-22111a4a80c0", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEFGCUbep0ggRZx+AIF+/qed5xJ74JDXZorkaN2nM6IPZw1LiL9a6wTxbgJCqb94V1A==", null, false, "4e45acf1-b71c-4646-8f7d-fcfdab60d6f8", false, "sara@fakemail.net" },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "4ab058d8-714a-4fc2-b472-2eedc7f420f6", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAECL7zj7XdnIuwAaMPR2+o18R3lvIe6mXw4SznQnK6m1Q0NsdqaG+URIhR97DScnp1g==", null, false, "0ece69e6-271b-4a7a-a8c0-f889a7287986", false, "bertil@fakemail.net" }
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
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", "fb84d6f4-7126-41b5-9278-a375210f6ead" },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", "829110b9-32d1-4007-ba22-040555b2172c" },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", "0eefc918-792b-4d44-a3d6-e63b1cd92baf" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 13, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(8057) },
                    { -4, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", "Umm..", new DateTime(2022, 8, 15, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(8880) },
                    { -5, "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", "Message from Bertil to Sara", new DateTime(2022, 8, 15, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(8931) },
                    { -2, "672a5735-5dc8-4358-bbe7-cde61342ac77", "Hello John!", new DateTime(2022, 8, 14, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(8849) },
                    { -3, "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", "What's up??", new DateTime(2022, 8, 15, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(8876) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -3, "admin@fakemail.net/picture3.jpg", null, "e3d24956-8ef9-4458-b24a-f025ec4ecc5b" },
                    { -1, "admin@fakemail.net/picture1.jpg", null, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "672a5735-5dc8-4358-bbe7-cde61342ac77" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -6, "672a5735-5dc8-4358-bbe7-cde61342ac77", -4, "For random testing.", "User Group Test" },
                    { -1, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, "What's hot right now?", "Trending" },
                    { -5, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, "Planned occasions.", "Events" },
                    { -7, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, "Backend news", "Backend" },
                    { -8, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, "News about frontend subjects", "Frontend" },
                    { -9, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, "Other news", "Other" },
                    { -2, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "672a5735-5dc8-4358-bbe7-cde61342ac77", -2, "The necessary evil?", "CSS" },
                    { -4, "672a5735-5dc8-4358-bbe7-cde61342ac77", -3, "Because SQL is even worse.", "Entity Framework" }
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
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, -1 },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", -5, -3 },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", -5, -3 },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", -3, -2 },
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -3, -2 },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", -2, -1 },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", -2, -1 },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", -3, -2 },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", -4, -2 },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", -4, -2 },
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -4, -2 },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", -1, -1 },
                    { "672a5735-5dc8-4358-bbe7-cde61342ac77", -1, -1 },
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AurthorId", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -2, "672a5735-5dc8-4358-bbe7-cde61342ac77", "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", "Site launch", -5, "Site-launch" },
                    { -5, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", "Site presentation", -5, "Site-presentation" },
                    { -1, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", "HTML Tables?", -2, null },
                    { -3, "672a5735-5dc8-4358-bbe7-cde61342ac77", "Am I'm the chosen one?", -3, null },
                    { -6, "672a5735-5dc8-4358-bbe7-cde61342ac77", "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "UserId", "UserGroupId", "Id" },
                values: new object[,]
                {
                    { "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", -1, -1 },
                    { "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "672a5735-5dc8-4358-bbe7-cde61342ac77", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 14, 22, 43, 42, 294, DateTimeKind.Local).AddTicks(3371), 1 },
                    { -2, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 15, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(5577), 0 },
                    { -7, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Site launch.<br><br>Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 9, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(5716), 0 },
                    { -8, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Site presentation.<br><br>Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 9, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(6148), 0 },
                    { -3, "f040d695-ecc6-4f1c-ab6e-6b2507b41f6c", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 11, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(5654), 3 },
                    { -4, "672a5735-5dc8-4358-bbe7-cde61342ac77", null, 1, -1, "I dont know..", new DateTime(2022, 8, 12, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(5660), 0 },
                    { -5, "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", null, 0, -1, "Me neither..", new DateTime(2022, 8, 16, 19, 43, 42, 296, DateTimeKind.Local).AddTicks(5664), 1 },
                    { -6, "672a5735-5dc8-4358-bbe7-cde61342ac77", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 16, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(5685), 1 },
                    { -9, "672a5735-5dc8-4358-bbe7-cde61342ac77", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 14, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(6178), 0 },
                    { -10, "e3d24956-8ef9-4458-b24a-f025ec4ecc5b", null, 0, -6, "Anything.", new DateTime(2022, 8, 15, 22, 43, 42, 296, DateTimeKind.Local).AddTicks(6182), 0 }
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
