using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Group3.Migrations
{
    public partial class initial : Migration
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
                    { "912e479a-ff0c-44d6-94b0-7a60bb1222d9", "27a9eb76-2845-4306-bfa0-57bb11d27313", "Admin", "ADMIN" },
                    { "2b636dfe-eee6-4bc4-aa2b-33e90d844af9", "06bc8ecb-0c65-44c7-a04f-0c408adc60de", "User", "USER" },
                    { "062a6179-e962-4f2f-9cf6-0c477b6aa48c", "5af4034c-c825-467e-abea-b1a0559d43a2", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0e59cc11-346c-42fa-ade9-eefbb4140ee8", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEJaKlNapRWOZj4uaZlvmI24v7jxEeui1aCn+dz8RbBm5fRm+uJgS+5otB4QEBSl2rg==", null, false, "79c87b2f-f0a9-4248-b510-13359b71f1c2", false, "admin@fakemail.net" },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "bf07465e-55a5-4132-ae93-6b640362d9fd", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEF86L6OMZSNSsCVnwpUfqfHXgGVc3Ka1/4pYgkPB2Xy+YoMFmM8beRelSQx3rvHyLg==", null, false, "ba1e5d0c-1e37-4ffb-b94f-95e9549b23a9", false, "sara@fakemail.net" },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9d391eb6-04bf-4c09-91df-8da843419cdb", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEMlmF3q4kt1tc1P8yw2C54/o2X7CK9SgPJYxZcHpYeGDXpX2qcvV78frAyy4EPFYZQ==", null, false, "6e82dd3b-1791-4c78-9610-bd53930e1147", false, "bertil@fakemail.net" }
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
                    { "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", "912e479a-ff0c-44d6-94b0-7a60bb1222d9" },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", "2b636dfe-eee6-4bc4-aa2b-33e90d844af9" },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", "062a6179-e962-4f2f-9cf6-0c477b6aa48c" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 13, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(9144) },
                    { -4, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", "Umm..", new DateTime(2022, 8, 15, 14, 26, 51, 654, DateTimeKind.Local).AddTicks(2) },
                    { -5, "97d61949-d788-40fd-9955-61a00d763f6f", "Message from Bertil to Sara", new DateTime(2022, 8, 15, 14, 26, 51, 654, DateTimeKind.Local).AddTicks(34) },
                    { -2, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", "Hello John!", new DateTime(2022, 8, 14, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(9969) },
                    { -3, "97d61949-d788-40fd-9955-61a00d763f6f", "What's up??", new DateTime(2022, 8, 15, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(9998) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -3, "admin@fakemail.net/picture3.jpg", null, "97d61949-d788-40fd-9955-61a00d763f6f" },
                    { -1, "admin@fakemail.net/picture1.jpg", null, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -1, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -1, "What's hot right now?", "Trending" },
                    { -5, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -1, "Planned occasions.", "Events" },
                    { -7, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -1, "Backend news", "Backend" },
                    { -8, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -1, "News about frontend subjects", "Frontend" },
                    { -9, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -1, "Other news", "Other" },
                    { -2, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -2, "The necessary evil?", "CSS" },
                    { -4, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -3, "Because SQL is even worse.", "Entity Framework" },
                    { -6, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -4, "For random testing.", "User Group Test" }
                });

            migrationBuilder.InsertData(
                table: "UserGroupEnlistments",
                columns: new[] { "ApplicationUserID", "CategoryId", "UserGroupEnlistmentID" },
                values: new object[,]
                {
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -4, -1 },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", -4, -2 }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -1, -1 },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", -5, -3 },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -5, -3 },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", -3, -2 },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -3, -2 },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", -2, -1 },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -2, -1 },
                    { "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -3, -2 },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", -4, -2 },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -4, -2 },
                    { "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -4, -2 },
                    { "97d61949-d788-40fd-9955-61a00d763f6f", -1, -1 },
                    { "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", -1, -1 },
                    { "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AurthorId", "Name", "TopicId", "UrlSlug" },
                values: new object[,]
                {
                    { -3, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", "Am I'm the chosen one?", -3, null },
                    { -2, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", "Visual Studio 2022", -1, "Visual-Studio-2022" },
                    { -4, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", "Site launch", -5, "Site-launch" },
                    { -5, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", "Site presentation", -5, "Site-presentation" },
                    { -1, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", "HTML Tables?", -2, null },
                    { -6, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", "What?.", -6, null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "EventDate", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", null, 0, -2, "Is this version any good?", new DateTime(2022, 8, 14, 14, 26, 51, 651, DateTimeKind.Local).AddTicks(3578), 1 },
                    { -2, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", null, 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 15, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(6497), 0 },
                    { -7, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), 0, -4, "Site launch.<br><br>Day for site launch. We will see if it is possible to host the site on freeasphosting.net", new DateTime(2022, 8, 9, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(6643), 0 },
                    { -8, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), 0, -5, "Site presentation.<br><br>Day for presentation. Our project was to create a community portal for an organization, including a news feed, events, member lists and discussion forums. ", new DateTime(2022, 8, 9, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(7077), 0 },
                    { -3, "c5c9241b-7440-4b2d-9aca-777ab5e59ca3", null, 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 11, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(6576), 3 },
                    { -4, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", null, 1, -1, "I dont know..", new DateTime(2022, 8, 12, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(6583), 0 },
                    { -5, "97d61949-d788-40fd-9955-61a00d763f6f", null, 0, -1, "Me neither..", new DateTime(2022, 8, 16, 11, 26, 51, 653, DateTimeKind.Local).AddTicks(6587), 1 },
                    { -6, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", null, 0, -3, "WoW first post?!?", new DateTime(2019, 8, 16, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(6609), 1 },
                    { -9, "2c1e8c24-8b06-481a-bb5d-2309bc40fb3a", null, 0, -6, "What should we talk about in our user group test forum?", new DateTime(2022, 8, 14, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(7127), 0 },
                    { -10, "97d61949-d788-40fd-9955-61a00d763f6f", null, 0, -6, "Anything.", new DateTime(2022, 8, 15, 14, 26, 51, 653, DateTimeKind.Local).AddTicks(7133), 0 }
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
