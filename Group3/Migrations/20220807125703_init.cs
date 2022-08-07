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
                    { "fcb2afa4-c8ec-408c-8c08-cf34234493bf", "fbd11b6d-b810-40c6-83c1-62039de7d3a9", "Admin", "ADMIN" },
                    { "ca6897bb-6983-49a9-8a69-90010f20cbbd", "63a6ceaa-bcfd-44c7-ad10-c2c155906644", "User", "USER" },
                    { "5fcab190-8e3b-4b61-bf58-34c03c25d81d", "93211696-c581-423b-8835-c5a021c3edc9", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "141b2307-27c7-4a38-9ad7-4183d4343876", 0, new DateTime(1964, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5eea05f-6b15-4a4b-9d7b-30a4f7df9070", "admin@fakemail.net", false, "John", "Doe", "America", false, null, "ADMIN@FAKEMAIL.NET", "ADMIN@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEBndc1Qn+FmMwX6ruOoO/wsdjUfCSScVJfbmMZuZ5/w4R2mtJS9sjIaiHchT70K9ww==", null, false, "a5e2aca8-8b4b-49fd-a027-b0737243dfaa", false, "admin@fakemail.net" },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", 0, new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "42f6f609-ee26-4613-883c-f114673cd1a8", "sara@fakemail.net", false, "Sara", "Svensson", "Danmark", false, null, "SARA@FAKEMAIL.NET", "SARA@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEDTxnaJ+wO0hEesPPSNg2mlBF942Xi0hzq99eFGgM8x8f2dLnrAsN+aJMdmraKwTPQ==", null, false, "70f02e1e-6222-43b2-8589-1136479fd210", false, "sara@fakemail.net" },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", 0, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "74df0717-dbec-499b-a0e3-0f0bed01966f", "bertil@fakemail.net", false, "Bertil", "Johansson", "Sweden", false, null, "BERTIL@FAKEMAIL.NET", "BERTIL@FAKEMAIL.NET", "AQAAAAEAACcQAAAAEPUESof0nvYGDXSkOR2e+lAWGaFbJUvVTs+uRIkSJrB+VY7DUEkMgF1VADCjf4iHGA==", null, false, "e2d93a2c-0989-4c2d-882a-40f0ec3cf45c", false, "bertil@fakemail.net" }
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
                    { "141b2307-27c7-4a38-9ad7-4183d4343876", "fcb2afa4-c8ec-408c-8c08-cf34234493bf" },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", "ca6897bb-6983-49a9-8a69-90010f20cbbd" },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", "5fcab190-8e3b-4b61-bf58-34c03c25d81d" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AurthorId", "Text", "Time" },
                values: new object[,]
                {
                    { -1, "141b2307-27c7-4a38-9ad7-4183d4343876", "Hello Sara and Bertil my name is John!", new DateTime(2022, 8, 4, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(6373) },
                    { -4, "141b2307-27c7-4a38-9ad7-4183d4343876", "Umm..", new DateTime(2022, 8, 6, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(7198) },
                    { -2, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", "Hello John!", new DateTime(2022, 8, 5, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(7165) },
                    { -3, "04363ba0-d213-4e19-a0d2-d38cc893af3b", "What's up??", new DateTime(2022, 8, 6, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(7193) },
                    { -5, "04363ba0-d213-4e19-a0d2-d38cc893af3b", "Message from Bertil to Sara", new DateTime(2022, 8, 6, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(7202) }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { -1, "admin@fakemail.net/picture1.jpg", null, "141b2307-27c7-4a38-9ad7-4183d4343876" },
                    { -2, "sara@fakemail.net/picture2.jpg", null, "da3a4e5f-558b-4580-bc65-ff951c1c5d33" },
                    { -3, "admin@fakemail.net/picture3.jpg", null, "04363ba0-d213-4e19-a0d2-d38cc893af3b" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "AurthorId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { -1, "141b2307-27c7-4a38-9ad7-4183d4343876", -1, "What's hot right now?", "Trending" },
                    { -2, "141b2307-27c7-4a38-9ad7-4183d4343876", -2, "Tag TAG <b>TAG!</b>", "HTML" },
                    { -3, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -2, "The necessary evil?", "CSS" },
                    { -4, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -3, "Because SQL is even worse.", "Entity Framework" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserId", "MessageId", "Id" },
                values: new object[,]
                {
                    { "141b2307-27c7-4a38-9ad7-4183d4343876", -1, -1 },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", -5, -3 },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -5, -3 },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", -3, -2 },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -3, -2 },
                    { "141b2307-27c7-4a38-9ad7-4183d4343876", -3, -2 },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -2, -1 },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", -2, -1 },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", -4, -2 },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -4, -2 },
                    { "141b2307-27c7-4a38-9ad7-4183d4343876", -4, -2 },
                    { "04363ba0-d213-4e19-a0d2-d38cc893af3b", -1, -1 },
                    { "da3a4e5f-558b-4580-bc65-ff951c1c5d33", -1, -1 },
                    { "141b2307-27c7-4a38-9ad7-4183d4343876", -2, -1 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AurthorId", "Name", "TopicId" },
                values: new object[,]
                {
                    { -1, "141b2307-27c7-4a38-9ad7-4183d4343876", "HTML Tables?", -2 },
                    { -2, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", "Visual Studio 2022", -1 },
                    { -3, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", "Am I'm the chosen one?", -3 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AurthorId", "Reports", "SubjectId", "Text", "Time", "Votes" },
                values: new object[,]
                {
                    { -1, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", 0, -2, "Is this version any good?", new DateTime(2022, 8, 5, 14, 57, 2, 629, DateTimeKind.Local).AddTicks(2997), 1 },
                    { -2, "141b2307-27c7-4a38-9ad7-4183d4343876", 2, -2, "Maybe, but I'll stick with 2019!", new DateTime(2022, 8, 6, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(4359), 0 },
                    { -3, "141b2307-27c7-4a38-9ad7-4183d4343876", 0, -1, "How do I make a <b>table?</b>", new DateTime(2022, 8, 2, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(4429), 3 },
                    { -4, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", 1, -1, "I dont know..", new DateTime(2022, 8, 3, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(4436), 0 },
                    { -5, "04363ba0-d213-4e19-a0d2-d38cc893af3b", 0, -1, "Me neither..", new DateTime(2022, 8, 7, 11, 57, 2, 631, DateTimeKind.Local).AddTicks(4440), 1 },
                    { -6, "da3a4e5f-558b-4580-bc65-ff951c1c5d33", 0, -3, "WoW first post?!?", new DateTime(2019, 8, 7, 14, 57, 2, 631, DateTimeKind.Local).AddTicks(4460), 1 }
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
