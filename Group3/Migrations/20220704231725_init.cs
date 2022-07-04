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
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Text = table.Column<string>(maxLength: 200, nullable: true)
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
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 10000, nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Text = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 10000, nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    TopicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
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
                    { "46831bbf-91d4-4c35-b1f8-2e103a1b9b0b", "fbc3ba79-b759-40b2-a086-87a4c6f0c61a", "Admin", "ADMIN" },
                    { "c543c2e9-e509-4db0-9f8e-21ac3799a454", "a254454f-cf46-4fa7-b7cd-f53e11f7f514", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "36a1aa80-9a59-4f5d-b713-1866f5062195", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "63af2d06-eb73-473b-ba61-9413349c3085", "admin@fakemail.net", false, "John", "Doe", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEK1g0o57EZgFuqroz811b+xbXyLKbkZ9K4GLfTNXirCgVpVSAuzzmPAwXZ3O+f0aHg==", null, false, "60cbf834-3eb2-478f-b3bf-488a3c4afe6c", false, "admin@fakemail.net" },
                    { "74909f9a-0dc9-4a9e-b5db-705d36e5e5da", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "4d49c617-0622-4218-9bdc-48a9d63b434e", "user@fakemail.net", false, "Johan", "Svensson", false, null, "USER@FAKEMAIL.NET", "USER@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEA8aHPfSENWysun7+4cGmBfbCCCvRGtq+80w5FbBkepnJ1vd3JY7jOozQWE0ipE+KA==", null, false, "bbf58871-4196-41e3-8a3c-8da9b887f120", false, "user@fakemail.net" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Text" },
                values: new object[,]
                {
                    { "ce4dc927-0b9f-4aa5-9873-c5777414800c", "Category 1", null },
                    { "12dc1c81-05d8-4add-bcd4-0c483f3ecdbb", "Category 2", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "36a1aa80-9a59-4f5d-b713-1866f5062195", "46831bbf-91d4-4c35-b1f8-2e103a1b9b0b" },
                    { "74909f9a-0dc9-4a9e-b5db-705d36e5e5da", "c543c2e9-e509-4db0-9f8e-21ac3799a454" }
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "ReceiverId", "Text", "Time", "UserId" },
                values: new object[,]
                {
                    { "4f39e550-dab6-4cbc-b2bf-6ad160808035", "74909f9a-0dc9-4a9e-b5db-705d36e5e5da", "Message 1", new DateTime(2022, 7, 2, 1, 17, 24, 830, DateTimeKind.Local).AddTicks(244), "36a1aa80-9a59-4f5d-b713-1866f5062195" },
                    { "10cfa12d-8cf7-442b-ae56-7e14be840c0f", "36a1aa80-9a59-4f5d-b713-1866f5062195", "Message 2", new DateTime(2022, 6, 26, 1, 17, 24, 830, DateTimeKind.Local).AddTicks(570), "74909f9a-0dc9-4a9e-b5db-705d36e5e5da" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CategoryId", "Name", "Text", "UserId" },
                values: new object[,]
                {
                    { "7da41190-bf6d-46e9-8656-1252feff8385", "ce4dc927-0b9f-4aa5-9873-c5777414800c", "Topic 2", null, "36a1aa80-9a59-4f5d-b713-1866f5062195" },
                    { "76e729aa-7b1c-4a6a-bbde-c748a3742a24", "12dc1c81-05d8-4add-bcd4-0c483f3ecdbb", "Topic 1", null, "74909f9a-0dc9-4a9e-b5db-705d36e5e5da" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Text", "Time", "TopicId", "UserId" },
                values: new object[] { "c099c586-a5c3-4578-93a5-cce0e30b1125", "Test in post 1", new DateTime(2022, 7, 4, 1, 17, 24, 827, DateTimeKind.Local).AddTicks(6667), "7da41190-bf6d-46e9-8656-1252feff8385", "74909f9a-0dc9-4a9e-b5db-705d36e5e5da" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Text", "Time", "TopicId", "UserId" },
                values: new object[] { "4316bcbe-ad6a-4cfe-9697-f5987a72e79f", "Text in post 2", new DateTime(2022, 7, 3, 1, 17, 24, 829, DateTimeKind.Local).AddTicks(8918), "76e729aa-7b1c-4a6a-bbde-c748a3742a24", "36a1aa80-9a59-4f5d-b713-1866f5062195" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Text", "Time", "TopicId", "UserId" },
                values: new object[] { "4f330921-d9a1-4f03-9084-467d23fd700f", "Text in post 3", new DateTime(2022, 6, 30, 1, 17, 24, 829, DateTimeKind.Local).AddTicks(8984), "76e729aa-7b1c-4a6a-bbde-c748a3742a24", "36a1aa80-9a59-4f5d-b713-1866f5062195" });

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
                name: "IX_Message_ReceiverId",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CategoryId",
                table: "Topics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");
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
                name: "Message");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
