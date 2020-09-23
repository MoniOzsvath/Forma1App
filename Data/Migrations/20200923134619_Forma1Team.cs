using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forma1App.Data.Migrations
{
    public partial class Forma1Team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forma1Teams",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoundedDate = table.Column<DateTime>(nullable: false),
                    WinnedChampionshipsCount = table.Column<int>(nullable: false),
                    PaiedEntryFee = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forma1Teams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forma1Teams");
        }
    }
}
