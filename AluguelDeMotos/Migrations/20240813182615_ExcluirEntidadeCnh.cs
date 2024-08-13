using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AluguelDeMotos.Migrations
{
    /// <inheritdoc />
    public partial class ExcluirEntidadeCnh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cnhs_CnhId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cnhs");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CnhId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "CnhId",
                table: "Usuarios",
                newName: "TipoCnh");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Usuarios",
                type: "character varying(18)",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroCnh",
                table: "Usuarios",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Motos",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NumeroCnh",
                table: "Usuarios",
                column: "NumeroCnh",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_NumeroCnh",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NumeroCnh",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "TipoCnh",
                table: "Usuarios",
                newName: "CnhId");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(18)",
                oldMaxLength: 18,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Motos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8);

            migrationBuilder.CreateTable(
                name: "Cnhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnhs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CnhId",
                table: "Usuarios",
                column: "CnhId");

            migrationBuilder.CreateIndex(
                name: "IX_Cnhs_Numero",
                table: "Cnhs",
                column: "Numero",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cnhs_CnhId",
                table: "Usuarios",
                column: "CnhId",
                principalTable: "Cnhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
