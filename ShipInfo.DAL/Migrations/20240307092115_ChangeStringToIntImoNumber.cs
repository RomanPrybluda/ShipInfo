using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStringToIntImoNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImoNumber",
                table: "Ships",
                type: "int",
                precision: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldPrecision: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImoNumber",
                table: "Ships",
                type: "nvarchar(max)",
                precision: 7,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 7);
        }
    }
}
