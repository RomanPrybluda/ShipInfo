using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeTableRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ships_AuxiliaryEngineId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ClassSocietyId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_GeneratorId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_MainEngineId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_OperatorId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipFlagId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipPowerPlantTypeId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipPropulsorTypeId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipTypeId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_StatusId",
                table: "Ships");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_AuxiliaryEngineId",
                table: "Ships",
                column: "AuxiliaryEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ClassSocietyId",
                table: "Ships",
                column: "ClassSocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_GeneratorId",
                table: "Ships",
                column: "GeneratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_MainEngineId",
                table: "Ships",
                column: "MainEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_OperatorId",
                table: "Ships",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipFlagId",
                table: "Ships",
                column: "ShipFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipPowerPlantTypeId",
                table: "Ships",
                column: "ShipPowerPlantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipPropulsorTypeId",
                table: "Ships",
                column: "ShipPropulsorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipTypeId",
                table: "Ships",
                column: "ShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_StatusId",
                table: "Ships",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ships_AuxiliaryEngineId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ClassSocietyId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_GeneratorId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_MainEngineId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_OperatorId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipFlagId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipPowerPlantTypeId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipPropulsorTypeId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipTypeId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_StatusId",
                table: "Ships");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_AuxiliaryEngineId",
                table: "Ships",
                column: "AuxiliaryEngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ClassSocietyId",
                table: "Ships",
                column: "ClassSocietyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_GeneratorId",
                table: "Ships",
                column: "GeneratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_MainEngineId",
                table: "Ships",
                column: "MainEngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_OperatorId",
                table: "Ships",
                column: "OperatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipFlagId",
                table: "Ships",
                column: "ShipFlagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipPowerPlantTypeId",
                table: "Ships",
                column: "ShipPowerPlantTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipPropulsorTypeId",
                table: "Ships",
                column: "ShipPropulsorTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipTypeId",
                table: "Ships",
                column: "ShipTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_StatusId",
                table: "Ships",
                column: "StatusId",
                unique: true);
        }
    }
}
