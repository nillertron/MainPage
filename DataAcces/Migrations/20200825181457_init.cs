using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAcces.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MS_Competence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Kompetence = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_Competence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MS_Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    Beskrivelse = table.Column<string>(nullable: true),
                    Published = table.Column<DateTime>(nullable: false),
                    FrontFotoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_Portfolio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MS_Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PortfolioId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    MS_PortfolioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MS_Picture_MS_Portfolio_MS_PortfolioId",
                        column: x => x.MS_PortfolioId,
                        principalTable: "MS_Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MS_Picture_MS_PortfolioId",
                table: "MS_Picture",
                column: "MS_PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_MS_Portfolio_FrontFotoId",
                table: "MS_Portfolio",
                column: "FrontFotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MS_Portfolio_MS_Picture_FrontFotoId",
                table: "MS_Portfolio",
                column: "FrontFotoId",
                principalTable: "MS_Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MS_Picture_MS_Portfolio_MS_PortfolioId",
                table: "MS_Picture");

            migrationBuilder.DropTable(
                name: "MS_Competence");

            migrationBuilder.DropTable(
                name: "MS_Portfolio");

            migrationBuilder.DropTable(
                name: "MS_Picture");
        }
    }
}
