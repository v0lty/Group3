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
                    Birthdate = table.Column<DateTime>(nullable: false)
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
                    Description = table.Column<string>(maxLength: 200, nullable: true)
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
                name: "Chats",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AurthorId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 10000, nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    TopicId = table.Column<int>(nullable: false),
                    Reports = table.Column<int>(nullable: false),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AurthorId",
                        column: x => x.AurthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ba57f22-cadf-42e1-9aca-f7aa4eb1d145", "679856e9-85a8-4122-abc1-ad4bcb988676", "Admin", "ADMIN" },
                    { "6de84da1-d6fd-4f17-84a0-39d098eeac43", "b3ea367a-a484-4a53-ab48-3c3af6627b02", "User", "USER" },
                    { "87b24ab2-7440-48f1-b18b-d51453cde95e", "b4ecfbe7-1ab0-41e2-bd82-4628decd23a5", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "f81759a6-4263-4da5-9e80-fffca2051e41", "admin@fakemail.net", false, "John", "Doe", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEF3rkHL/9ULWZXFSm/HCsZrE6cm1fS50GYJyaSvBh49YOVwUgvAnxjenCik3TolzIQ==", null, false, "2d8464dd-4724-413a-bac8-74d4547473f9", false, "admin@fakemail.net" },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "58039ac2-4d04-496c-a099-e0609a6bf54d", "sara@fakemail.net", false, "Sara", "Svensson", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAECNZ+a1quVGXJ0X87/9mTtFnpt6AOYEUw6z7O0Bv9GDanLzGguPgE25MkUkkzVqayQ==", null, false, "ff6dd937-b3b6-4a3c-9514-0c3a59337895", false, "sara@fakemail.net" },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "4bff0ade-5250-4f37-b101-be540ede5234", "bertil@fakemail.net", false, "Bertil", "Johansson", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEGH1+8uiId5vn5A4FpPWUlF9xR8eVu8HCLlPtmBCeQqOwjfGfqIxSUHWHalLuYO7uA==", null, false, "4b241ebf-c679-4003-8bf8-bfefe3bffe37", false, "bertil@fakemail.net" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { -1, "Breaking news here!", "News" },
                    { -2, "Javascript, React and more.", "Frontend" },
                    { -3, "C++ and C#", "Backend" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", "3ba57f22-cadf-42e1-9aca-f7aa4eb1d145" },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", "6de84da1-d6fd-4f17-84a0-39d098eeac43" },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", "87b24ab2-7440-48f1-b18b-d51453cde95e" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 2, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(8149) },
                    { -4, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", "Umm..", new DateTime(2022, 8, 4, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9074) },
                    { -2, "4c9712e9-1359-439a-b161-e4f4d5047148", "Hello John!", new DateTime(2022, 8, 3, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9041) },
                    { -3, "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", "What's up??", new DateTime(2022, 8, 4, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9070) },
                    { -5, "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", "Message from Bertil to Sara", new DateTime(2022, 8, 4, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(9078) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -1, "admin@fakemail.net/picture1.jpg", null, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "4c9712e9-1359-439a-b161-e4f4d5047148" },
                    { -3, "admin@fakemail.net/picture3.jpg", null, "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { -1, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -1, "Trending" },
                    { -2, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -2, "HTML" },
                    { -3, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -2, "CSS" },
                    { -4, "4c9712e9-1359-439a-b161-e4f4d5047148", -3, "Entity Framework" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -1, -1 },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", -5, -3 },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", -5, -3 },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", -3, -2 },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", -3, -2 },
                    { "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -3, -2 },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", -2, -1 },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", -2, -1 },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", -4, -2 },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", -4, -2 },
                    { "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -4, -2 },
                    { "bd6d91b2-9082-4ac6-b69c-57c4b48bef6b", -1, -1 },
                    { "4c9712e9-1359-439a-b161-e4f4d5047148", -1, -1 },
                    { "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "Reports", "Text", "Time", "TopicId", "Votes" },
                values: new object[,]
                {
                    { -3, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", 0, "How do I make a table?", new DateTime(2022, 7, 31, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(5887), -2, 3 },
                    { -1, "4c9712e9-1359-439a-b161-e4f4d5047148", 0, "<b>Visual Studio 6.0</b> news news news more news", new DateTime(2022, 8, 4, 13, 8, 31, 847, DateTimeKind.Local).AddTicks(669), -1, 1 },
                    { -2, "3ead9f54-2b0e-44fb-b5f5-6fcf1bf1b4b6", 2, "My head is empty, should I fill it with something?", new DateTime(2022, 8, 3, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(5783), -1, 0 },
                    { -4, "4c9712e9-1359-439a-b161-e4f4d5047148", 1, "I dont know..", new DateTime(2022, 8, 1, 13, 8, 31, 849, DateTimeKind.Local).AddTicks(5896), -2, 0 }
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
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_AurthorId",
                table: "Topics",
                column: "AurthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CategoryId",
                table: "Topics",
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
