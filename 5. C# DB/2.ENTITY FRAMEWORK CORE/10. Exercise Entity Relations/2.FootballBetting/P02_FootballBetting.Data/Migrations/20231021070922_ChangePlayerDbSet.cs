using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_FootballBetting.Data.Migrations
{
    public partial class ChangePlayerDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Positions_PositionId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersStatistics_Player_PlayerId",
                table: "PlayersStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameIndex(
                name: "IX_Player_TeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_PositionId",
                table: "Players",
                newName: "IX_Players_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersStatistics_Players_PlayerId",
                table: "PlayersStatistics",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersStatistics_Players_PlayerId",
                table: "PlayersStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Player",
                newName: "IX_Player_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PositionId",
                table: "Player",
                newName: "IX_Player_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Positions_PositionId",
                table: "Player",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersStatistics_Player_PlayerId",
                table: "PlayersStatistics",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
