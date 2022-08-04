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
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
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
                    ReferenceId = table.Column<int>(nullable: true)
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
                        name: "FK_Posts_Posts_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "Posts",
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
                    { "b8e195ef-24fb-4304-a9b8-f333bc0a49f7", "8ddc35d9-8f8b-4e91-a942-99c34ec34154", "Admin", "ADMIN" },
                    { "aa95fe5d-440d-4a4a-b910-676f6e1ea3a8", "66759ddf-307c-403e-adbb-4bc1172ae7d1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "a9f4cf9b-00bc-4bba-b96b-ad0091a56c37", "admin@fakemail.net", false, "John", "Doe", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAECcgus/MbC2eqTBXzgFuGTdicg9v9iebBBySfLARZTq9Fr3YRP4mldT1PYym+TdPTg==", null, false, "49240cbf-a7d9-450c-9010-9f281322b380", false, "admin@fakemail.net" },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "8547437e-bbd3-4884-8465-c3245d703ac0", "sara@fakemail.net", false, "Sara", "Svensson", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEPrE7BR9n0rIxPSbtKffaf44ekfAOYYzrRGNE+HmHdPPHfsSTUzKzo7PGpbkmgganQ==", null, false, "6410fcd7-3fa3-4e0e-b54c-29d344461e55", false, "sara@fakemail.net" },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "c524d543-9cf3-41b3-ae5e-4baff74fe64f", "bertil@fakemail.net", false, "Bertil", "Johansson", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEDhm7IAnKAV0KZSiys4f7RLljh/a6KmIDS+wDx5yKz+9mXruOapiqHX6jRwv6gpJJw==", null, false, "349a6461-8965-4dbb-a398-7f0a84c505e4", false, "bertil@fakemail.net" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { -1, null, "News" },
                    { -2, null, "Frontend" },
                    { -3, null, "Backend" },
                    { -4, null, "Random" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", "b8e195ef-24fb-4304-a9b8-f333bc0a49f7" },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", "aa95fe5d-440d-4a4a-b910-676f6e1ea3a8" },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", "aa95fe5d-440d-4a4a-b910-676f6e1ea3a8" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 1, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(7123) },
                    { -4, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", "Umm..", new DateTime(2022, 8, 3, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(7600) },
                    { -2, "871408aa-5382-4e3c-a6d0-66017d087c00", "Hello John!", new DateTime(2022, 8, 2, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(7569) },
                    { -3, "cc194169-e1f2-48f9-8670-eba74673ba60", "What's up??", new DateTime(2022, 8, 3, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(7596) },
                    { -5, "cc194169-e1f2-48f9-8670-eba74673ba60", "Message from Bertil to Sara", new DateTime(2022, 8, 3, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(7602) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -1, "admin@fakemail.net/picture1.jpg", null, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "871408aa-5382-4e3c-a6d0-66017d087c00" },
                    { -5, "bertil@fakemail.net/picture5.jpg", null, "cc194169-e1f2-48f9-8670-eba74673ba60" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -1, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", -1, "Upgrade your project to 6.0", "Trending" },
                    { -2, "871408aa-5382-4e3c-a6d0-66017d087c00", -2, "What ever about HTML", "HTML" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", -1, -1 },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", -5, -3 },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", -5, -3 },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", -3, -2 },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", -3, -2 },
                    { "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", -3, -2 },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", -2, -1 },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", -2, -1 },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", -4, -2 },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", -4, -2 },
                    { "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", -4, -2 },
                    { "cc194169-e1f2-48f9-8670-eba74673ba60", -1, -1 },
                    { "871408aa-5382-4e3c-a6d0-66017d087c00", -1, -1 },
                    { "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "ReferenceId", "Text", "Time", "TopicId" },
                values: new object[,]
                {
                    { -2, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", null, "My head is empty, should I fill it with something?", new DateTime(2022, 8, 2, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(5405), -2 },
                    { -1, "871408aa-5382-4e3c-a6d0-66017d087c00", null, "<b>Visual Studio 6.0</b> news news news more news", new DateTime(2022, 8, 3, 14, 40, 40, 944, DateTimeKind.Local).AddTicks(4074), -1 },
                    { -3, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", null, "HoW do I make a table?", new DateTime(2022, 7, 30, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(5486), -2 }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[] { -3, "admin@fakemail.net/picture3.jpg", -1, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4" });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[] { -4, "sara@fakemail.net/picture4.jpg", -2, "871408aa-5382-4e3c-a6d0-66017d087c00" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "ReferenceId", "Text", "Time", "TopicId" },
                values: new object[] { -4, "1ddfc41a-8b0e-4dbd-8ef5-f94a552838d4", -3, "I dont know", new DateTime(2022, 7, 31, 14, 40, 40, 946, DateTimeKind.Local).AddTicks(5492), -2 });

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
                name: "IX_Posts_ReferenceId",
                table: "Posts",
                column: "ReferenceId");

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
