using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop_DotNetCore.Migrations
{
    /// <inheritdoc />
    public partial class Relationsandseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The best Laptop", "Laptop" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 20m, 440 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 30m, 30 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 40m, 34 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "Price", "QuantityInStock" },
                values: new object[] { 4, 20m, 33 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "car");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Book");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The best Home", "Home" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 10m, 22 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 10m, 22 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 10m, 22 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Course 1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Course 2");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ItemID", "Name" },
                values: new object[] { 3, 3, "Course 3" });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 }
                });
        }
    }
}
