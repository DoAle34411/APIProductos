using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class User
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public int CodigoAcceso { get; set; } // 1 para admin, 2 para usuario trabajador habilitado, 3 usuario trabajador no habilitado y 4 usuario externo
    }
}
