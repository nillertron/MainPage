using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAcces.Migrations
{
    public partial class polymorf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MS_FreelanceMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MS_JobMessages",
                table: "MS_JobMessages");

            migrationBuilder.RenameTable(
                name: "MS_JobMessages",
                newName: "MS_Messages");

            migrationBuilder.AddColumn<double>(
                name: "Budget",
                table: "MS_Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientLocation",
                table: "MS_Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "MS_Messages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadLine",
                table: "MS_Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreelanceJobType",
                table: "MS_Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MS_Messages",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MS_Messages",
                table: "MS_Messages",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MS_Messages",
                table: "MS_Messages");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "MS_Messages");

            migrationBuilder.DropColumn(
                name: "ClientLocation",
                table: "MS_Messages");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "MS_Messages");

            migrationBuilder.DropColumn(
                name: "DeadLine",
                table: "MS_Messages");

            migrationBuilder.DropColumn(
                name: "FreelanceJobType",
                table: "MS_Messages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MS_Messages");

            migrationBuilder.RenameTable(
                name: "MS_Messages",
                newName: "MS_JobMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MS_JobMessages",
                table: "MS_JobMessages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MS_FreelanceMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Budget = table.Column<double>(type: "double", nullable: false),
                    ClientLocation = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime", nullable: false),
                    FreelanceJobType = table.Column<string>(type: "text", nullable: true),
                    Headline = table.Column<string>(type: "text", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "datetime", nullable: false),
                    Read = table.Column<short>(type: "bit", nullable: false),
                    SenderEmail = table.Column<string>(type: "text", nullable: true),
                    SenderName = table.Column<string>(type: "text", nullable: true),
                    SenderPhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MS_FreelanceMessages", x => x.Id);
                });
        }
    }
}
