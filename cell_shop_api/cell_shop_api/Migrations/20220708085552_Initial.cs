using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cell_shop_api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 950, DateTimeKind.Local).AddTicks(1472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 23, 20, 3, 37, 620, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPhone",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvoice",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 947, DateTimeKind.Local).AddTicks(4775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 23, 20, 3, 37, 617, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 23, 20, 3, 37, 620, DateTimeKind.Local).AddTicks(61),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 950, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPhone",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvoice",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 23, 20, 3, 37, 617, DateTimeKind.Local).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 8, 15, 55, 51, 947, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
