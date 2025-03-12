using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupermercadoBackend.Migrations
{
    /// <inheritdoc />
    public partial class FirebaseUid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Oferta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisponibleConPuntos = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DNI = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefonos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PuntosFidelizacion = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LocalidadId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FirebaseUid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefonos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cbu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CondicionIva = table.Column<int>(type: "int", nullable: false),
                    LocalidadId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detallescompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detallescompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detallescompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormaDePago = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detallesventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detallesventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detallesventas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detallesventas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "San Justo" },
                    { 2, false, "Videla" },
                    { 3, false, "Escalada" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "DisponibleConPuntos", "Eliminado", "Nombre", "Oferta", "Precio" },
                values: new object[,]
                {
                    { 1, true, false, "Coca Cola 2lts", false, 2650m },
                    { 2, false, false, "Sprite 2lts", false, 2450m },
                    { 3, false, false, "Fanta 2lts", false, 2550m }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "DNI", "Eliminado", "FechaNacimiento", "FirebaseUid", "LocalidadId", "Nombre", "PuntosFidelizacion", "Telefonos" },
                values: new object[,]
                {
                    { 1, "González", "44064814", false, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", 1, "Juan", 100, "123456789" },
                    { 2, "Pérez", "44064815", false, new DateTime(1986, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", 2, "Pedro", 200, "123456789" },
                    { 3, "Gómez", "44064816", false, new DateTime(1987, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", 3, "María", 300, "123456789" },
                    { 4, "Rodríguez", "44064817", false, new DateTime(1988, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", 1, "José", 400, "123456789" },
                    { 5, "Fernández", "44064818", false, new DateTime(1989, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", 2, "Ana", 500, "123456789" },
                    { 6, "López", "44064819", false, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", 3, "Carlos", 600, "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Detallescompras",
                columns: new[] { "Id", "Cantidad", "CompraId", "Eliminado", "PrecioUnitario", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 1, false, 2650m, 1 },
                    { 2, 2, 2, false, 2450m, 2 },
                    { 3, 1, 3, false, 2550m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "Cbu", "CondicionIva", "Direccion", "Eliminado", "LocalidadId", "Nombre", "Telefonos" },
                values: new object[,]
                {
                    { 1, "0000003100010000000001", 0, "Calle 1", false, 1, "Proveedor A", "111111111" },
                    { 2, "0000003100010000000002", 5, "Calle 2", false, 2, "Proveedor B", "222222222" },
                    { 3, "0000003100010000000003", 4, "Calle 3", false, 3, "Proveedor C", "333333333" },
                    { 4, "0000003100010000000004", 2, "Calle 4", false, 1, "Proveedor D", "444444444" },
                    { 5, "0000003100010000000005", 3, "Calle 5", false, 1, "Proveedor E", "555555555" },
                    { 6, "0000003100010000000006", 1, "Calle 6", false, 2, "Proveedor F", "666666666" },
                    { 7, "0000003100010000000007", 0, "Calle 7", false, 2, "Proveedor G", "777777777" },
                    { 8, "0000003100010000000008", 6, "Calle 8", false, 3, "Proveedor H", "888888888" },
                    { 9, "0000003100010000000009", 5, "Calle 9", false, 3, "Proveedor I", "999999999" },
                    { 10, "0000003100010000000010", 2, "Calle 10", false, 1, "Proveedor J", "101010101" }
                });

            migrationBuilder.InsertData(
                table: "Compras",
                columns: new[] { "Id", "Eliminado", "Fecha", "FormaDePago", "Iva", "ProveedorId", "Total" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 21, 1, 1000 },
                    { 2, false, new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, 2, 2000 },
                    { 3, false, new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 3, 3000 },
                    { 4, false, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 4, 4000 }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "ClienteId", "Eliminado", "Fecha", "FormaPago", "Iva", "Total" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2025, 3, 12, 5, 41, 50, 436, DateTimeKind.Local).AddTicks(2989), 0, 21m, 3000m },
                    { 2, 2, false, new DateTime(2025, 3, 12, 5, 41, 50, 436, DateTimeKind.Local).AddTicks(3004), 1, 10m, 5000m },
                    { 3, 1, false, new DateTime(2025, 3, 12, 5, 41, 50, 436, DateTimeKind.Local).AddTicks(3006), 2, 21m, 8000m }
                });

            migrationBuilder.InsertData(
                table: "Detallesventas",
                columns: new[] { "Id", "Cantidad", "Eliminado", "PrecioUnitario", "ProductoId", "VentaId" },
                values: new object[,]
                {
                    { 1, 1, false, 2650m, 1, 1 },
                    { 2, 2, false, 2450m, 2, 2 },
                    { 3, 1, false, 2550m, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadId",
                table: "Clientes",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Detallescompras_ProductoId",
                table: "Detallescompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detallesventas_ProductoId",
                table: "Detallesventas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detallesventas_VentaId",
                table: "Detallesventas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_LocalidadId",
                table: "Proveedores",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Detallescompras");

            migrationBuilder.DropTable(
                name: "Detallesventas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Localidades");
        }
    }
}
