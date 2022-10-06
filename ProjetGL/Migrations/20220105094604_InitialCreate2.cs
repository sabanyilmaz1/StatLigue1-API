using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetGL.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipeDId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipeEId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreD = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreE = table.Column<int>(type: "INTEGER", nullable: false),
                    DateMatch = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Equipes_EquipeDId",
                        column: x => x.EquipeDId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Equipes_EquipeEId",
                        column: x => x.EquipeEId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_EquipeDId",
                table: "Match",
                column: "EquipeDId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_EquipeEId",
                table: "Match",
                column: "EquipeEId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");
        }
    }
}
