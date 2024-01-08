using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Pedidos
    {
        [Key]
        public int IdPedido { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public bool IsActivo { get; set; }
        public int IdUsuarioActivo { get; set; }
    }
}
