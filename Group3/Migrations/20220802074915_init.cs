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
                    TopicId = table.Column<int>(nullable: false)
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
                    { "c4db8954-4ef2-4925-bc85-cc1b9368c0f1", "05c3564e-0f2f-43b0-b4ee-0cc8f4567ee2", "Admin", "ADMIN" },
                    { "87f9f677-3346-412c-8497-ca9e2aa70806", "db5db423-d02d-4c20-9c96-5a4a6b48d3c2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9618b24c-c9dd-458a-9160-cb222bc8fd29", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "9c66dc33-62b7-4f53-b770-8272f61111f7", "admin@fakemail.net", false, "John", "Doe", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEK/j70VbSE8CV0V4r5DdLZei5RmyeJwKPr5chDwSx4qyBxlUDZopzaGiTSfmVisC+g==", null, false, "2d34da9d-e054-4073-b7ef-68cb4643cd59", false, "admin@fakemail.net" },
                    { "40574de4-256f-4172-a60f-c46738c57554", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "04611645-f52c-4f97-949d-77f82bb68003", "sara@fakemail.net", false, "Sara", "Svensson", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAED1ZSxmYT/BG8FTYTfBdU5N02SVbHlnT7hbq9dDPuh4f34DP2HkzXJlA+64ifwXL/g==", null, false, "63d965b1-acf9-402e-8352-900843611a37", false, "sara@fakemail.net" },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "4803c717-5243-4cea-899e-ceffe35a4e25", "bertil@fakemail.net", false, "Bertil", "Johansson", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEFZyCMmiJZVDrC5DLYCNE+nH6URlix0I5AHqTvpWU7Ujw9LfPSuk2sIu+hnwGXpMTQ==", null, false, "4cfebd8c-5d5a-4b22-9717-cf6485a91d70", false, "bertil@fakemail.net" }
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
                    { "9618b24c-c9dd-458a-9160-cb222bc8fd29", "c4db8954-4ef2-4925-bc85-cc1b9368c0f1" },
                    { "40574de4-256f-4172-a60f-c46738c57554", "87f9f677-3346-412c-8497-ca9e2aa70806" },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", "87f9f677-3346-412c-8497-ca9e2aa70806" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "9618b24c-c9dd-458a-9160-cb222bc8fd29", "Hello Sara and Bertil my name is John!", new DateTime(2022, 7, 30, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(2808) },
                    { -4, "9618b24c-c9dd-458a-9160-cb222bc8fd29", "Umm..", new DateTime(2022, 8, 1, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(3671) },
                    { -2, "40574de4-256f-4172-a60f-c46738c57554", "Hello John!", new DateTime(2022, 7, 31, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(3638) },
                    { -3, "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", "What's up??", new DateTime(2022, 8, 1, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(3667) },
                    { -5, "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", "Message from Bertil to Sara", new DateTime(2022, 8, 1, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(3675) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -1, "Pictures/admin@fakemail.net/picture1.jpg", null, "9618b24c-c9dd-458a-9160-cb222bc8fd29" },
                    { -2, "Pictures/sara@fakemail.net/abc.jpg", null, "40574de4-256f-4172-a60f-c46738c57554" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -1, "9618b24c-c9dd-458a-9160-cb222bc8fd29", -1, "Upgrade your project to 6.0", "Trending" },
                    { -2, "40574de4-256f-4172-a60f-c46738c57554", -2, "What ever about HTML", "HTML" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "9618b24c-c9dd-458a-9160-cb222bc8fd29", -1, -1 },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", -5, -3 },
                    { "40574de4-256f-4172-a60f-c46738c57554", -5, -3 },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", -3, -2 },
                    { "40574de4-256f-4172-a60f-c46738c57554", -3, -2 },
                    { "9618b24c-c9dd-458a-9160-cb222bc8fd29", -3, -2 },
                    { "40574de4-256f-4172-a60f-c46738c57554", -2, -1 },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", -2, -1 },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", -4, -2 },
                    { "40574de4-256f-4172-a60f-c46738c57554", -4, -2 },
                    { "9618b24c-c9dd-458a-9160-cb222bc8fd29", -4, -2 },
                    { "918a1403-62dd-49b4-b2ae-b481f2e6ccc9", -1, -1 },
                    { "40574de4-256f-4172-a60f-c46738c57554", -1, -1 },
                    { "9618b24c-c9dd-458a-9160-cb222bc8fd29", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "Text", "Time", "TopicId" },
                values: new object[,]
                {
                    { -2, "9618b24c-c9dd-458a-9160-cb222bc8fd29", "My head is empty, should I fill it with something?", new DateTime(2022, 7, 31, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(228), -2 },
                    { -1, "40574de4-256f-4172-a60f-c46738c57554", "<b>Visual Studio 6.0</b> news news news more news", new DateTime(2022, 8, 1, 9, 49, 14, 965, DateTimeKind.Local).AddTicks(8374), -1 },
                    { -3, "9618b24c-c9dd-458a-9160-cb222bc8fd29", "HoW do I make a table?", new DateTime(2022, 7, 28, 9, 49, 14, 968, DateTimeKind.Local).AddTicks(292), -2 }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[] { -3, "Pictures/admin@fakemail.net/postPic1.jpg", -1, "9618b24c-c9dd-458a-9160-cb222bc8fd29" });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[] { -4, "Pictures/sara@fakemail.net/postPic2.jpg", -2, "40574de4-256f-4172-a60f-c46738c57554" });

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
