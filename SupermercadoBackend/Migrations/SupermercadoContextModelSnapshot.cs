﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupermercadoBackend.DataContext;

#nullable disable

namespace SupermercadoBackend.Migrations
{
    [DbContext(typeof(SupermercadoContext))]
    partial class SupermercadoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SupermercadoServices.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirebaseUid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("LocalidadId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PuntosFidelizacion")
                        .HasColumnType("int");

                    b.Property<string>("Telefonos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "González",
                            DNI = "44064814",
                            Eliminado = false,
                            FechaNacimiento = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirebaseUid = "123456789",
                            LocalidadId = 1,
                            Nombre = "Juan",
                            PuntosFidelizacion = 100,
                            Telefonos = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Pérez",
                            DNI = "44064815",
                            Eliminado = false,
                            FechaNacimiento = new DateTime(1986, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirebaseUid = "123456789",
                            LocalidadId = 2,
                            Nombre = "Pedro",
                            PuntosFidelizacion = 200,
                            Telefonos = "123456789"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Gómez",
                            DNI = "44064816",
                            Eliminado = false,
                            FechaNacimiento = new DateTime(1987, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirebaseUid = "123456789",
                            LocalidadId = 3,
                            Nombre = "María",
                            PuntosFidelizacion = 300,
                            Telefonos = "123456789"
                        },
                        new
                        {
                            Id = 4,
                            Apellido = "Rodríguez",
                            DNI = "44064817",
                            Eliminado = false,
                            FechaNacimiento = new DateTime(1988, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirebaseUid = "123456789",
                            LocalidadId = 1,
                            Nombre = "José",
                            PuntosFidelizacion = 400,
                            Telefonos = "123456789"
                        },
                        new
                        {
                            Id = 5,
                            Apellido = "Fernández",
                            DNI = "44064818",
                            Eliminado = false,
                            FechaNacimiento = new DateTime(1989, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirebaseUid = "123456789",
                            LocalidadId = 2,
                            Nombre = "Ana",
                            PuntosFidelizacion = 500,
                            Telefonos = "123456789"
                        },
                        new
                        {
                            Id = 6,
                            Apellido = "López",
                            DNI = "44064819",
                            Eliminado = false,
                            FechaNacimiento = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirebaseUid = "123456789",
                            LocalidadId = 3,
                            Nombre = "Carlos",
                            PuntosFidelizacion = 600,
                            Telefonos = "123456789"
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FormaDePago")
                        .HasColumnType("int");

                    b.Property<int>("Iva")
                        .HasColumnType("int");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eliminado = false,
                            Fecha = new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormaDePago = 0,
                            Iva = 21,
                            ProveedorId = 1,
                            Total = 1000
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Fecha = new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormaDePago = 1,
                            Iva = 10,
                            ProveedorId = 2,
                            Total = 2000
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Fecha = new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormaDePago = 2,
                            Iva = 5,
                            ProveedorId = 3,
                            Total = 3000
                        },
                        new
                        {
                            Id = 4,
                            Eliminado = false,
                            Fecha = new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormaDePago = 0,
                            Iva = 0,
                            ProveedorId = 4,
                            Total = 4000
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.DetalleCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("Detallescompras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 1,
                            CompraId = 1,
                            Eliminado = false,
                            PrecioUnitario = 2650m,
                            ProductoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 2,
                            CompraId = 2,
                            Eliminado = false,
                            PrecioUnitario = 2450m,
                            ProductoId = 2
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = 1,
                            CompraId = 3,
                            Eliminado = false,
                            PrecioUnitario = 2550m,
                            ProductoId = 3
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("Detallesventas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 1,
                            Eliminado = false,
                            PrecioUnitario = 2650m,
                            ProductoId = 1,
                            VentaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 2,
                            Eliminado = false,
                            PrecioUnitario = 2450m,
                            ProductoId = 2,
                            VentaId = 2
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = 1,
                            Eliminado = false,
                            PrecioUnitario = 2550m,
                            ProductoId = 3,
                            VentaId = 3
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.Localidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Localidades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Eliminado = false,
                            Nombre = "San Justo"
                        },
                        new
                        {
                            Id = 2,
                            Eliminado = false,
                            Nombre = "Videla"
                        },
                        new
                        {
                            Id = 3,
                            Eliminado = false,
                            Nombre = "Escalada"
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("DisponibleConPuntos")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Oferta")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisponibleConPuntos = true,
                            Eliminado = false,
                            Nombre = "Coca Cola 2lts",
                            Oferta = false,
                            Precio = 2650m
                        },
                        new
                        {
                            Id = 2,
                            DisponibleConPuntos = false,
                            Eliminado = false,
                            Nombre = "Sprite 2lts",
                            Oferta = false,
                            Precio = 2450m
                        },
                        new
                        {
                            Id = 3,
                            DisponibleConPuntos = false,
                            Eliminado = false,
                            Nombre = "Fanta 2lts",
                            Oferta = false,
                            Precio = 2550m
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cbu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CondicionIva")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("LocalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefonos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadId");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cbu = "0000003100010000000001",
                            CondicionIva = 0,
                            Direccion = "Calle 1",
                            Eliminado = false,
                            LocalidadId = 1,
                            Nombre = "Proveedor A",
                            Telefonos = "111111111"
                        },
                        new
                        {
                            Id = 2,
                            Cbu = "0000003100010000000002",
                            CondicionIva = 5,
                            Direccion = "Calle 2",
                            Eliminado = false,
                            LocalidadId = 2,
                            Nombre = "Proveedor B",
                            Telefonos = "222222222"
                        },
                        new
                        {
                            Id = 3,
                            Cbu = "0000003100010000000003",
                            CondicionIva = 4,
                            Direccion = "Calle 3",
                            Eliminado = false,
                            LocalidadId = 3,
                            Nombre = "Proveedor C",
                            Telefonos = "333333333"
                        },
                        new
                        {
                            Id = 4,
                            Cbu = "0000003100010000000004",
                            CondicionIva = 2,
                            Direccion = "Calle 4",
                            Eliminado = false,
                            LocalidadId = 1,
                            Nombre = "Proveedor D",
                            Telefonos = "444444444"
                        },
                        new
                        {
                            Id = 5,
                            Cbu = "0000003100010000000005",
                            CondicionIva = 3,
                            Direccion = "Calle 5",
                            Eliminado = false,
                            LocalidadId = 1,
                            Nombre = "Proveedor E",
                            Telefonos = "555555555"
                        },
                        new
                        {
                            Id = 6,
                            Cbu = "0000003100010000000006",
                            CondicionIva = 1,
                            Direccion = "Calle 6",
                            Eliminado = false,
                            LocalidadId = 2,
                            Nombre = "Proveedor F",
                            Telefonos = "666666666"
                        },
                        new
                        {
                            Id = 7,
                            Cbu = "0000003100010000000007",
                            CondicionIva = 0,
                            Direccion = "Calle 7",
                            Eliminado = false,
                            LocalidadId = 2,
                            Nombre = "Proveedor G",
                            Telefonos = "777777777"
                        },
                        new
                        {
                            Id = 8,
                            Cbu = "0000003100010000000008",
                            CondicionIva = 6,
                            Direccion = "Calle 8",
                            Eliminado = false,
                            LocalidadId = 3,
                            Nombre = "Proveedor H",
                            Telefonos = "888888888"
                        },
                        new
                        {
                            Id = 9,
                            Cbu = "0000003100010000000009",
                            CondicionIva = 5,
                            Direccion = "Calle 9",
                            Eliminado = false,
                            LocalidadId = 3,
                            Nombre = "Proveedor I",
                            Telefonos = "999999999"
                        },
                        new
                        {
                            Id = 10,
                            Cbu = "0000003100010000000010",
                            CondicionIva = 2,
                            Direccion = "Calle 10",
                            Eliminado = false,
                            LocalidadId = 1,
                            Nombre = "Proveedor J",
                            Telefonos = "101010101"
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FormaPago")
                        .HasColumnType("int");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            Eliminado = false,
                            Fecha = new DateTime(2025, 3, 12, 5, 41, 50, 436, DateTimeKind.Local).AddTicks(2989),
                            FormaPago = 0,
                            Iva = 21m,
                            Total = 3000m
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 2,
                            Eliminado = false,
                            Fecha = new DateTime(2025, 3, 12, 5, 41, 50, 436, DateTimeKind.Local).AddTicks(3004),
                            FormaPago = 1,
                            Iva = 10m,
                            Total = 5000m
                        },
                        new
                        {
                            Id = 3,
                            ClienteId = 1,
                            Eliminado = false,
                            Fecha = new DateTime(2025, 3, 12, 5, 41, 50, 436, DateTimeKind.Local).AddTicks(3006),
                            FormaPago = 2,
                            Iva = 21m,
                            Total = 8000m
                        });
                });

            modelBuilder.Entity("SupermercadoServices.Models.Cliente", b =>
                {
                    b.HasOne("SupermercadoServices.Models.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localidad");
                });

            modelBuilder.Entity("SupermercadoServices.Models.Compra", b =>
                {
                    b.HasOne("SupermercadoServices.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("SupermercadoServices.Models.DetalleCompra", b =>
                {
                    b.HasOne("SupermercadoServices.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("SupermercadoServices.Models.DetalleVenta", b =>
                {
                    b.HasOne("SupermercadoServices.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupermercadoServices.Models.Venta", "Venta")
                        .WithMany("DetallesVenta")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("SupermercadoServices.Models.Proveedor", b =>
                {
                    b.HasOne("SupermercadoServices.Models.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadId");

                    b.Navigation("Localidad");
                });

            modelBuilder.Entity("SupermercadoServices.Models.Venta", b =>
                {
                    b.HasOne("SupermercadoServices.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SupermercadoServices.Models.Venta", b =>
                {
                    b.Navigation("DetallesVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
