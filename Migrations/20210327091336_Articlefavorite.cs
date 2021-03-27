using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newsroom.Migrations
{
    public partial class Articlefavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 27, 10, 13, 34, 650, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 27, 10, 13, 34, 673, DateTimeKind.Local).AddTicks(8651));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 12, 1, 4, 51, 483, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 12, 1, 4, 51, 490, DateTimeKind.Local).AddTicks(6793));
        }
    }
}
