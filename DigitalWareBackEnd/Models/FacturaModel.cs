using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWareBackEnd.Models
{
    public class FacturaModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime fechaCreacion { get; set; }

        [Required]
        public int valorPagado { get; set; }

        public int dniPersona { get; set; }
        [ForeignKey("dniPersona")]
        public  PersonaModel? PersonaModel { get; set; }


    }
}
