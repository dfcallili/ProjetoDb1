using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rh.Data.Context.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RhEntrevista");

            migrationBuilder.CreateTable(
                name: "Candidato",
                schema: "RhEntrevista",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.CandidatoId);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "RhEntrevista",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Tecnologia",
                schema: "RhEntrevista",
                columns: table => new
                {
                    TecnologiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologia", x => x.TecnologiaId);
                    table.ForeignKey(
                        name: "FK_Tecnologia_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                schema: "RhEntrevista",
                columns: table => new
                {
                    VagaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.VagaId);
                    table.ForeignKey(
                        name: "FK_Vaga_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entrevista",
                schema: "RhEntrevista",
                columns: table => new
                {
                    EntrevistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    DataEntrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VagaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrevista", x => x.EntrevistaId);
                    table.ForeignKey(
                        name: "FK_Entrevista_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Candidato",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrevista_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Vaga",
                        principalColumn: "VagaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VagaTecnologia",
                schema: "RhEntrevista",
                columns: table => new
                {
                    VagaTecnologiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Peso = table.Column<int>(type: "int", nullable: true),
                    TecnologiaId = table.Column<int>(type: "int", nullable: false),
                    VagaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaTecnologia", x => x.VagaTecnologiaId);
                    table.ForeignKey(
                        name: "FK_VagaTecnologia_Tecnologia_TecnologiaId",
                        column: x => x.TecnologiaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Tecnologia",
                        principalColumn: "TecnologiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagaTecnologia_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Vaga",
                        principalColumn: "VagaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntrevistaTecnologia",
                schema: "RhEntrevista",
                columns: table => new
                {
                    EntrevistaTecnologiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntrevistaId = table.Column<int>(type: "int", nullable: false),
                    TecnologiaId = table.Column<int>(type: "int", nullable: true),
                    VagaTecnologiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrevistaTecnologia", x => x.EntrevistaTecnologiaId);
                    table.ForeignKey(
                        name: "FK_EntrevistaTecnologia_Entrevista_EntrevistaId",
                        column: x => x.EntrevistaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Entrevista",
                        principalColumn: "EntrevistaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntrevistaTecnologia_Tecnologia_TecnologiaId",
                        column: x => x.TecnologiaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "Tecnologia",
                        principalColumn: "TecnologiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntrevistaTecnologia_VagaTecnologia_VagaTecnologiaId",
                        column: x => x.VagaTecnologiaId,
                        principalSchema: "RhEntrevista",
                        principalTable: "VagaTecnologia",
                        principalColumn: "VagaTecnologiaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_CandidatoId",
                schema: "RhEntrevista",
                table: "Entrevista",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_VagaId",
                schema: "RhEntrevista",
                table: "Entrevista",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrevistaTecnologia_EntrevistaId",
                schema: "RhEntrevista",
                table: "EntrevistaTecnologia",
                column: "EntrevistaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrevistaTecnologia_TecnologiaId",
                schema: "RhEntrevista",
                table: "EntrevistaTecnologia",
                column: "TecnologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrevistaTecnologia_VagaTecnologiaId",
                schema: "RhEntrevista",
                table: "EntrevistaTecnologia",
                column: "VagaTecnologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnologia_EmpresaId",
                schema: "RhEntrevista",
                table: "Tecnologia",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_EmpresaId",
                schema: "RhEntrevista",
                table: "Vaga",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologia_TecnologiaId",
                schema: "RhEntrevista",
                table: "VagaTecnologia",
                column: "TecnologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologia_VagaId",
                schema: "RhEntrevista",
                table: "VagaTecnologia",
                column: "VagaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntrevistaTecnologia",
                schema: "RhEntrevista");

            migrationBuilder.DropTable(
                name: "Entrevista",
                schema: "RhEntrevista");

            migrationBuilder.DropTable(
                name: "VagaTecnologia",
                schema: "RhEntrevista");

            migrationBuilder.DropTable(
                name: "Candidato",
                schema: "RhEntrevista");

            migrationBuilder.DropTable(
                name: "Tecnologia",
                schema: "RhEntrevista");

            migrationBuilder.DropTable(
                name: "Vaga",
                schema: "RhEntrevista");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "RhEntrevista");
        }
    }
}
