using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadeFYTrabalho.Migrations
{
    public partial class inicialProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Texto2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diferenca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frases");
        }
    }
}
