using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraveApi.Data
{
    /// <inheritdoc />
    public partial class TravelApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Humans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 8, 12, 26, 32, 135, DateTimeKind.Utc).AddTicks(5332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 8, 11, 25, 58, 750, DateTimeKind.Utc).AddTicks(7523));

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Humans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TravelData",
                table: "Humans",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Humans");

            migrationBuilder.DropColumn(
                name: "TravelData",
                table: "Humans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Humans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 8, 11, 25, 58, 750, DateTimeKind.Utc).AddTicks(7523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 8, 12, 26, 32, 135, DateTimeKind.Utc).AddTicks(5332));
        }
    }
}
