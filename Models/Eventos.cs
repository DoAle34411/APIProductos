using System.ComponentModel.DataAnnotations;
namespace APIProductos.Models
{
    public class Eventos
    {
        [Key]
        public int idEvento { get; set; }
        [Required]
        public string NombreEvento { get; set; }
        [Required]
        public string DescripcionEvento { get; set; }
        [Required]
        public DateOnly diaEvento { get; set; }
        public TimeOnly horaEvento { get; set; }
        public string Expositores { get; set; }
    }
}
