using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Conducteur",
                columns: table => new
                {
                    No_Dossier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyPrenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Conducteur", x => x.No_Dossier);
                });

            migrationBuilder.CreateTable(
                name: "Tb_DCPR",
                columns: table => new
                {
                    Code_agent = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Affectation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DCPR", x => x.Code_agent);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Contravention",
                columns: table => new
                {
                    No_Fiche = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No_Dossier = table.Column<int>(type: "int", nullable: false),
                    Plaque_vehicule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_agent = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Article_violation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Montant_a_payer = table.Column<int>(type: "int", nullable: false),
                    Date_contravention = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Contravention", x => x.No_Fiche);
                    table.ForeignKey(
                        name: "FK_Tb_Contravention_Tb_Conducteur_No_Dossier",
                        column: x => x.No_Dossier,
                        principalTable: "Tb_Conducteur",
                        principalColumn: "No_Dossier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Contravention_Tb_DCPR_Code_agent",
                        column: x => x.Code_agent,
                        principalTable: "Tb_DCPR",
                        principalColumn: "Code_agent");
                });

            migrationBuilder.CreateTable(
                name: "Tb_DGI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No_Fiche = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    Remarque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_paiement = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DGI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tb_DGI_Tb_Contravention_No_Fiche",
                        column: x => x.No_Fiche,
                        principalTable: "Tb_Contravention",
                        principalColumn: "No_Fiche",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Contravention_Code_agent",
                table: "Tb_Contravention",
                column: "Code_agent");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Contravention_No_Dossier",
                table: "Tb_Contravention",
                column: "No_Dossier");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DGI_No_Fiche",
                table: "Tb_DGI",
                column: "No_Fiche");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_DGI");

            migrationBuilder.DropTable(
                name: "Tb_Contravention");

            migrationBuilder.DropTable(
                name: "Tb_Conducteur");

            migrationBuilder.DropTable(
                name: "Tb_DCPR");
        }
    }
}
