﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OdontoSimple.Migrations
{
    [DbContext(typeof(OdontoSimpleContext))]
    partial class OdontoSimpleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OdontoSimple.Models.Dente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int?>("TratamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TratamentoId");

                    b.ToTable("Dente");
                });

            modelBuilder.Entity("OdontoSimple.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("OdontoSimple.Models.Procediment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DenteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DenteId");

                    b.HasIndex("StatusId");

                    b.ToTable("Procediment");
                });

            modelBuilder.Entity("OdontoSimple.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusAtual")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("OdontoSimple.Models.TipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TipoServico");
                });

            modelBuilder.Entity("OdontoSimple.Models.Tratamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Exames")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Medicamentos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("Tratamento");
                });

            modelBuilder.Entity("OdontoSimple.Models.Dente", b =>
                {
                    b.HasOne("OdontoSimple.Models.Tratamento", null)
                        .WithMany("Dentes")
                        .HasForeignKey("TratamentoId");
                });

            modelBuilder.Entity("OdontoSimple.Models.Procediment", b =>
                {
                    b.HasOne("OdontoSimple.Models.Dente", null)
                        .WithMany("Procediments")
                        .HasForeignKey("DenteId");

                    b.HasOne("OdontoSimple.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("OdontoSimple.Models.Tratamento", b =>
                {
                    b.HasOne("OdontoSimple.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.HasOne("OdontoSimple.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("OdontoSimple.Models.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("TipoServicoId");
                });
#pragma warning restore 612, 618
        }
    }
}