using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Game
{
    public partial class NPCBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Behavior",
                table: "Npcs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Behavior",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeCreated = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BehaviorType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Enrage = table.Column<bool>(nullable: false),
                    EnrageTimer = table.Column<int>(nullable: false),
                    EnrageSkill = table.Column<Guid>(nullable: false),
                    SpellSequences = table.Column<string>(nullable: true),
                    Folder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behavior", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Behavior");

            migrationBuilder.DropColumn(
                name: "Behavior",
                table: "Npcs");
        }
    }
}
