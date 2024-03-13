using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeRel26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipHulls_Ships_Id",
                table: "ShipHulls");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipHullId",
                table: "Ships",
                column: "ShipHullId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipHulls_ShipHullId",
                table: "Ships",
                column: "ShipHullId",
                principalTable: "ShipHulls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipHulls_ShipHullId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipHullId",
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
