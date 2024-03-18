using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuxiliaryEngineManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AuxiliaryEngineManufacturerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuxiliaryEngineManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassSocieties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ClassSocietyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassSocietyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassSocietyIsIACS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSocieties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneratorManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    GeneratorManufacturerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratorManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainEngineManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    MainEngineManufacturerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEngineManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    OperatorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OperatorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    OwnerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipBuilders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ShipBuilderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipBuilders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipFlags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ShipFlagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipFlags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipPowerPlantTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ShipPowerPlantTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipPowerPlantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipPropulsorTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ShipPropulsorTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipPropulsorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ShipTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    StatusName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuxiliaryEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AuxiliaryEngineType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxAuxiliaryEnginePower = table.Column<int>(type: "int", nullable: false),
                    MaxAuxiliaryEngineSpeed = table.Column<int>(type: "int", nullable: false),
                    AuxiliaryEngineManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuxiliaryEngines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuxiliaryEngines_AuxiliaryEngineManufacturers_AuxiliaryEngineManufacturerId",
                        column: x => x.AuxiliaryEngineManufacturerId,
                        principalTable: "AuxiliaryEngineManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    GeneratorType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxGeneratorPower = table.Column<int>(type: "int", nullable: false),
                    GeneratorVoltage = table.Column<int>(type: "int", nullable: false),
                    GeneratorManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generators_GeneratorManufacturers_GeneratorManufacturerId",
                        column: x => x.GeneratorManufacturerId,
                        principalTable: "GeneratorManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    MainEngineType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxMainEnginePower = table.Column<int>(type: "int", nullable: false),
                    MaxMainEngineSpeed = table.Column<int>(type: "int", nullable: false),
                    MainEngineManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEngines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainEngines_MainEngineManufacturers_MainEngineManufacturerId",
                        column: x => x.MainEngineManufacturerId,
                        principalTable: "MainEngineManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ImoNumber = table.Column<int>(type: "int", precision: 7, nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ShipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipFlagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassSocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBuild = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrossTonnage = table.Column<double>(type: "float", nullable: false),
                    NetTonnage = table.Column<double>(type: "float", nullable: false),
                    SummerDeadweight = table.Column<double>(type: "float", nullable: false),
                    OverAllLength = table.Column<double>(type: "float", nullable: false),
                    BetweenPerpendicularsLength = table.Column<double>(type: "float", nullable: false),
                    Breadth = table.Column<double>(type: "float", nullable: false),
                    Depth = table.Column<double>(type: "float", nullable: false),
                    SummerDraught = table.Column<double>(type: "float", nullable: false),
                    SummerFreeBoard = table.Column<double>(type: "float", nullable: false),
                    Lightship = table.Column<double>(type: "float", nullable: false),
                    Displacement = table.Column<double>(type: "float", nullable: false),
                    VolumeDisplacement = table.Column<double>(type: "float", nullable: false),
                    ShipPowerPlantTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipPropulsorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainEngineQuantity = table.Column<int>(type: "int", nullable: false),
                    MainEngineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuxiliaryEngineQuantity = table.Column<int>(type: "int", nullable: false),
                    AuxiliaryEngineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratorQuantity = table.Column<int>(type: "int", nullable: false),
                    GeneratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipBuilderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_AuxiliaryEngines_AuxiliaryEngineId",
                        column: x => x.AuxiliaryEngineId,
                        principalTable: "AuxiliaryEngines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ClassSocieties_ClassSocietyId",
                        column: x => x.ClassSocietyId,
                        principalTable: "ClassSocieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_Generators_GeneratorId",
                        column: x => x.GeneratorId,
                        principalTable: "Generators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_MainEngines_MainEngineId",
                        column: x => x.MainEngineId,
                        principalTable: "MainEngines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ShipBuilders_ShipBuilderId",
                        column: x => x.ShipBuilderId,
                        principalTable: "ShipBuilders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ShipFlags_ShipFlagId",
                        column: x => x.ShipFlagId,
                        principalTable: "ShipFlags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ShipPowerPlantTypes_ShipPowerPlantTypeId",
                        column: x => x.ShipPowerPlantTypeId,
                        principalTable: "ShipPowerPlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ShipPropulsorTypes_ShipPropulsorTypeId",
                        column: x => x.ShipPropulsorTypeId,
                        principalTable: "ShipPropulsorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ShipTypes_ShipTypeId",
                        column: x => x.ShipTypeId,
                        principalTable: "ShipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuxiliaryEngines_AuxiliaryEngineManufacturerId",
                table: "AuxiliaryEngines",
                column: "AuxiliaryEngineManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Generators_GeneratorManufacturerId",
                table: "Generators",
                column: "GeneratorManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_MainEngines_MainEngineManufacturerId",
                table: "MainEngines",
                column: "MainEngineManufacturerId");

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
                name: "IX_Ships_ShipBuilderId",
                table: "Ships",
                column: "ShipBuilderId");

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
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AuxiliaryEngines");

            migrationBuilder.DropTable(
                name: "ClassSocieties");

            migrationBuilder.DropTable(
                name: "Generators");

            migrationBuilder.DropTable(
                name: "MainEngines");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "ShipBuilders");

            migrationBuilder.DropTable(
                name: "ShipFlags");

            migrationBuilder.DropTable(
                name: "ShipPowerPlantTypes");

            migrationBuilder.DropTable(
                name: "ShipPropulsorTypes");

            migrationBuilder.DropTable(
                name: "ShipTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "AuxiliaryEngineManufacturers");

            migrationBuilder.DropTable(
                name: "GeneratorManufacturers");

            migrationBuilder.DropTable(
                name: "MainEngineManufacturers");
        }
    }
}
