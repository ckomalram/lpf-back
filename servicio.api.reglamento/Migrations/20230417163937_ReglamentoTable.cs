using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace servicio.api.reglamento.Migrations
{
    public partial class ReglamentoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reglamento",
                columns: table => new
                {
                    ReglamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reglamento", x => x.ReglamentoId);
                });

            migrationBuilder.InsertData(
                table: "Reglamento",
                columns: new[] { "ReglamentoId", "Descripcion", "DocumentoUrl", "Estado", "FechaCreado", "ImagenUrl", "Tipo", "Titulo" },
                values: new object[] { new Guid("71c87875-4439-4d7c-ba96-f8ba9136db03"), "Reglamento de ligra masculina de futbol lpf", "https://lpf.com.pa/wp-content/uploads/2023/01/REGLAMENTO-DE-COMPETENCIA-LPF-2023.pdf", 0, new DateTime(2023, 4, 17, 11, 39, 37, 290, DateTimeKind.Local).AddTicks(8104), "https://lpf.com.pa/wp-content/uploads/2023/01/REGLAMENTO-DE-COMPETENCIA-LPF-2023-791x1024.webp", 0, "LPF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reglamento");
        }
    }
}
