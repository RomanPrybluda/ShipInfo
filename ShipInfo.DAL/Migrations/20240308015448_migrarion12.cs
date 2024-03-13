using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migrarion12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipHulls_Ships_Id",
                table: "ShipHulls");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipId",
                table: "ShipHulls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShipHulls_ShipId",
                table: "ShipHulls",
                column: "ShipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipHulls_Ships_ShipId",
                table: "ShipHulls",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipHulls_Ships_ShipId",
                table: "ShipHulls");

            migrationBuilder.DropIndex(
                name: "IX_ShipHulls_ShipId",
                table: "ShipHulls");

            migrationBuilder.DropColumn(
                name: "ShipId",
                table: "ShipHulls");

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
