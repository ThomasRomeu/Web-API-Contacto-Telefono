using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace thomasRomeu_PrimerParcial.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    IdContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.IdContacto);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    IdTelefono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false),
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.IdTelefono);
                    table.ForeignKey(
                        name: "FK_Telefonos_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "IdContacto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contactos",
                columns: new[] { "IdContacto", "Apellido", "Nombre", "NumeroDocumento", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "Ferez", "Ludmila", 42442367, "DNI" },
                    { 2, "Romeu", "Gianluca", 42567249, "DNI" },
                    { 3, "Romeu", "Joaquin", 43190425, "DNI" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "nombreUsuario", "password" },
                values: new object[] { 1, "tromeu", "4622" });

            migrationBuilder.InsertData(
                table: "Telefonos",
                columns: new[] { "IdTelefono", "ContactoId", "NumeroTelefono", "TipoTelefono" },
                values: new object[,]
                {
                    { 1, 1, 1125245672, "Celular" },
                    { 2, 2, 1125245672, "Celular" },
                    { 3, 3, 46228527, "Fijo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_ContactoId",
                table: "Telefonos",
                column: "ContactoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Contactos");
        }
    }
}
