namespace DigitalWareBackEnd.Models.Dto
{
    public class DetFacturaDto
    {
        public int Id { get; set; }
        public int cantidadProducto { get; set; }
        public int totalFactura { get; set; }
        public int idProducto { get; set; }
        public int idFactura { get; set; }

        public ProductoModel ProductoModel { get; set; }

        //public FacturaModel FacturaModel { get; set; }

    }
}
