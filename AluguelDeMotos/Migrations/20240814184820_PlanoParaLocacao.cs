using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelDeMotos.Migrations
{
    /// <inheritdoc />
    public partial class PlanoParaLocacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLocacao",
                table: "Locacoes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDevolucao",
                table: "Locacoes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Multa",
                table: "Locacoes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Plano",
                table: "Locacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrevisaoDevolucao",
                table: "Locacoes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPorDia",
                table: "Locacoes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Locacoes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Multa",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "Plano",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "PrevisaoDevolucao",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "ValorPorDia",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Locacoes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLocacao",
                table: "Locacoes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDevolucao",
                table: "Locacoes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
