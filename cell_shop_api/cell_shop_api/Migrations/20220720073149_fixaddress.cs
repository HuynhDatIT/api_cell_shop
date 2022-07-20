using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cell_shop_api.Migrations
{
    public partial class fixaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 14, 31, 48, 832, DateTimeKind.Local).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 8, 13, 13, 641, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvoice",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 14, 31, 48, 828, DateTimeKind.Local).AddTicks(5586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 8, 13, 13, 636, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 8, 13, 13, 641, DateTimeKind.Local).AddTicks(3711),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 14, 31, 48, 832, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvoice",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 8, 13, 13, 636, DateTimeKind.Local).AddTicks(1046),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 14, 31, 48, 828, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
