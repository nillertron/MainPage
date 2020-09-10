using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAcces.Migrations
{
    public partial class messagebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "MS_FreelanceMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Headline = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Read = table.Column<bool>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: true),
                    SenderName = table.Column<string>(nullable: true),
                    SenderPhoneNumber = table.Column<string>(nullable: true),
                    MessageSent = table.Column<DateTime>(nullable: false),
                    FreelanceJobType = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    ClientLocation = table.Column<string>(nullable: true),
                    DeadLine = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_FreelanceMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MS_JobMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Headline = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Read = table.Column<bool>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: true),
                    SenderName = table.Column<string>(nullable: true),
                    SenderPhoneNumber = table.Column<string>(nullable: true),
                    MessageSent = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyCity = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_JobMessages", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MS_Picture_MS_Portfolio_MS_PortfolioId",
                table: "MS_Picture");

            migrationBuilder.DropTable(
                name: "MS_FreelanceMessages");

            migrationBuilder.DropTable(
                name: "MS_JobMessages");

            migrationBuilder.DropColumn(
                name: "FrontFoto",
                table: "MS_Picture");

            migrationBuilder.AddColumn<int>(
                name: "FrontFotoId",
                table: "MS_Portfolio",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MS_PortfolioId",
                table: "MS_Picture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "MS_Picture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MS_Portfolio_FrontFotoId",
                table: "MS_Portfolio",
                column: "FrontFotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MS_Picture_MS_Portfolio_MS_PortfolioId",
                table: "MS_Picture",
                column: "MS_PortfolioId",
                principalTable: "MS_Portfolio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MS_Portfolio_MS_Picture_FrontFotoId",
                table: "MS_Portfolio",
                column: "FrontFotoId",
                principalTable: "MS_Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
