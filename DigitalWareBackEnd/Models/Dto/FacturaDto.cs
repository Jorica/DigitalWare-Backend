namespace DigitalWareBackEnd.Models.Dto
{
    public class FacturaDto
    {
      public int Id { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int valorPagado { get; set; }

        public int dniPersona { get; set; }

        public PersonaModel PersonaModel { get; set; }

    }
}
