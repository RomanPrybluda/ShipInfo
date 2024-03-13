﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShipInfo.DAL;

#nullable disable

namespace ShipInfo.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240307092115_ChangeStringToIntImoNumber")]
    partial class ChangeStringToIntImoNumber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShipInfo.DAL.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ShipInfo.DAL.AuxiliaryEngine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AuxiliaryEngineManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuxiliaryEngineType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("MaxAuxiliaryEnginePower")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("MaxAuxiliaryEngineSpeed")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuxiliaryEngineManufacturerId");

                    b.ToTable("AuxiliaryEngines");
                });

            modelBuilder.Entity("ShipInfo.DAL.AuxiliaryEngineManufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AuxiliaryEngineManufacturerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AuxiliaryEngineManufacturers");
                });

            modelBuilder.Entity("ShipInfo.DAL.ClassSociety", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ClassSocietyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ClassSocietyIsIACS")
                        .HasColumnType("bit");

                    b.Property<string>("ClassSocietyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ClassSocieties");
                });

            modelBuilder.Entity("ShipInfo.DAL.Generator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("GeneratorManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GeneratorType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("GeneratorVoltage")
                        .HasColumnType("int");

                    b.Property<int>("MaxGeneratorPower")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneratorManufacturerId");

                    b.ToTable("Generators");
                });

            modelBuilder.Entity("ShipInfo.DAL.GeneratorManufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("GeneratorManufacturerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("GeneratorManufacturers");
                });

            modelBuilder.Entity("ShipInfo.DAL.MainEngine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("MainEngineManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MainEngineType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("MaxMainEnginePower")
                        .HasColumnType("int");

                    b.Property<int>("MaxMainEngineSpeed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainEngineManufacturerId");

                    b.ToTable("MainEngines");
                });

            modelBuilder.Entity("ShipInfo.DAL.MainEngineManufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("MainEngineManufacturerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MainEngineManufacturers");
                });

            modelBuilder.Entity("ShipInfo.DAL.Operator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("OperatorAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OperatorPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("ShipInfo.DAL.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("OwnerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OwnerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("ShipInfo.DAL.Ship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AuxiliaryEngineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AuxiliaryEngineQuantity")
                        .HasColumnType("int");

                    b.Property<string>("CallSign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClassSocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBuild")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GeneratorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GeneratorQuantity")
                        .HasColumnType("int");

                    b.Property<double>("GrossTonnage")
                        .HasColumnType("float");

                    b.Property<int>("ImoNumber")
                        .HasPrecision(7)
                        .HasColumnType("int");

                    b.Property<Guid>("MainEngineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MainEngineQuantity")
                        .HasColumnType("int");

                    b.Property<double>("NetTonnage")
                        .HasColumnType("float");

                    b.Property<Guid>("OperatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipBuilderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipFlagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipHullId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("ShipPowerPlantTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipPropulsorTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShipTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("SummerDeadweight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AuxiliaryEngineId")
                        .IsUnique();

                    b.HasIndex("ClassSocietyId")
                        .IsUnique();

                    b.HasIndex("GeneratorId")
                        .IsUnique();

                    b.HasIndex("MainEngineId")
                        .IsUnique();

                    b.HasIndex("OperatorId")
                        .IsUnique();

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.HasIndex("ShipBuilderId");

                    b.HasIndex("ShipFlagId")
                        .IsUnique();

                    b.HasIndex("ShipHullId")
                        .IsUnique();

                    b.HasIndex("ShipPowerPlantTypeId")
                        .IsUnique();

                    b.HasIndex("ShipPropulsorTypeId")
                        .IsUnique();

                    b.HasIndex("ShipTypeId")
                        .IsUnique();

                    b.HasIndex("StatusId")
                        .IsUnique();

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipBuilder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ShipBuilderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShipBuilders");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipFlag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ShipFlagName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShipFlags");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipHull", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double>("BetweenPerpendicularsLength")
                        .HasColumnType("float");

                    b.Property<double>("Breadth")
                        .HasColumnType("float");

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<double>("Displacement")
                        .HasColumnType("float");

                    b.Property<double>("Lightship")
                        .HasColumnType("float");

                    b.Property<double>("OverAllLength")
                        .HasColumnType("float");

                    b.Property<double>("SummerDraught")
                        .HasColumnType("float");

                    b.Property<double>("SummerFreeBoard")
                        .HasColumnType("float");

                    b.Property<double>("VolumeDisplacement")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ShipHulls");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipPowerPlantType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ShipPowerPlantTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShipPowerPlantTypes");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipPropulsorType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ShipPropulsorTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShipPropulsorTypes");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ShipTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShipTypes");
                });

            modelBuilder.Entity("ShipInfo.DAL.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShipInfo.DAL.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShipInfo.DAL.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShipInfo.DAL.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShipInfo.DAL.AuxiliaryEngine", b =>
                {
                    b.HasOne("ShipInfo.DAL.AuxiliaryEngineManufacturer", "AuxiliaryEngineManufacturer")
                        .WithMany("AuxiliaryEngines")
                        .HasForeignKey("AuxiliaryEngineManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuxiliaryEngineManufacturer");
                });

            modelBuilder.Entity("ShipInfo.DAL.Generator", b =>
                {
                    b.HasOne("ShipInfo.DAL.GeneratorManufacturer", "GeneratorManufacturer")
                        .WithMany("Generators")
                        .HasForeignKey("GeneratorManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeneratorManufacturer");
                });

            modelBuilder.Entity("ShipInfo.DAL.MainEngine", b =>
                {
                    b.HasOne("ShipInfo.DAL.MainEngineManufacturer", "MainEngineManufacturer")
                        .WithMany("MainEngines")
                        .HasForeignKey("MainEngineManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainEngineManufacturer");
                });

            modelBuilder.Entity("ShipInfo.DAL.Ship", b =>
                {
                    b.HasOne("ShipInfo.DAL.AuxiliaryEngine", "AuxiliaryEngine")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "AuxiliaryEngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ClassSociety", "ClassSociety")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "ClassSocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.Generator", "Generator")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "GeneratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.MainEngine", "MainEngine")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "MainEngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.Operator", "Operator")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.Owner", "Owner")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ShipBuilder", "ShipBuilder")
                        .WithMany("Ships")
                        .HasForeignKey("ShipBuilderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ShipFlag", "ShipFlag")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "ShipFlagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ShipHull", "ShipHull")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "ShipHullId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ShipPowerPlantType", "ShipPowerPlantType")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "ShipPowerPlantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ShipPropulsorType", "ShipPropulsorType")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "ShipPropulsorTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.ShipType", "ShipType")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "ShipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShipInfo.DAL.Status", "Status")
                        .WithOne("Ship")
                        .HasForeignKey("ShipInfo.DAL.Ship", "StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuxiliaryEngine");

                    b.Navigation("ClassSociety");

                    b.Navigation("Generator");

                    b.Navigation("MainEngine");

                    b.Navigation("Operator");

                    b.Navigation("Owner");

                    b.Navigation("ShipBuilder");

                    b.Navigation("ShipFlag");

                    b.Navigation("ShipHull");

                    b.Navigation("ShipPowerPlantType");

                    b.Navigation("ShipPropulsorType");

                    b.Navigation("ShipType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ShipInfo.DAL.AuxiliaryEngine", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.AuxiliaryEngineManufacturer", b =>
                {
                    b.Navigation("AuxiliaryEngines");
                });

            modelBuilder.Entity("ShipInfo.DAL.ClassSociety", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.Generator", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.GeneratorManufacturer", b =>
                {
                    b.Navigation("Generators");
                });

            modelBuilder.Entity("ShipInfo.DAL.MainEngine", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.MainEngineManufacturer", b =>
                {
                    b.Navigation("MainEngines");
                });

            modelBuilder.Entity("ShipInfo.DAL.Operator", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.Owner", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipBuilder", b =>
                {
                    b.Navigation("Ships");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipFlag", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipHull", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipPowerPlantType", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipPropulsorType", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.ShipType", b =>
                {
                    b.Navigation("Ship");
                });

            modelBuilder.Entity("ShipInfo.DAL.Status", b =>
                {
                    b.Navigation("Ship");
                });
#pragma warning restore 612, 618
        }
    }
}
