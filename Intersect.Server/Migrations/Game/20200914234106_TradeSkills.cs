using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Game
{
    public partial class TradeSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeCreated = table.Column<long>(nullable: false),
                    TradeskillType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    XPBase = table.Column<int>(nullable: false),
                    XPIncrease = table.Column<int>(nullable: false),
                    MaxLevel = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    CraftUnlocks = table.Column<string>(nullable: true),
                    WeaponUnlocks = table.Column<string>(nullable: true),
                    SkillUnlocks = table.Column<string>(nullable: true),
                    Folder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeSkill", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeSkill");
        }
    }
}
