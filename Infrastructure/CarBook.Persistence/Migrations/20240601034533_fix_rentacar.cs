using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fix_rentacar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "PickUpLocationID",
                table: "RentACars");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "RentACars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationID",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }
    }
}
