using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace agroWebSitreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AnalysisMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "analysis",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idFarm = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    currentPh = table.Column<float>(type: "real", nullable: false),
                    currentMo = table.Column<float>(type: "real", nullable: false),
                    currentCo = table.Column<float>(type: "real", nullable: false),
                    currentP = table.Column<float>(type: "real", nullable: false),
                    currentK = table.Column<float>(type: "real", nullable: false),
                    currentCa = table.Column<float>(type: "real", nullable: false),
                    currentMg = table.Column<float>(type: "real", nullable: false),
                    currentS = table.Column<float>(type: "real", nullable: false),
                    currentB = table.Column<float>(type: "real", nullable: false),
                    currentZn = table.Column<float>(type: "real", nullable: false),
                    currentCu = table.Column<float>(type: "real", nullable: false),
                    currentMn = table.Column<float>(type: "real", nullable: false),
                    currentFe = table.Column<float>(type: "real", nullable: false),
                    currentAl = table.Column<float>(type: "real", nullable: false),
                    currentCtc = table.Column<float>(type: "real", nullable: false),
                    currentV = table.Column<float>(type: "real", nullable: false),
                    currentHal = table.Column<float>(type: "real", nullable: false),
                    missingPh = table.Column<float>(type: "real", nullable: false),
                    missingMo = table.Column<float>(type: "real", nullable: false),
                    missingCo = table.Column<float>(type: "real", nullable: false),
                    missingP = table.Column<float>(type: "real", nullable: false),
                    missingK = table.Column<float>(type: "real", nullable: false),
                    missingCa = table.Column<float>(type: "real", nullable: false),
                    missingMg = table.Column<float>(type: "real", nullable: false),
                    missingS = table.Column<float>(type: "real", nullable: false),
                    missingB = table.Column<float>(type: "real", nullable: false),
                    missingZn = table.Column<float>(type: "real", nullable: false),
                    missingCu = table.Column<float>(type: "real", nullable: false),
                    missingMn = table.Column<float>(type: "real", nullable: false),
                    missingFe = table.Column<float>(type: "real", nullable: false),
                    missingAl = table.Column<float>(type: "real", nullable: false),
                    missingCtc = table.Column<float>(type: "real", nullable: false),
                    missingV = table.Column<float>(type: "real", nullable: false),
                    missingHal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysis", x => x.id);
                    table.ForeignKey(
                        name: "FK_analysis_farm_idFarm",
                        column: x => x.idFarm,
                        principalTable: "farm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_analysis_idFarm",
                table: "analysis",
                column: "idFarm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analysis");
        }
    }
}
