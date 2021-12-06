using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoSimple.Migrations
{
    public partial class denteprocedimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procediment_Tratamento_TratamentoId",
                table: "Procediment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tratamento_Dente_DenteId",
                table: "Tratamento");

            migrationBuilder.DropTable(
                name: "TratamentoProcedimento");

            migrationBuilder.DropIndex(
                name: "IX_Tratamento_DenteId",
                table: "Tratamento");

            migrationBuilder.DropIndex(
                name: "IX_Procediment_TratamentoId",
                table: "Procediment");

            migrationBuilder.DropColumn(
                name: "DenteId",
                table: "Tratamento");

            migrationBuilder.DropColumn(
                name: "TratamentoId",
                table: "Procediment");

            migrationBuilder.AddColumn<int>(
                name: "DenteId",
                table: "Procediment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TratamentoId",
                table: "Dente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DenteProcedimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DenteId = table.Column<int>(nullable: false),
                    ProcedimentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenteProcedimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenteProcedimento_Dente_DenteId",
                        column: x => x.DenteId,
                        principalTable: "Dente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DenteProcedimento_Procediment_ProcedimentId",
                        column: x => x.ProcedimentId,
                        principalTable: "Procediment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TratamentoDente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TratamentoId = table.Column<int>(nullable: false),
                    DenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoDente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentoDente_Dente_DenteId",
                        column: x => x.DenteId,
                        principalTable: "Dente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamentoDente_Tratamento_TratamentoId",
                        column: x => x.TratamentoId,
                        principalTable: "Tratamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procediment_DenteId",
                table: "Procediment",
                column: "DenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Dente_TratamentoId",
                table: "Dente",
                column: "TratamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DenteProcedimento_DenteId",
                table: "DenteProcedimento",
                column: "DenteId");

            migrationBuilder.CreateIndex(
                name: "IX_DenteProcedimento_ProcedimentId",
                table: "DenteProcedimento",
                column: "ProcedimentId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoDente_DenteId",
                table: "TratamentoDente",
                column: "DenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoDente_TratamentoId",
                table: "TratamentoDente",
                column: "TratamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dente_Tratamento_TratamentoId",
                table: "Dente",
                column: "TratamentoId",
                principalTable: "Tratamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Procediment_Dente_DenteId",
                table: "Procediment",
                column: "DenteId",
                principalTable: "Dente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dente_Tratamento_TratamentoId",
                table: "Dente");

            migrationBuilder.DropForeignKey(
                name: "FK_Procediment_Dente_DenteId",
                table: "Procediment");

            migrationBuilder.DropTable(
                name: "DenteProcedimento");

            migrationBuilder.DropTable(
                name: "TratamentoDente");

            migrationBuilder.DropIndex(
                name: "IX_Procediment_DenteId",
                table: "Procediment");

            migrationBuilder.DropIndex(
                name: "IX_Dente_TratamentoId",
                table: "Dente");

            migrationBuilder.DropColumn(
                name: "DenteId",
                table: "Procediment");

            migrationBuilder.DropColumn(
                name: "TratamentoId",
                table: "Dente");

            migrationBuilder.AddColumn<int>(
                name: "DenteId",
                table: "Tratamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TratamentoId",
                table: "Procediment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TratamentoProcedimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProcedimentId = table.Column<int>(type: "int", nullable: false),
                    TratamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoProcedimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentoProcedimento_Procediment_ProcedimentId",
                        column: x => x.ProcedimentId,
                        principalTable: "Procediment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamentoProcedimento_Tratamento_TratamentoId",
                        column: x => x.TratamentoId,
                        principalTable: "Tratamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_DenteId",
                table: "Tratamento",
                column: "DenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Procediment_TratamentoId",
                table: "Procediment",
                column: "TratamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoProcedimento_ProcedimentId",
                table: "TratamentoProcedimento",
                column: "ProcedimentId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoProcedimento_TratamentoId",
                table: "TratamentoProcedimento",
                column: "TratamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procediment_Tratamento_TratamentoId",
                table: "Procediment",
                column: "TratamentoId",
                principalTable: "Tratamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamento_Dente_DenteId",
                table: "Tratamento",
                column: "DenteId",
                principalTable: "Dente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
