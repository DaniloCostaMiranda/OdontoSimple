﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OdontoSimple.Migrations
{
    [DbContext(typeof(OdontoSimpleContext))]
    [Migration("20211205025734_denteprocedimento")]
    partial class denteprocedimento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("OdontoSimple.Models.DenteProcedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DenteId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedimentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DenteId");

                    b.HasIndex("ProcedimentId");

                    b.ToTable("DenteProcedimento");
                });

            modelBuilder.Entity("OdontoSimple.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(11) CHARACTER SET utf8mb4")
                        .HasMaxLength(11);

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
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DenteId");

                    b.ToTable("Procediment");
                });

            modelBuilder.Entity("OdontoSimple.Models.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11) CHARACTER SET utf8mb4")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("OdontoSimple.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusAtual")
                        .IsRequired()
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
                        .IsRequired()
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
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TipoServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfissionalId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("Tratamento");
                });

            modelBuilder.Entity("OdontoSimple.Models.TratamentoDente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DenteId")
                        .HasColumnType("int");

                    b.Property<int>("TratamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DenteId");

                    b.HasIndex("TratamentoId");

                    b.ToTable("TratamentoDente");
                });

            modelBuilder.Entity("OdontoSimple.Models.Dente", b =>
                {
                    b.HasOne("OdontoSimple.Models.Tratamento", null)
                        .WithMany("Dentes")
                        .HasForeignKey("TratamentoId");
                });

            modelBuilder.Entity("OdontoSimple.Models.DenteProcedimento", b =>
                {
                    b.HasOne("OdontoSimple.Models.Dente", "Dente")
                        .WithMany("DenteProcedimentos")
                        .HasForeignKey("DenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoSimple.Models.Procediment", "Procediment")
                        .WithMany("DenteProcedimentos")
                        .HasForeignKey("ProcedimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OdontoSimple.Models.Procediment", b =>
                {
                    b.HasOne("OdontoSimple.Models.Dente", null)
                        .WithMany("Procediments")
                        .HasForeignKey("DenteId");
                });

            modelBuilder.Entity("OdontoSimple.Models.Tratamento", b =>
                {
                    b.HasOne("OdontoSimple.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoSimple.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoSimple.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoSimple.Models.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("TipoServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OdontoSimple.Models.TratamentoDente", b =>
                {
                    b.HasOne("OdontoSimple.Models.Dente", "Dente")
                        .WithMany("TratamentoDentes")
                        .HasForeignKey("DenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoSimple.Models.Tratamento", "Tratamento")
                        .WithMany("TratamentoDentes")
                        .HasForeignKey("TratamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
