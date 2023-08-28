using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyfootAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EloMin = table.Column<int>(type: "int", nullable: false),
                    EloMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstPlayerId = table.Column<int>(type: "int", nullable: false),
                    FirstPlayerScore = table.Column<int>(type: "int", nullable: false),
                    SecondPlayerId = table.Column<int>(type: "int", nullable: false),
                    SecondPlayerScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstPlayerId = table.Column<int>(type: "int", nullable: false),
                    SecondPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Players_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstTeamScore = table.Column<int>(type: "int", nullable: false),
                    FirstTeamId = table.Column<int>(type: "int", nullable: false),
                    SecondTeamScore = table.Column<int>(type: "int", nullable: false),
                    SecondTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamGames_Teams_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamGames_Teams_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_FirstPlayerId",
                table: "PlayerGames",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_SecondPlayerId",
                table: "PlayerGames",
                column: "SecondPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RankId",
                table: "Players",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_FirstTeamId",
                table: "TeamGames",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGames_SecondTeamId",
                table: "TeamGames",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_FirstPlayerId",
                table: "Teams",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SecondPlayerId",
                table: "Teams",
                column: "SecondPlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "TeamGames");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
