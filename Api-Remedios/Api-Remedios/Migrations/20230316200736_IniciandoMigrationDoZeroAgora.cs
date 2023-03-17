using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Remedios.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoMigrationDoZeroAgora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remedios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Codigo_ANS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_lote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vaga_lote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_deposito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_remedio = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<int>(type: "int", nullable: false),
                    Hora_Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Img_Remedio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_Bula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome_RegiaoId = table.Column<int>(type: "int", nullable: true),
                    Nome_UnidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remedios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remedios_Regiao_Nome_RegiaoId",
                        column: x => x.Nome_RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Remedios_Unidades_Nome_UnidadeId",
                        column: x => x.Nome_UnidadeId,
                        principalTable: "Unidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remedios_Nome_RegiaoId",
                table: "Remedios",
                column: "Nome_RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Remedios_Nome_UnidadeId",
                table: "Remedios",
                column: "Nome_UnidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remedios");

            migrationBuilder.DropTable(
                name: "Regiao");

            migrationBuilder.DropTable(
                name: "Unidades");
        }
    }
}
