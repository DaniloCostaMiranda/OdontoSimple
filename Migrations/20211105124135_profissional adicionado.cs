using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoSimple.Migrations
{
    public partial class profissionaladicionado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tratamento_TratamentoRegister_TratamentoRegisterId",
                table: "Tratamento");

            migrationBuilder.DropTable(
                name: "TratamentoRegister");

            migrationBuilder.DropIndex(
                name: "IX_Tratamento_TratamentoRegisterId",
                table: "Tratamento");

            migrationBuilder.DropColumn(
                name: "TratamentoRegisterId",
                table: "Tratamento");

            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "Tratamento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_ProfissionalId",
                table: "Tratamento",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamento_Profissional_ProfissionalId",
                table: "Tratamento",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tratamento_Profissional_ProfissionalId",
                table: "Tratamento");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.DropIndex(
                name: "IX_Tratamento_ProfissionalId",
                table: "Tratamento");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "Tratamento");

            migrationBuilder.AddColumn<int>(
                name: "TratamentoRegisterId",
                table: "Tratamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TratamentoRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoRegister", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_TratamentoRegisterId",
                table: "Tratamento",
                column: "TratamentoRegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamento_TratamentoRegister_TratamentoRegisterId",
                table: "Tratamento",
                column: "TratamentoRegisterId",
                principalTable: "TratamentoRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
