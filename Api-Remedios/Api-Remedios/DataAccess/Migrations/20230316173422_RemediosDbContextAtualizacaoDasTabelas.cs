using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Remedios.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemediosDbContextAtualizacaoDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Remedios",
                newName: "Vaga_lote");

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Remedios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Codigo_ANS",
                table: "Remedios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cor",
                table: "Remedios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_deposito",
                table: "Remedios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_lote",
                table: "Remedios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Img_Remedio",
                table: "Remedios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nome_RegiaoId",
                table: "Remedios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nome_UnidadeId",
                table: "Remedios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_remedio",
                table: "Remedios",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Remedios_Nome_RegiaoId",
                table: "Remedios",
                column: "Nome_RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Remedios_Nome_UnidadeId",
                table: "Remedios",
                column: "Nome_UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remedios_Regiao_Nome_RegiaoId",
                table: "Remedios",
                column: "Nome_RegiaoId",
                principalTable: "Regiao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Remedios_Unidades_Nome_UnidadeId",
                table: "Remedios",
                column: "Nome_UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remedios_Regiao_Nome_RegiaoId",
                table: "Remedios");

            migrationBuilder.DropForeignKey(
                name: "FK_Remedios_Unidades_Nome_UnidadeId",
                table: "Remedios");

            migrationBuilder.DropTable(
                name: "Regiao");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Remedios_Nome_RegiaoId",
                table: "Remedios");

            migrationBuilder.DropIndex(
                name: "IX_Remedios_Nome_UnidadeId",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Codigo_ANS",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Data_deposito",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Data_lote",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Img_Remedio",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Nome_RegiaoId",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Nome_UnidadeId",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "Tipo_remedio",
                table: "Remedios");

            migrationBuilder.RenameColumn(
                name: "Vaga_lote",
                table: "Remedios",
                newName: "Descricao");
        }
    }
}
