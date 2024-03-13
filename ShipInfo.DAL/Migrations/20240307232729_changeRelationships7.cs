using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationships7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipHulls_ShipHullId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipHullId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ShipHullId",
                table: "Ships");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ShipHullId",
                table: "Ships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
