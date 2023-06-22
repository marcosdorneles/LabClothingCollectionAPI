using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabClothingCollectionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orcamento = table.Column<double>(type: "float", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estacao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colecao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    LayoutModelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusUsuario = table.Column<int>(type: "int", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColecaoModelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColecaoId = table.Column<int>(type: "int", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColecaoModelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColecaoModelo_Colecao_ColecaoId",
                        column: x => x.ColecaoId,
                        principalTable: "Colecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColecaoModelo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioColecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ColecaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioColecao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioColecao_Colecao_ColecaoId",
                        column: x => x.ColecaoId,
                        principalTable: "Colecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioColecao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataNascimento", "Genero", "Nome", "StatusUsuario", "Telefone", "TipoUsuario", "cpf", "email" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Marcos Guilherme", 1, "111111111", 0, "11111111111", "email@teste.com" },
                    { 2, new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Maria Silva", 1, "222222222", 2, "22222222222", "maria@teste.com" },
                    { 3, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "João Santos", 2, "333333333", 1, "33333333333", "joao@teste.com" },
                    { 4, new DateTime(1995, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Ana Oliveira", 1, "444444444", 1, "44444444444", "ana@teste.com" },
                    { 5, new DateTime(1998, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Lucas Almeida", 2, "555555555", 3, "55555555555", "lucas@teste.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColecaoModelo_ColecaoId",
                table: "ColecaoModelo",
                column: "ColecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColecaoModelo_ModeloId",
                table: "ColecaoModelo",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioColecao_ColecaoId",
                table: "UsuarioColecao",
                column: "ColecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioColecao_UsuarioId",
                table: "UsuarioColecao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColecaoModelo");

            migrationBuilder.DropTable(
                name: "UsuarioColecao");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Colecao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
