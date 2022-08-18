using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTNT1.Migrations
{
    public partial class Db_VTNT1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_FasesCafe",
                columns: table => new
                {
                    FaseCafeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verde = table.Column<int>(type: "int", nullable: false),
                    Amarelo = table.Column<int>(type: "int", nullable: false),
                    Maduro = table.Column<int>(type: "int", nullable: false),
                    Passando = table.Column<int>(type: "int", nullable: false),
                    Seco = table.Column<int>(type: "int", nullable: false),
                    PassagemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_FasesCafe", x => x.FaseCafeID);
                });

            migrationBuilder.CreateTable(
                name: "tb_PassagemsVTNT1",
                columns: table => new
                {
                    PassagemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distancia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaseCafeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PassagemsVTNT1", x => x.PassagemID);
                    table.ForeignKey(
                        name: "FK_tb_PassagemsVTNT1_tb_FasesCafe_FaseCafeID",
                        column: x => x.FaseCafeID,
                        principalTable: "tb_FasesCafe",
                        principalColumn: "FaseCafeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_PassagemsVTNT1_FaseCafeID",
                table: "tb_PassagemsVTNT1",
                column: "FaseCafeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_PassagemsVTNT1");

            migrationBuilder.DropTable(
                name: "tb_FasesCafe");
        }
    }
}
