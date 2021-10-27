using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class ChangeCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "auth0|617946b7ed3a290068b82013");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "auth0|617946b7ed3a290068b82013");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "auth0|617946b7ed3a290068b82013");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "auth0|617946b7ed3a290068b82013");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "auth0|617946b7ed3a290068b82013");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: "auth0|6179475e1c278900683507fd");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: "auth0|6179475e1c278900683507fd");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: "auth0|6179475e1c278900683507fd");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedBy",
                value: "auth0|6179475e1c278900683507fd");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedBy",
                value: "auth0|6179475e1c278900683507fd");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "auth0|617946b7ed3a290068b82013");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "auth0|6179475e1c278900683507fd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedBy",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "user2");
        }
    }
}
