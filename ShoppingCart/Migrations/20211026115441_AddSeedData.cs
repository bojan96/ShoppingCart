using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1, "test", 0, new DateTime(2021, 1, 1, 10, 10, 10, 0, DateTimeKind.Utc), null });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1, 1, "test", "Description1", "Name1", new DateTime(2021, 1, 2, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 2, 1, "test", "Description2", "Name2", new DateTime(2021, 1, 3, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 3, 1, "test", "Description3", "Name3", new DateTime(2021, 1, 4, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 4, 1, "test", "Description4", "Name4", new DateTime(2021, 1, 5, 10, 10, 10, 0, DateTimeKind.Utc), null },
                    { 5, 1, "test", "Description5", "Name5", new DateTime(2021, 1, 6, 10, 10, 10, 0, DateTimeKind.Utc), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
