using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetGL.Migrations
{
    public partial class InitialCreate8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joueur_Equipes_EquipeId",
                table: "Joueur");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Equipes_EquipeDId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Equipes_EquipeEId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipes",
                table: "Equipes");

            migrationBuilder.RenameTable(
                name: "Equipes",
                newName: "Equipe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipe",
                table: "Equipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Joueur_Equipe_EquipeId",
                table: "Joueur",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Equipe_EquipeDId",
                table: "Match",
                column: "EquipeDId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Equipe_EquipeEId",
                table: "Match",
                column: "EquipeEId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joueur_Equipe_EquipeId",
                table: "Joueur");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Equipe_EquipeDId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Equipe_EquipeEId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipe",
                table: "Equipe");

            migrationBuilder.RenameTable(
                name: "Equipe",
                newName: "Equipes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipes",
                table: "Equipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Joueur_Equipes_EquipeId",
                table: "Joueur",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Equipes_EquipeDId",
                table: "Match",
                column: "EquipeDId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Equipes_EquipeEId",
                table: "Match",
                column: "EquipeEId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
