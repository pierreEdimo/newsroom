using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newsroom.Migrations
{
    public partial class isfavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Articles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 18, 13, 8, 15, 238, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 18, 13, 8, 15, 241, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 18, 13, 8, 15, 241, DateTimeKind.Local).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 18, 13, 8, 15, 241, DateTimeKind.Local).AddTicks(8590));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 1, 11, 29, 41, 995, DateTimeKind.Local).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 1, 11, 29, 42, 14, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 1, 11, 29, 42, 14, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 1, 11, 29, 42, 14, DateTimeKind.Local).AddTicks(125));
        }
    }
}
