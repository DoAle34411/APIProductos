using APIProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creando un producto
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto = 1,
                    Nombre = "A Court of Thorns and Roses",
                    Descripcion = "Cuando la cazadora de diecinueve años de edad, Feyre, mata a un lobo el el bosque, una criatura parecida a una bestia llega para exigir venganza. Arrastrada a una traicionera tierra mágica que solo conoce de leyendas, Feyre descubre que su captor no es un animal, sino Tamlin, una de las letales e inmortales hadas que una vez gobernaron su mundo.\nA medida que ella vive en su estado, sus sentimientos por Tamlin se transforman de una hostilidad helada a una pasión que quema a pesar de todas las mentiras y las advertencias que se le han hecho sobre el hermoso y peligroso mundo de las hadas. Pero una antigua y malvada sombre crece sobre las tierras feéricas, y Feyre debe encontrar la manera de detenerla... o condenará a Tamlin, y su mundo, para siempre.",
                    Cantidad = 20,
                    Autor = "Sarah J. Maas",
                    Genero = "Fantasia",
                    IdUsuario=0,
                    urlImage= "https://bookevin.files.wordpress.com/2015/08/acotar.jpg"
                },

                new Producto
                {
                    IdProducto = 2,
                    Nombre = "A Court of Mist and Fury",
                    Descripcion = "Tras haber superado más pruebas de lo que un corazón humano puede soportar, Feyre regresa a la Corte Primavera con los poderes de una alta fae. Sin embargo, no consigue olvidar los crímenes que debió cometer para salvar a Tamlin y a su pueblo, ni el perverso pacto que cerró con Rhysand, el alto lord de la temible Corte Noche. \\nMientras Feyre es arrastrada hacia el interior de la oscura red política y pasional de Rhysand, una guerra inminente acecha y un mal mucho más peligroso que cualquier reina amenaza con destruir todo lo que Feyre alguna vez intentó proteger. Ella podría ser la clave para detenerlo, pero solo si consigue dominar sus nuevos dones, sanar su alma partida en dos y decidir su futuro y el de todo un mundo en crisis. \\nLa autora número uno en ventas en The New York Times y USA Today, Sarah J. Maas, lleva esta saga más que adictiva a un nivel impensado.\",",
                    Cantidad = 20,
                    Autor = "Sarah J. Maas",
                    Genero = "Fantasia",
                    IdUsuario = 0,
                    urlImage= "https://static.wikia.nocookie.net/acourtofthornsandroses/images/5/59/A_Court_of_Mist_and_Fury_-_UK_Cover.jpg/revision/latest/scale-to-width-down/250?cb=20160114162151"
                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "A Court of Wings And Ruin",
                    Descripcion = "Feyre regresa a la Corte Primavera, decidida a reunir información sobre los planes de Tamlin y del rey invasor que amenaza con destruir Prythian. Para esto deberá someterse a un letal y peligroso juego de engaño, en el que un simple error podría condenar no solo a Feyre, sino también a todo el mundo a su alrededor.\\nA medida que la guerra avanza sin tregua, Feyre deberá posicionarse como una alta fae y luchar por dominar sus dones mágicos; tendrá que determinar en cuáles de los deslumbrantes altos lores puede confiar y salir a buscar aliados en los lugares más inesperados.\\nEn este apasionante tercer volumen de la serie de Una corte de rosas y espinas de la exitosísima autora Sarah J. Maas, la tierra se teñirá de rojo mientras majestuosos ejércitos luchan por apoderarse del único objeto que podría destruirlos a todos. \",",
                    Cantidad = 20,
                    Autor = "Sarah J. Maas",
                    Genero = "Fantasia",
                    IdUsuario = 0,
                    urlImage= "https://starcrossedbookblog.com/wp-content/uploads/2019/05/23766634.jpg"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User 
                {
                    IdUsuario=1,
                    Cedula="1600014789",
                    Clave="Ciscoudla.1",
                    CodigoAcceso=1,
                    Nombres="Rosa Leopoldina",
                    Apellidos="Coronel Loaiza",
                    HaRetirado=false
                },
                new User
                {
                    IdUsuario = 2,
                    Cedula = "0981316125",
                    Clave = "Ciscoudla.1",
                    CodigoAcceso = 2,
                    Nombres = "Alejandra",
                    Apellidos = "Zambrano",
                    HaRetirado = false
                },
                new User
                {
                    IdUsuario = 3,
                    Cedula = "0982989316",
                    Clave = "Ciscoudla.1",
                    CodigoAcceso = 3,
                    Nombres = "Dorian",
                    Apellidos = "Havilliard",
                    HaRetirado = false
                },
                new User
                {
                    IdUsuario = 4,
                    Cedula = "1726884552",
                    Clave = "Ciscoudla.1",
                    CodigoAcceso = 4,
                    Nombres = "Alejandra",
                    Apellidos = "Arcos",
                    HaRetirado = true,
                    IdLibroRetirado=1
                }
                );
            modelBuilder.Entity<Eventos>().Property(e => e.Expositores).HasDefaultValue("No especificado");
            modelBuilder.Entity<Eventos>().HasData(
                new Eventos
                {
                    idEvento = 1,
                    NombreEvento = "Fin Clases Semestre",
                    DescripcionEvento = "Un evento donde los estudiantes terminan clases, antes de descubrir si han aprobado o reprobado el semestre.",
                    diaEvento = new DateTime(2024, 01, 27),
                    horaEvento=new TimeSpan(0, 0, 0),
                },
                new Eventos
                {
                    idEvento = 2,
                    NombreEvento = "Concierto Camila",
                    DescripcionEvento = "Concierto de la agrupación mexicana Camila, una banda referente de la música pop en Latinoamérica. Mario Domm, Pablo Hurtado y Samo tienen el propósito de llevar un mensaje de amor a todo tipo de público, sin limitarse por las modas o exigencias que determina el mercado.",
                    diaEvento = new DateTime(2024, 03, 01),
                    horaEvento = new TimeSpan(20, 00, 00),
                    Expositores = "Camila"
                }
                );
            modelBuilder.Entity<Pedidos>().HasData(
                new Pedidos
                {
                    IdPedido = 1,
                    IdUsuario = 4,
                    IdProducto=1,
                    IsActivo=false,
                    IdUsuarioActivo=0
                },
                new Pedidos
                {
                    IdPedido=2,
                    IdUsuario = 4,
                    IdProducto=2,
                    IsActivo=true,
                    IdUsuarioActivo=0,
                }
            );
        }
    }
}
