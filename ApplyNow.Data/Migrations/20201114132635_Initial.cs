using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplyNow.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnnouncementId = table.Column<int>(nullable: false),
                    ResumeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applys_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applys_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Department = table.Column<string>(maxLength: 200, nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    ResumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    ResumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Ankara/Türkiye", "Company X" },
                    { 2, "İstanbul/Türkiye", "Company Y" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "user1@xyz.com", "123", "user1" },
                    { 2, "user2@xyz.com", "123", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "Description", "EndDate", "Location" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 11, 4, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(8060), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", new DateTime(2020, 11, 16, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(8410), "İstanbul" },
                    { 2, 2, new DateTime(2020, 11, 4, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(9000), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", new DateTime(2020, 11, 14, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(9010), "İzmir" }
                });

            migrationBuilder.InsertData(
                table: "Resumes",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Title", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 14, 16, 26, 34, 753, DateTimeKind.Local).AddTicks(7850), false, "Yazılım Uzmanı", null, 1 },
                    { 2, new DateTime(2020, 11, 14, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(1050), false, "Avukat", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Department", "EndDate", "Name", "ResumeId" },
                values: new object[,]
                {
                    { 1, "Bilgisayar Mühendisliği", "2014", "İstanbul Teknik Ünversitesi", 1 },
                    { 2, "Bilgisayar Programcılığı", "2009", "İstanbul Lisesi", 1 },
                    { 3, "Hukuk Fakültesi", "2020", "Yıldız Teknik Üniversitesi", 2 },
                    { 4, "Fen Bilimleri", "2014", "Ankara Lisesi", 2 }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CompanyName", "EndDate", "ResumeId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "X Firma", "2015", 1, "2012", "Yazılım Mühendisliği" },
                    { 2, "Y Firma", "2017", 2, "2009", "Avukat" },
                    { 3, "Z Firma", "2009", 2, "2002", "Danışman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CompanyId",
                table: "Announcements",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applys_AnnouncementId",
                table: "Applys",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Applys_ResumeId",
                table: "Applys",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeId",
                table: "Educations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ResumeId",
                table: "Experiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UserId",
                table: "Resumes",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applys");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
