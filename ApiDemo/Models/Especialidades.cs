using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDemo.Models
{
    [Table("especialidades")]
    public class Especialidades
    {
        [Key] // Indica que esta propiedad es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Se generará automáticamente

        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string descripcion { get; set; }
    }
}
