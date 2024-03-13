using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeRel21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipHulls_Ships_Id",
                table: "ShipHulls");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipHulls_Id",
                table: "Ships",
                column: "Id",
                principalTable: "ShipHulls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipHulls_Id",
                table: "Ships");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipHulls_Ships_Id",
                table: "ShipHulls",
                column: "Id",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
