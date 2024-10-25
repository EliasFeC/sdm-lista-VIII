using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblioteca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    inicio_funcionamento = table.Column<string>(type: "TEXT", nullable: true),
                    fim_funcionamento = table.Column<string>(type: "TEXT", nullable: true),
                    inauguracao = table.Column<string>(type: "TEXT", nullable: true),
                    contato = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biblioteca");
        }
    }
}
