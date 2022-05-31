using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWareBackEnd.Models
{
    public class PersonaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dni { get; set; }

        [Required, MaxLength(50)]
        public string nombre { get; set; }

        [Required, MaxLength(50)]
        public string apellido { get; set; }

        [Required]
        public int edad { get; set; }

        [Required, MaxLength(100)]
        public string direccion { get; set; }
    }
}
