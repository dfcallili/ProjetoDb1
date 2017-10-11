﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Rh.Data.Context.Ef;
using System;

namespace Rh.Data.Context.Migrations
{
    [DbContext(typeof(RhDbContext))]
    partial class RhDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Candidato", b =>
                {
                    b.Property<int>("CandidatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CandidatoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.HasKey("CandidatoId");

                    b.ToTable("Candidato","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmpresaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresa","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Entrevista", b =>
                {
                    b.Property<int>("EntrevistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EntrevistaId");

                    b.Property<int>("CandidatoId")
                        .HasColumnName("CandidatoId");

                    b.Property<DateTime>("DataEntrevista")
                        .HasColumnName("DataEntrevista");

                    b.Property<int>("VagaId");

                    b.HasKey("EntrevistaId");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("VagaId");

                    b.ToTable("Entrevista","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.EntrevistaTecnologia", b =>
                {
                    b.Property<int>("EntrevistaTecnologiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EntrevistaTecnologiaId");

                    b.Property<int>("EntrevistaId")
                        .HasColumnName("EntrevistaId");

                    b.Property<int?>("TecnologiaId");

                    b.Property<int>("VagaTecnologiaId");

                    b.HasKey("EntrevistaTecnologiaId");

                    b.HasIndex("EntrevistaId");

                    b.HasIndex("TecnologiaId");

                    b.HasIndex("VagaTecnologiaId");

                    b.ToTable("EntrevistaTecnologia","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Tecnologia", b =>
                {
                    b.Property<int>("TecnologiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TecnologiaId");

                    b.Property<int?>("EmpresaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.HasKey("TecnologiaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Tecnologia","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Vaga", b =>
                {
                    b.Property<int>("VagaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VagaId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasMaxLength(500);

                    b.Property<int?>("EmpresaId");

                    b.HasKey("VagaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Vaga","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.VagaTecnologia", b =>
                {
                    b.Property<int>("VagaTecnologiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VagaTecnologiaId");

                    b.Property<int?>("Peso")
                        .HasColumnName("Peso");

                    b.Property<int>("TecnologiaId")
                        .HasColumnName("TecnologiaId");

                    b.Property<int>("VagaId")
                        .HasColumnName("VagaId");

                    b.HasKey("VagaTecnologiaId");

                    b.HasIndex("TecnologiaId");

                    b.HasIndex("VagaId");

                    b.ToTable("VagaTecnologia","RhEntrevista");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Entrevista", b =>
                {
                    b.HasOne("Rh.Entities.RhEntrevista.Candidato", "Candidato")
                        .WithMany("ListaEntrevista")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rh.Entities.RhEntrevista.Vaga", "Vaga")
                        .WithMany("ListaEntrevista")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.EntrevistaTecnologia", b =>
                {
                    b.HasOne("Rh.Entities.RhEntrevista.Entrevista", "Entrevista")
                        .WithMany("ListaEntrevistaTecnologia")
                        .HasForeignKey("EntrevistaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Rh.Entities.RhEntrevista.Tecnologia")
                        .WithMany("ListaEntrevistaTecnologia")
                        .HasForeignKey("TecnologiaId");

                    b.HasOne("Rh.Entities.RhEntrevista.VagaTecnologia", "VagaTecnologia")
                        .WithMany("ListaEntrevistaTecnologia")
                        .HasForeignKey("VagaTecnologiaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Tecnologia", b =>
                {
                    b.HasOne("Rh.Entities.RhEntrevista.Empresa")
                        .WithMany("ListaTecnologia")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.Vaga", b =>
                {
                    b.HasOne("Rh.Entities.RhEntrevista.Empresa")
                        .WithMany("ListaVaga")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Rh.Entities.RhEntrevista.VagaTecnologia", b =>
                {
                    b.HasOne("Rh.Entities.RhEntrevista.Tecnologia", "Tecnologia")
                        .WithMany("ListaVagaTecnologia")
                        .HasForeignKey("TecnologiaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rh.Entities.RhEntrevista.Vaga", "Vaga")
                        .WithMany("ListaVagaTecnologia")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
