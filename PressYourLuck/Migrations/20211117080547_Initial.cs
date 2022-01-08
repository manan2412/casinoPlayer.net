using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PressYourLuck.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AuditTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "AuditTypes",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTypes", x => x.AuditTypeId);
                });

            migrationBuilder.InsertData(
                table: "AuditTypes",
                columns: new[] { "AuditTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Cash-In" },
                    { 2, "Cash-Out" },
                    { 3, "Win" },
                    { 4, "Lose" }
                });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "AuditId", "Amount", "AuditTypeId", "CreatedDate", "PlayerName" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, new DateTime(2021, 11, 17, 2, 5, 47, 257, DateTimeKind.Local).AddTicks(7637), "Manan" },
                    { 2, 9000.0, 2, new DateTime(2021, 11, 17, 2, 5, 47, 260, DateTimeKind.Local).AddTicks(862), "Kosha" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "AuditTypes");
        }
    }
}
