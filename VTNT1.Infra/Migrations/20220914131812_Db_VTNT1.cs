using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTNT1.Infra.Migrations
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
                    Vermelho = table.Column<int>(type: "int", nullable: false),
                    Marrom = table.Column<int>(type: "int", nullable: false),
                    Chumbinho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_FasesCafe", x => x.FaseCafeID);
                });

            migrationBuilder.CreateTable(
                name: "tb_RouteVTNT1",
                columns: table => new
                {
                    PassagemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distancia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaseCafeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_RouteVTNT1", x => x.PassagemID);
                    table.ForeignKey(
                        name: "FK_tb_RouteVTNT1_tb_FasesCafe_FaseCafeID",
                        column: x => x.FaseCafeID,
                        principalTable: "tb_FasesCafe",
                        principalColumn: "FaseCafeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_RouteVTNT1_FaseCafeID",
                table: "tb_RouteVTNT1",
                column: "FaseCafeID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_RouteVTNT1");

            migrationBuilder.DropTable(
                name: "tb_FasesCafe");
        }
    }
}
