﻿// <auto-generated />
using System;
using APIProductos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIProductos.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIProductos.Models.Eventos", b =>
                {
                    b.Property<int>("idEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEvento"));

                    b.Property<string>("DescripcionEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expositores")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("No especificado");

                    b.Property<string>("NombreEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("diaEvento")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("horaEvento")
                        .HasColumnType("time");

                    b.HasKey("idEvento");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            idEvento = 1,
                            DescripcionEvento = "Un evento donde los estudiantes terminan clases, antes de descubrir si han aprobado o reprobado el semestre.",
                            NombreEvento = "Fin Clases Semestre",
                            diaEvento = new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            horaEvento = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            idEvento = 2,
                            DescripcionEvento = "Concierto de la agrupación mexicana Camila, una banda referente de la música pop en Latinoamérica. Mario Domm, Pablo Hurtado y Samo tienen el propósito de llevar un mensaje de amor a todo tipo de público, sin limitarse por las modas o exigencias que determina el mercado.",
                            Expositores = "Camila",
                            NombreEvento = "Concierto Camila",
                            diaEvento = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            horaEvento = new TimeSpan(0, 20, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("APIProductos.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            IdProducto = 1,
                            Autor = "Sarah J. Maas",
                            Cantidad = 20,
                            Descripcion = "Cuando la cazadora de diecinueve años de edad, Feyre, mata a un lobo el el bosque, una criatura parecida a una bestia llega para exigir venganza. Arrastrada a una traicionera tierra mágica que solo conoce de leyendas, Feyre descubre que su captor no es un animal, sino Tamlin, una de las letales e inmortales hadas que una vez gobernaron su mundo.\nA medida que ella vive en su estado, sus sentimientos por Tamlin se transforman de una hostilidad helada a una pasión que quema a pesar de todas las mentiras y las advertencias que se le han hecho sobre el hermoso y peligroso mundo de las hadas. Pero una antigua y malvada sombre crece sobre las tierras feéricas, y Feyre debe encontrar la manera de detenerla... o condenará a Tamlin, y su mundo, para siempre.",
                            Genero = "Fantasia",
                            Nombre = "A Court of Thorns and Roses"
                        },
                        new
                        {
                            IdProducto = 2,
                            Autor = "Sarah J. Maas",
                            Cantidad = 20,
                            Descripcion = "Tras haber superado más pruebas de lo que un corazón humano puede soportar, Feyre regresa a la Corte Primavera con los poderes de una alta fae. Sin embargo, no consigue olvidar los crímenes que debió cometer para salvar a Tamlin y a su pueblo, ni el perverso pacto que cerró con Rhysand, el alto lord de la temible Corte Noche. \\nMientras Feyre es arrastrada hacia el interior de la oscura red política y pasional de Rhysand, una guerra inminente acecha y un mal mucho más peligroso que cualquier reina amenaza con destruir todo lo que Feyre alguna vez intentó proteger. Ella podría ser la clave para detenerlo, pero solo si consigue dominar sus nuevos dones, sanar su alma partida en dos y decidir su futuro y el de todo un mundo en crisis. \\nLa autora número uno en ventas en The New York Times y USA Today, Sarah J. Maas, lleva esta saga más que adictiva a un nivel impensado.\",",
                            Genero = "Fantasia",
                            Nombre = "A Court of Mist and Fury"
                        },
                        new
                        {
                            IdProducto = 3,
                            Autor = "Sarah J. Maas",
                            Cantidad = 20,
                            Descripcion = "Feyre regresa a la Corte Primavera, decidida a reunir información sobre los planes de Tamlin y del rey invasor que amenaza con destruir Prythian. Para esto deberá someterse a un letal y peligroso juego de engaño, en el que un simple error podría condenar no solo a Feyre, sino también a todo el mundo a su alrededor.\\nA medida que la guerra avanza sin tregua, Feyre deberá posicionarse como una alta fae y luchar por dominar sus dones mágicos; tendrá que determinar en cuáles de los deslumbrantes altos lores puede confiar y salir a buscar aliados en los lugares más inesperados.\\nEn este apasionante tercer volumen de la serie de Una corte de rosas y espinas de la exitosísima autora Sarah J. Maas, la tierra se teñirá de rojo mientras majestuosos ejércitos luchan por apoderarse del único objeto que podría destruirlos a todos. \",",
                            Genero = "Fantasia",
                            Nombre = "A Court of Wings And Ruin"
                        });
                });

            modelBuilder.Entity("APIProductos.Models.User", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodigoAcceso")
                        .HasColumnType("int");

                    b.Property<bool>("HaRetirado")
                        .HasColumnType("bit");

                    b.Property<int>("IdLibroRetirado")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Apellidos = "Coronel Loaiza",
                            Cedula = "1600014789",
                            Clave = "Ciscoudla.1",
                            CodigoAcceso = 1,
                            HaRetirado = false,
                            IdLibroRetirado = 0,
                            Nombres = "Rosa Leopoldina"
                        },
                        new
                        {
                            IdUsuario = 2,
                            Apellidos = "Zambrano",
                            Cedula = "0981316125",
                            Clave = "Ciscoudla.1",
                            CodigoAcceso = 2,
                            HaRetirado = false,
                            IdLibroRetirado = 0,
                            Nombres = "Alejandra"
                        },
                        new
                        {
                            IdUsuario = 3,
                            Apellidos = "Havilliard",
                            Cedula = "0982989316",
                            Clave = "Ciscoudla.1",
                            CodigoAcceso = 3,
                            HaRetirado = false,
                            IdLibroRetirado = 0,
                            Nombres = "Dorian"
                        },
                        new
                        {
                            IdUsuario = 4,
                            Apellidos = "Arcos",
                            Cedula = "1726884552",
                            Clave = "Ciscoudla.1",
                            CodigoAcceso = 4,
                            HaRetirado = true,
                            IdLibroRetirado = 1,
                            Nombres = "Alejandra"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
