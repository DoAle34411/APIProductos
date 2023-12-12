using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Genero { get; set; }
        public int IdUsuario { get; set; }
        public string urlImage { get; set; }
    }
}
