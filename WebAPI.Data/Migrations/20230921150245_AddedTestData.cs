using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_purchase_purchase_purchase_temp_id",
                table: "product_purchase");

            migrationBuilder.DropForeignKey(
                name: "fk_purchase_clients_client_id",
                table: "purchase");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchase",
                table: "purchase");

            migrationBuilder.RenameTable(
                name: "purchase",
                newName: "purchases");

            migrationBuilder.RenameIndex(
                name: "ix_purchase_client_id",
                table: "purchases",
                newName: "ix_purchases_client_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchases",
                table: "purchases",
                column: "number");

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "id", "date_of_birth", "date_of_registration", "initials" },
                values: new object[,]
                {
                    { new Guid("0ddcc0d3-8d4c-4af1-bcba-12baa06b0af8"), new DateTime(1988, 4, 19, 21, 0, 0, 0, DateTimeKind.Utc), new DateTime(2018, 8, 24, 21, 0, 0, 0, DateTimeKind.Utc), "Client4" },
                    { new Guid("4de9648f-488d-4534-8691-a5c3d93e6a62"), new DateTime(1985, 3, 14, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 7, 19, 21, 0, 0, 0, DateTimeKind.Utc), "Client3" },
                    { new Guid("6cd9ae1b-7f8a-4881-86dc-9ac94e5d658d"), new DateTime(1991, 2, 1, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 6, 10, 21, 0, 0, 0, DateTimeKind.Utc), "Client2" },
                    { new Guid("a541e8e0-ea1a-41da-bbb4-3bd61e17423f"), new DateTime(1989, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc), "Client1" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "article", "category", "name", "price" },
                values: new object[,]
                {
                    { new Guid("31513b63-bb6b-47c1-9c15-19830871ceb5"), "Food", "Product2", 39.99m },
                    { new Guid("7b2bafcf-8ba4-4398-a5a2-0cf61f3d69a4"), "Clothes", "Product3", 49.99m },
                    { new Guid("a0c2d632-3711-47a7-9466-3f2941602afc"), "Other", "Product4", 59.99m },
                    { new Guid("a57cb32f-6cac-43b1-ba46-3e7ee4ddda56"), "Electronics", "Product1", 29.99m }
                });

            migrationBuilder.InsertData(
                table: "purchases",
                columns: new[] { "number", "client_id", "date", "total_value" },
                values: new object[,]
                {
                    { new Guid("00ed4d9a-8e29-434c-b454-6b04dbb5061f"), new Guid("0ddcc0d3-8d4c-4af1-bcba-12baa06b0af8"), new DateTime(2023, 9, 21, 15, 2, 45, 677, DateTimeKind.Utc).AddTicks(7748), 59.99m },
                    { new Guid("0a67c57e-4e00-4ab8-9251-1e79368078a3"), new Guid("6cd9ae1b-7f8a-4881-86dc-9ac94e5d658d"), new DateTime(2023, 9, 21, 15, 2, 45, 677, DateTimeKind.Utc).AddTicks(7744), 39.99m },
                    { new Guid("dc0e5e30-f760-4c07-83ac-d221b20c9960"), new Guid("4de9648f-488d-4534-8691-a5c3d93e6a62"), new DateTime(2023, 9, 21, 15, 2, 45, 677, DateTimeKind.Utc).AddTicks(7746), 49.99m },
                    { new Guid("fa0c1087-a04b-470d-b703-818006158472"), new Guid("a541e8e0-ea1a-41da-bbb4-3bd61e17423f"), new DateTime(2023, 9, 21, 15, 2, 45, 677, DateTimeKind.Utc).AddTicks(7298), 29.99m }
                });

            migrationBuilder.InsertData(
                table: "product_purchase",
                columns: new[] { "product_id", "purchase_id" },
                values: new object[,]
                {
                    { new Guid("31513b63-bb6b-47c1-9c15-19830871ceb5"), new Guid("0a67c57e-4e00-4ab8-9251-1e79368078a3") },
                    { new Guid("7b2bafcf-8ba4-4398-a5a2-0cf61f3d69a4"), new Guid("dc0e5e30-f760-4c07-83ac-d221b20c9960") },
                    { new Guid("a0c2d632-3711-47a7-9466-3f2941602afc"), new Guid("00ed4d9a-8e29-434c-b454-6b04dbb5061f") },
                    { new Guid("a57cb32f-6cac-43b1-ba46-3e7ee4ddda56"), new Guid("fa0c1087-a04b-470d-b703-818006158472") }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_product_purchase_purchases_purchase_temp_id",
                table: "product_purchase",
                column: "purchase_id",
                principalTable: "purchases",
                principalColumn: "number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchases_clients_client_id",
                table: "purchases",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_purchase_purchases_purchase_temp_id",
                table: "product_purchase");

            migrationBuilder.DropForeignKey(
                name: "fk_purchases_clients_client_id",
                table: "purchases");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchases",
                table: "purchases");

            migrationBuilder.DeleteData(
                table: "product_purchase",
                keyColumns: new[] { "product_id", "purchase_id" },
                keyValues: new object[] { new Guid("31513b63-bb6b-47c1-9c15-19830871ceb5"), new Guid("0a67c57e-4e00-4ab8-9251-1e79368078a3") });

            migrationBuilder.DeleteData(
                table: "product_purchase",
                keyColumns: new[] { "product_id", "purchase_id" },
                keyValues: new object[] { new Guid("7b2bafcf-8ba4-4398-a5a2-0cf61f3d69a4"), new Guid("dc0e5e30-f760-4c07-83ac-d221b20c9960") });

            migrationBuilder.DeleteData(
                table: "product_purchase",
                keyColumns: new[] { "product_id", "purchase_id" },
                keyValues: new object[] { new Guid("a0c2d632-3711-47a7-9466-3f2941602afc"), new Guid("00ed4d9a-8e29-434c-b454-6b04dbb5061f") });

            migrationBuilder.DeleteData(
                table: "product_purchase",
                keyColumns: new[] { "product_id", "purchase_id" },
                keyValues: new object[] { new Guid("a57cb32f-6cac-43b1-ba46-3e7ee4ddda56"), new Guid("fa0c1087-a04b-470d-b703-818006158472") });

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "article",
                keyValue: new Guid("31513b63-bb6b-47c1-9c15-19830871ceb5"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "article",
                keyValue: new Guid("7b2bafcf-8ba4-4398-a5a2-0cf61f3d69a4"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "article",
                keyValue: new Guid("a0c2d632-3711-47a7-9466-3f2941602afc"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "article",
                keyValue: new Guid("a57cb32f-6cac-43b1-ba46-3e7ee4ddda56"));

            migrationBuilder.DeleteData(
                table: "purchases",
                keyColumn: "number",
                keyValue: new Guid("00ed4d9a-8e29-434c-b454-6b04dbb5061f"));

            migrationBuilder.DeleteData(
                table: "purchases",
                keyColumn: "number",
                keyValue: new Guid("0a67c57e-4e00-4ab8-9251-1e79368078a3"));

            migrationBuilder.DeleteData(
                table: "purchases",
                keyColumn: "number",
                keyValue: new Guid("dc0e5e30-f760-4c07-83ac-d221b20c9960"));

            migrationBuilder.DeleteData(
                table: "purchases",
                keyColumn: "number",
                keyValue: new Guid("fa0c1087-a04b-470d-b703-818006158472"));

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("0ddcc0d3-8d4c-4af1-bcba-12baa06b0af8"));

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("4de9648f-488d-4534-8691-a5c3d93e6a62"));

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("6cd9ae1b-7f8a-4881-86dc-9ac94e5d658d"));

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("a541e8e0-ea1a-41da-bbb4-3bd61e17423f"));

            migrationBuilder.RenameTable(
                name: "purchases",
                newName: "purchase");

            migrationBuilder.RenameIndex(
                name: "ix_purchases_client_id",
                table: "purchase",
                newName: "ix_purchase_client_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchase",
                table: "purchase",
                column: "number");

            migrationBuilder.AddForeignKey(
                name: "fk_product_purchase_purchase_purchase_temp_id",
                table: "product_purchase",
                column: "purchase_id",
                principalTable: "purchase",
                principalColumn: "number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchase_clients_client_id",
                table: "purchase",
                column: "client_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
