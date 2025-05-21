using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seminaires",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tarif = table.Column<double>(type: "float", nullable: false),
                    DateSeminaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreMaximal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminaires", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    SpecialiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abreviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.SpecialiteId);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroTelephone = table.Column<int>(type: "int", nullable: false),
                    TypeParticipant = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Fonction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomEntreprise = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Niveau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomInstitu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpecialiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Specialites_SpecialiteId",
                        column: x => x.SpecialiteId,
                        principalTable: "Specialites",
                        principalColumn: "SpecialiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantFK = table.Column<int>(type: "int", nullable: false),
                    SeminaireFK = table.Column<int>(type: "int", nullable: false),
                    TauxReduction = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => new { x.SeminaireFK, x.ParticipantFK, x.DateInscription });
                    table.ForeignKey(
                        name: "FK_Inscriptions_Participants_ParticipantFK",
                        column: x => x.ParticipantFK,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Seminaires_SeminaireFK",
                        column: x => x.SeminaireFK,
                        principalTable: "Seminaires",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ParticipantFK",
                table: "Inscriptions",
                column: "ParticipantFK");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_SpecialiteId",
                table: "Participants",
                column: "SpecialiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Seminaires");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
