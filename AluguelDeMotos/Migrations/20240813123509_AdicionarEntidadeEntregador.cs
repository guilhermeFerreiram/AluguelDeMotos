using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AluguelDeMotos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarEntidadeEntregador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CnhId",
                table: "Usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Usuarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                table: "Usuarios",
                type: "timestamp with time zone",
                nullable: true);

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
                    Numero = table.Column<int>(type: "integer", nullable: false),
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
                name: "IX_Usuarios_Cnpj",
                table: "Usuarios",
                column: "Cnpj",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cnhs_CnhId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cnhs");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CnhId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Cnpj",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CnhId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Motos",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
