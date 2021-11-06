using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoSimple.Migrations
{
    public partial class Listaconsultas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Medicamentos",
                table: "Tratamento",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TratamentoRegisterId",
                table: "Tratamento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TratamentoRegister",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Medicamentos",
                table: "Tratamento",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);
        }
    }
}
