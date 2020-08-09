using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations
{
    public partial class guildspt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuildExperience",
                table: "Guilds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuildLevel",
                table: "Guilds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guild_Bank",
                columns: table => new
                {
                    BagId = table.Column<Guid>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StatBuffs = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    GuildId = table.Column<Guid>(nullable: false),
                    Slot = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guild_Bank", x => x.Id);
                    //Hooray to limitations!
                    /*table.ForeignKey(
                        name: "FK_Guild_Bank_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guild_Bank_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);*/
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guild_Bank_BagId",
                table: "Guild_Bank",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_Guild_Bank_GuildId",
                table: "Guild_Bank",
                column: "GuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guild_Bank");

            migrationBuilder.DropColumn(
                name: "GuildExperience",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "GuildLevel",
                table: "Guilds");
        }
    }
}
