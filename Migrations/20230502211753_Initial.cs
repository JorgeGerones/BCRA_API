using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCRA_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Operatoria = table.Column<string>(type: "TEXT", nullable: false),
                    Transaccion = table.Column<string>(type: "TEXT", nullable: false),
                    EntidadDeudora = table.Column<int>(type: "INTEGER", nullable: false),
                    CuentaDeudora = table.Column<int>(type: "INTEGER", nullable: false),
                    EntidadAcreedora = table.Column<int>(type: "INTEGER", nullable: false),
                    CuentaAcreedora = table.Column<int>(type: "INTEGER", nullable: false),
                    Importe = table.Column<float>(type: "REAL", nullable: false),
                    InstruccionDePago = table.Column<string>(type: "TEXT", nullable: false),
                    FechaProcesado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumeroInterno = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");
        }
    }
}
