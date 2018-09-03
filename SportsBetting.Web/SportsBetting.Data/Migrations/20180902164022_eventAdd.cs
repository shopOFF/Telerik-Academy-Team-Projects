using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBetting.Data.Migrations
{
    public partial class eventAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cyclists");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 300, nullable: true),
                    OddsForFirstTeam = table.Column<double>(nullable: false),
                    OddsForDraw = table.Column<double>(nullable: false),
                    OddsForSecondTeam = table.Column<double>(nullable: false),
                    EventStartDate = table.Column<DateTime>(nullable: false),
                    IsEventPassed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Index_EventID",
                table: "Events",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "Index_IsEventPassed",
                table: "Events",
                column: "IsEventPassed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.CreateTable(
                name: "Cyclists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cyclists", x => x.Id);
                });
        }
    }
}
