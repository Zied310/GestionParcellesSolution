using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agriculteurs",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenomNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agriculteurs", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Cooperatives",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperatives", x => x.Reference);
                });

            migrationBuilder.CreateTable(
                name: "Parcelles",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Superficie = table.Column<double>(type: "float", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sol = table.Column<int>(type: "int", nullable: false),
                    CooperativeReference = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelles", x => x.Reference);
                    table.ForeignKey(
                        name: "FK_Parcelles_Cooperatives_CooperativeReference",
                        column: x => x.CooperativeReference,
                        principalTable: "Cooperatives",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agricultures",
                columns: table => new
                {
                    AgriculteurCIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParcelleRef = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePlantation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRecolte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixLocationParcelle = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultures", x => new { x.ParcelleRef, x.AgriculteurCIN });
                    table.ForeignKey(
                        name: "FK_Agricultures_Agriculteurs_AgriculteurCIN",
                        column: x => x.AgriculteurCIN,
                        principalTable: "Agriculteurs",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agricultures_Parcelles_ParcelleRef",
                        column: x => x.ParcelleRef,
                        principalTable: "Parcelles",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agricultures_AgriculteurCIN",
                table: "Agricultures",
                column: "AgriculteurCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelles_CooperativeReference",
                table: "Parcelles",
                column: "CooperativeReference");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agricultures");

            migrationBuilder.DropTable(
                name: "Agriculteurs");

            migrationBuilder.DropTable(
                name: "Parcelles");

            migrationBuilder.DropTable(
                name: "Cooperatives");
        }
    }
}
