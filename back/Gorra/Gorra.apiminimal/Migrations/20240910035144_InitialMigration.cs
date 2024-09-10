using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorra.apiminimal.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudadanos",
                columns: table => new
                {
                    CitizenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudadanos", x => x.CitizenId);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    IdDenuncia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCitizen = table.Column<int>(type: "int", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DenunciaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.IdDenuncia);
                    table.ForeignKey(
                        name: "FK_Denuncias_Ciudadanos_IdCitizen",
                        column: x => x.IdCitizen,
                        principalTable: "Ciudadanos",
                        principalColumn: "CitizenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_IdCitizen",
                table: "Denuncias",
                column: "IdCitizen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Ciudadanos");
        }
    }
}
