using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetGL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomEquipe = table.Column<string>(type: "TEXT", nullable: true),
                    AcronymeClub = table.Column<string>(type: "TEXT", nullable: true),
                    NomEntraineur = table.Column<string>(type: "TEXT", nullable: true),
                    NombrePoints = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreVictoire = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreDefaite = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreNul = table.Column<int>(type: "INTEGER", nullable: false),
                    DifferencedeBut = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassementEquipe = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomJoueur = table.Column<string>(type: "TEXT", nullable: true),
                    PrenomJoueur = table.Column<string>(type: "TEXT", nullable: true),
                    AgeJoueur = table.Column<int>(type: "INTEGER", nullable: false),
                    NationaliteJoueur = table.Column<string>(type: "TEXT", nullable: true),
                    TailleJoueur = table.Column<double>(type: "REAL", nullable: false),
                    PosteJoueur = table.Column<string>(type: "TEXT", nullable: true),
                    MatchJouee = table.Column<int>(type: "INTEGER", nullable: false),
                    CartonJaune = table.Column<int>(type: "INTEGER", nullable: false),
                    CartonRouge = table.Column<int>(type: "INTEGER", nullable: false),
                    ButJoueur = table.Column<int>(type: "INTEGER", nullable: false),
                    PasseDecisiveJoueur = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueur_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Joueur_EquipeId",
                table: "Joueur",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
