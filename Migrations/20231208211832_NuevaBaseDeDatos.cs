using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIProductos.Migrations
{
    /// <inheritdoc />
    public partial class NuevaBaseDeDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    idEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaEvento = table.Column<TimeSpan>(type: "time", nullable: false),
                    Expositores = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "No especificado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.idEvento);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoAcceso = table.Column<int>(type: "int", nullable: false),
                    HaRetirado = table.Column<bool>(type: "bit", nullable: false),
                    IdLibroRetirado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUsuario);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "idEvento", "DescripcionEvento", "NombreEvento", "diaEvento", "horaEvento" },
                values: new object[] { 1, "Un evento donde los estudiantes terminan clases, antes de descubrir si han aprobado o reprobado el semestre.", "Fin Clases Semestre", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "idEvento", "DescripcionEvento", "Expositores", "NombreEvento", "diaEvento", "horaEvento" },
                values: new object[] { 2, "Concierto de la agrupación mexicana Camila, una banda referente de la música pop en Latinoamérica. Mario Domm, Pablo Hurtado y Samo tienen el propósito de llevar un mensaje de amor a todo tipo de público, sin limitarse por las modas o exigencias que determina el mercado.", "Camila", "Concierto Camila", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Autor", "Cantidad", "Descripcion", "Genero", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sarah J. Maas", 20, "Cuando la cazadora de diecinueve años de edad, Feyre, mata a un lobo el el bosque, una criatura parecida a una bestia llega para exigir venganza. Arrastrada a una traicionera tierra mágica que solo conoce de leyendas, Feyre descubre que su captor no es un animal, sino Tamlin, una de las letales e inmortales hadas que una vez gobernaron su mundo.\nA medida que ella vive en su estado, sus sentimientos por Tamlin se transforman de una hostilidad helada a una pasión que quema a pesar de todas las mentiras y las advertencias que se le han hecho sobre el hermoso y peligroso mundo de las hadas. Pero una antigua y malvada sombre crece sobre las tierras feéricas, y Feyre debe encontrar la manera de detenerla... o condenará a Tamlin, y su mundo, para siempre.", "Fantasia", "A Court of Thorns and Roses" },
                    { 2, "Sarah J. Maas", 20, "Tras haber superado más pruebas de lo que un corazón humano puede soportar, Feyre regresa a la Corte Primavera con los poderes de una alta fae. Sin embargo, no consigue olvidar los crímenes que debió cometer para salvar a Tamlin y a su pueblo, ni el perverso pacto que cerró con Rhysand, el alto lord de la temible Corte Noche. \\nMientras Feyre es arrastrada hacia el interior de la oscura red política y pasional de Rhysand, una guerra inminente acecha y un mal mucho más peligroso que cualquier reina amenaza con destruir todo lo que Feyre alguna vez intentó proteger. Ella podría ser la clave para detenerlo, pero solo si consigue dominar sus nuevos dones, sanar su alma partida en dos y decidir su futuro y el de todo un mundo en crisis. \\nLa autora número uno en ventas en The New York Times y USA Today, Sarah J. Maas, lleva esta saga más que adictiva a un nivel impensado.\",", "Fantasia", "A Court of Mist and Fury" },
                    { 3, "Sarah J. Maas", 20, "Feyre regresa a la Corte Primavera, decidida a reunir información sobre los planes de Tamlin y del rey invasor que amenaza con destruir Prythian. Para esto deberá someterse a un letal y peligroso juego de engaño, en el que un simple error podría condenar no solo a Feyre, sino también a todo el mundo a su alrededor.\\nA medida que la guerra avanza sin tregua, Feyre deberá posicionarse como una alta fae y luchar por dominar sus dones mágicos; tendrá que determinar en cuáles de los deslumbrantes altos lores puede confiar y salir a buscar aliados en los lugares más inesperados.\\nEn este apasionante tercer volumen de la serie de Una corte de rosas y espinas de la exitosísima autora Sarah J. Maas, la tierra se teñirá de rojo mientras majestuosos ejércitos luchan por apoderarse del único objeto que podría destruirlos a todos. \",", "Fantasia", "A Court of Wings And Ruin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUsuario", "Apellidos", "Cedula", "Clave", "CodigoAcceso", "HaRetirado", "IdLibroRetirado", "Nombres" },
                values: new object[,]
                {
                    { 1, "Coronel Loaiza", "1600014789", "Ciscoudla.1", 1, false, 0, "Rosa Leopoldina" },
                    { 2, "Zambrano", "0981316125", "Ciscoudla.1", 2, false, 0, "Alejandra" },
                    { 3, "Havilliard", "0982989316", "Ciscoudla.1", 3, false, 0, "Dorian" },
                    { 4, "Arcos", "1726884552", "Ciscoudla.1", 4, true, 1, "Alejandra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
