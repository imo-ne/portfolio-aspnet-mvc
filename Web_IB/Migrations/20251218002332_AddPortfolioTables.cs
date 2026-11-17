using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_IB.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfolioTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Niveau = table.Column<int>(type: "int", maxLength: 40, nullable: true),
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreePar = table.Column<int>(type: "int", nullable: true),
                    EstSupprime = table.Column<bool>(type: "bit", nullable: true),
                    SupprimeA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupprimePar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competences_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poste = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Entreprise = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreePar = table.Column<int>(type: "int", nullable: true),
                    EstSupprime = table.Column<bool>(type: "bit", nullable: true),
                    SupprimeA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupprimePar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Lien = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreePar = table.Column<int>(type: "int", nullable: true),
                    EstSupprime = table.Column<bool>(type: "bit", nullable: true),
                    SupprimeA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupprimePar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projets_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competences_PersonneId",
                table: "Competences",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PersonneId",
                table: "Experiences",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_PersonneId",
                table: "Projets",
                column: "PersonneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Projets");
        }
    }
}
