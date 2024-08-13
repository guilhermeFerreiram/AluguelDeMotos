using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelDeMotos.Migrations
{
    /// <inheritdoc />
    public partial class LocacaoTemUmUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_EntregadorId",
                table: "Locacoes");

            migrationBuilder.RenameColumn(
                name: "EntregadorId",
                table: "Locacoes",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_EntregadorId",
                table: "Locacoes",
                newName: "IX_Locacoes_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_UsuarioId",
                table: "Locacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_UsuarioId",
                table: "Locacoes");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Locacoes",
                newName: "EntregadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_UsuarioId",
                table: "Locacoes",
                newName: "IX_Locacoes_EntregadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_EntregadorId",
                table: "Locacoes",
                column: "EntregadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
