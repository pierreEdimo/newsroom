using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newsroom.Migrations
{
    public partial class Articles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CommentCount", "Content", "CreatedAt", "ImageCredits", "ImageUrl", "Title", "TopicId" },
                values: new object[] { 3, 1, 0, "**At the end of 2019, everyone announced Tesla's death. But todayTesla is more valuable than Volswagen, Daimler and Toyota put together, I'll explain why and what it means for German brands.**\n\n\nAt first glance, you should know that the market for electric cars is growing thanks to the aid proposed by the European Union, but due to the crisis caused by Covid, the traditional German brands are facing a huge crisis. In addition to facing their production bases, they have to invest even more capital to electrify their fleets. The result ? Mercedes Benz, for example, has launched a vast savings programme, which consists in cutting unnecessary expenses, delocalising the production of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked more than 10,000 employees in 2020, and it's not over yet. \n\n\nIt is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric cars produced by vw have been a huge success in Europe.\n\n\nNow let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable business. But that can change very quickly.\n\n\nIn conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid.", new DateTime(2021, 11, 1, 11, 29, 42, 14, DateTimeKind.Local).AddTicks(118), "www.unsplash.com", "https://images.unsplash.com/photo-1545693315-85b6be26a3d6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80", "Genders aren't social constructs", 9 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CommentCount", "Content", "CreatedAt", "ImageCredits", "ImageUrl", "Title", "TopicId" },
                values: new object[] { 4, 1, 0, "**At the end of 2019, everyone announced Tesla's death. But todayTesla is more valuable than Volswagen, Daimler and Toyota put together, I'll explain why and what it means for German brands.**\n\n\nAt first glance, you should know that the market for electric cars is growing thanks to the aid proposed by the European Union, but due to the crisis caused by Covid, the traditional German brands are facing a huge crisis. In addition to facing their production bases, they have to invest even more capital to electrify their fleets. The result ? Mercedes Benz, for example, has launched a vast savings programme, which consists in cutting unnecessary expenses, delocalising the production of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked more than 10,000 employees in 2020, and it's not over yet. \n\n\nIt is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric cars produced by vw have been a huge success in Europe.\n\n\nNow let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable business. But that can change very quickly.\n\n\nIn conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid.", new DateTime(2021, 11, 1, 11, 29, 42, 14, DateTimeKind.Local).AddTicks(125), "www.unsplash.com", "https://images.unsplash.com/photo-1528629297340-d1d466945dc5?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=922&q=80", "Biking is healthy", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 10, 14, 50, 7, 570, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 10, 14, 50, 7, 577, DateTimeKind.Local).AddTicks(2077));
        }
    }
}
