using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cell_shop_api.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 50, 19, 4, DateTimeKind.Local).AddTicks(5765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 950, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvoice",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 50, 19, 0, DateTimeKind.Local).AddTicks(6502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 947, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AccountId", "Content", "ProductId", "Rating" },
                values: new object[] { 1, 2, "Day la review1", 1, 3f });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AccountId", "Content", "ProductId", "Rating" },
                values: new object[] { 2, 2, "Day la review2", 1, 4f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 950, DateTimeKind.Local).AddTicks(1472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 50, 19, 4, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvoice",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 947, DateTimeKind.Local).AddTicks(4775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 50, 19, 0, DateTimeKind.Local).AddTicks(6502));
        }
    }
}
