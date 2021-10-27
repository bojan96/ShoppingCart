using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class AddSubmittedCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "user1");

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 2, "user2", 2, new DateTime(2021, 1, 1, 10, 10, 10, 0, DateTimeKind.Utc), null });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 6, 2, "test", "Description6", "Name6", new DateTime(2021, 1, 7, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 7, 2, "test", "Description7", "Name7", new DateTime(2021, 1, 8, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 8, 2, "test", "Description8", "Name8", new DateTime(2021, 1, 9, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 9, 2, "test", "Description9", "Name9", new DateTime(2021, 1, 10, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 10, 2, "test", "Description10", "Name10", new DateTime(2021, 1, 11, 10, 10, 10, 0, DateTimeKind.Utc), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "test");
        }
    }
}
