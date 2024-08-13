﻿// <auto-generated />
using System;
using AluguelDeMotos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AluguelDeMotos.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AluguelDeMotos.Models.LocacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataLocacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EntregadorId")
                        .HasColumnType("integer");

                    b.Property<int>("MotoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntregadorId")
                        .IsUnique();

                    b.HasIndex("MotoId")
                        .IsUnique();

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("AluguelDeMotos.Models.MotoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Alugada")
                        .HasColumnType("boolean");

                    b.Property<int>("Ano")
                        .HasColumnType("integer");

                    b.Property<int>("Modelo")
                        .HasColumnType("integer");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.HasKey("Id");

                    b.HasIndex("Placa")
                        .IsUnique();

                    b.ToTable("Motos");
                });

            modelBuilder.Entity("AluguelDeMotos.Models.Usuarios.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator().HasValue("UsuarioModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AluguelDeMotos.Models.Usuarios.AdminModel", b =>
                {
                    b.HasBaseType("AluguelDeMotos.Models.Usuarios.UsuarioModel");

                    b.HasDiscriminator().HasValue("AdminModel");
                });

            modelBuilder.Entity("AluguelDeMotos.Models.Usuarios.EntregadorModel", b =>
                {
                    b.HasBaseType("AluguelDeMotos.Models.Usuarios.UsuarioModel");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumeroCnh")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int>("TipoCnh")
                        .HasColumnType("integer");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.HasIndex("NumeroCnh")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("EntregadorModel");
                });

            modelBuilder.Entity("AluguelDeMotos.Models.LocacaoModel", b =>
                {
                    b.HasOne("AluguelDeMotos.Models.Usuarios.EntregadorModel", "Entregador")
                        .WithOne("Locacao")
                        .HasForeignKey("AluguelDeMotos.Models.LocacaoModel", "EntregadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AluguelDeMotos.Models.MotoModel", "Moto")
                        .WithOne("Locacao")
                        .HasForeignKey("AluguelDeMotos.Models.LocacaoModel", "MotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entregador");

                    b.Navigation("Moto");
                });

            modelBuilder.Entity("AluguelDeMotos.Models.MotoModel", b =>
                {
                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("AluguelDeMotos.Models.Usuarios.EntregadorModel", b =>
                {
                    b.Navigation("Locacao");
                });
#pragma warning restore 612, 618
        }
    }
}
