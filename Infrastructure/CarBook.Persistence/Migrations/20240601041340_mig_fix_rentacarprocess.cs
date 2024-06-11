using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_fix_rentacarprocess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "PickUpTime",
                table: "RentACarProcess",
                type: "Time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickUpDate",
                table: "RentACarProcess",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DropOffTime",
                table: "RentACarProcess",
                type: "Time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DropOffDate",
                table: "RentACarProcess",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "PickUpTime",
                table: "RentACarProcess",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "Time");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PickUpDate",
                table: "RentACarProcess",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "DropOffTime",
                table: "RentACarProcess",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "Time");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DropOffDate",
                table: "RentACarProcess",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
