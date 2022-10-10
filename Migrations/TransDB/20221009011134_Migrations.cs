using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nft_project.Migrations.TransDB
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trans",
                columns: table => new
                {
                    trans_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    account_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    is_nft_trans = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans", x => x.trans_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trans");
        }
    }
}
