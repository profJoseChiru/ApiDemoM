using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDemo.Models
{
    [Table("v_listadomedico")]
    public class ListadoMedico
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidades { get; set; }
    }
}
