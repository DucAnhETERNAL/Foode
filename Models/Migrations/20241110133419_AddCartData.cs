using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class AddCartData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 2, 3, 1 },
                    { 3, 1, 1, 2 },
                    { 4, 2, 4, 2 },
                    { 5, 1, 5, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderDetailsId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderDetailsId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 20, 34, 19, 402, DateTimeKind.Local).AddTicks(4334));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderDetailsId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderDetailsId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 9, 11, 49, 0, 592, DateTimeKind.Local).AddTicks(9660));
        }
    }
}
