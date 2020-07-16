using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OperacaoBancaria.Infra.Data.Migrations
{
    public partial class OperacaoBancaria_Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroConta = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoOperacao = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    ContaCorrenteId = table.Column<Guid>(nullable: false),
                    DataLancamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContaCorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "ContaCorrente");
        }
    }
}
