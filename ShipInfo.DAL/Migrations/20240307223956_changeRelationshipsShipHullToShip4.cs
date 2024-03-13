﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationshipsShipHullToShip4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipHullId",
                table: "Ships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShipHullId",
                table: "Ships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}