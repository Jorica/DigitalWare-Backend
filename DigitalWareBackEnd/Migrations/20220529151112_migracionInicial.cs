using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalWareBackEnd.Migrations
{
    public partial class migracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.dni);
                });

                migrationBuilder.Sql("INSERT INTO personas (dni, nombre, apellido, edad, direccion) VALUES (1100852963, 'Javier','Perez',35,'CRA 9 # 7 - 89')");
                migrationBuilder.Sql("INSERT INTO personas (dni, nombre, apellido, edad, direccion) VALUES (1100147258, 'Carolina','Rodriguez',23,'CLL 12A # 1 - 32')");
                migrationBuilder.Sql("INSERT INTO personas (dni, nombre, apellido, edad, direccion) VALUES (1100987456, 'Alvaro','Sanchez',58,'CRA 6 # 12B - 42')");
                migrationBuilder.Sql("INSERT INTO personas (dni, nombre, apellido, edad, direccion) VALUES (1100123654, 'Dayana','Suarez',19,'CRA 21 # 2 - 32')");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    precioVenta = table.Column<int>(type: "int", nullable: false),
                    existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                });


                migrationBuilder.Sql("INSERT INTO productos (nombre, precioVenta, existencia) VALUES ('Jabón en polvo',3500,15)");
                migrationBuilder.Sql("INSERT INTO productos (nombre, precioVenta, existencia) VALUES ('Cloro 1000ml',4850,3)");
                migrationBuilder.Sql("INSERT INTO productos (nombre, precioVenta, existencia) VALUES ('Azúcar 500gr',2200,12)");
                migrationBuilder.Sql("INSERT INTO productos (nombre, precioVenta, existencia) VALUES ('Aceite Cocina 125cc',1800,9)");
                migrationBuilder.Sql("INSERT INTO productos (nombre, precioVenta, existencia) VALUES ('Gaseosa 1.5L',3200,5)");

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valorPagado = table.Column<int>(type: "int", nullable: false),
                    dniPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facturas_personas_dniPersona",
                        column: x => x.dniPersona,
                        principalTable: "personas",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false),
                    totalFactura = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    idFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detFactura_facturas_idFactura",
                        column: x => x.idFactura,
                        principalTable: "facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detFactura_productos_idProducto",
                        column: x => x.idProducto,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detFactura_idFactura",
                table: "detFactura",
                column: "idFactura");

            migrationBuilder.CreateIndex(
                name: "IX_detFactura_idProducto",
                table: "detFactura",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_dniPersona",
                table: "facturas",
                column: "dniPersona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detFactura");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
