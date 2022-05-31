using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWareBackEnd.Models
{
    public class DetFacturaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int cantidadProducto { get; set; }

        [Required]
        public int totalFactura { get; set; }

        
        public int idProducto { get; set; }
        [ForeignKey("idProducto")]
        public ProductoModel? ProductoModel { get; set; }
        public int idFactura { get; set; }
        [ForeignKey("idFactura")]

        

        public FacturaModel? FacturaModel { get; set; }





    }
}
