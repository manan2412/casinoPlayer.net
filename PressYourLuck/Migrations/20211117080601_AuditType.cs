using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PressYourLuck.Migrations
{
    public partial class AuditType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 17, 2, 6, 1, 148, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "AuditId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 17, 2, 6, 1, 152, DateTimeKind.Local).AddTicks(6310));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 17, 2, 5, 47, 257, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "Audits",
                keyColumn: "AuditId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 17, 2, 5, 47, 260, DateTimeKind.Local).AddTicks(862));
        }
    }
}
