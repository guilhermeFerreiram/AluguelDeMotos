using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelDeMotos.Migrations
{
    /// <inheritdoc />
    public partial class LocacaoAtivaParaEntregador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LocacaoAtiva",
                table: "Usuarios",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocacaoAtiva",
                table: "Usuarios");
        }
    }
}
