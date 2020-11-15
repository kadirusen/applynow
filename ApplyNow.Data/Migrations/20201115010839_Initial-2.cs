using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplyNow.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applys_Announcements_AnnouncementId",
                table: "Applys");

            migrationBuilder.DropForeignKey(
                name: "FK_Applys_Resumes_ResumeId",
                table: "Applys");

            migrationBuilder.DropIndex(
                name: "IX_Applys_AnnouncementId",
                table: "Applys");

            migrationBuilder.DropIndex(
                name: "IX_Applys_ResumeId",
                table: "Applys");

            migrationBuilder.AddColumn<int>(
                name: "ApplyId",
                table: "Resumes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplyId",
                table: "Announcements",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate" },
                values: new object[] { new DateTime(2020, 11, 5, 4, 8, 39, 185, DateTimeKind.Local).AddTicks(2660), new DateTime(2020, 11, 17, 4, 8, 39, 185, DateTimeKind.Local).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate" },
                values: new object[] { new DateTime(2020, 11, 5, 4, 8, 39, 185, DateTimeKind.Local).AddTicks(3610), new DateTime(2020, 11, 15, 4, 8, 39, 185, DateTimeKind.Local).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 15, 4, 8, 39, 180, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 15, 4, 8, 39, 184, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ApplyId",
                table: "Resumes",
                column: "ApplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ApplyId",
                table: "Announcements",
                column: "ApplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Applys_ApplyId",
                table: "Announcements",
                column: "ApplyId",
                principalTable: "Applys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Applys_ApplyId",
                table: "Resumes",
                column: "ApplyId",
                principalTable: "Applys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Applys_ApplyId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Applys_ApplyId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_ApplyId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_ApplyId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "ApplyId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ApplyId",
                table: "Announcements");

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate" },
                values: new object[] { new DateTime(2020, 11, 4, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(8060), new DateTime(2020, 11, 16, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate" },
                values: new object[] { new DateTime(2020, 11, 4, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(9000), new DateTime(2020, 11, 14, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 14, 16, 26, 34, 753, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 11, 14, 16, 26, 34, 758, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.CreateIndex(
                name: "IX_Applys_AnnouncementId",
                table: "Applys",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Applys_ResumeId",
                table: "Applys",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applys_Announcements_AnnouncementId",
                table: "Applys",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applys_Resumes_ResumeId",
                table: "Applys",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
