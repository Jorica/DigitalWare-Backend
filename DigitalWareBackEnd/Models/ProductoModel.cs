using System.ComponentModel.DataAnnotations;

namespace DigitalWareBackEnd.Models
{
    public class ProductoModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string nombre { get; set; }

        [Required]
        public int precioVenta { get; set; }

        [Required]
        public int existencia { get; set; }

    }
}
