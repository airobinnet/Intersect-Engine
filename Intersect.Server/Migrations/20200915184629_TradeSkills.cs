using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations
{
    public partial class TradeSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player_Tradeskills",
                columns: table => new
                {
                    TradeSkillId = table.Column<Guid>(nullable: false),
                    Unlocked = table.Column<bool>(nullable: false),
                    CurrentLevel = table.Column<int>(nullable: false),
                    CurrentXp = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    Slot = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Tradeskills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Tradeskills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_Tradeskills_PlayerId",
                table: "Player_Tradeskills",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player_Tradeskills");
        }
    }
}
