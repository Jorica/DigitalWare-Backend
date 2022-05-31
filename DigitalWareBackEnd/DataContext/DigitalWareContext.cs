using DigitalWareBackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace DigitalWareBackEnd.DataContext
{
    public class DigitalWareContext : DbContext
    {
 
        public DigitalWareContext(DbContextOptions<DigitalWareContext> options) : base(options){}

        public DbSet<PersonaModel> personas { get; set; }
        public DbSet<ProductoModel> productos { get; set; }
        public DbSet<FacturaModel> facturas { get; set; }
        public DbSet<DetFacturaModel> detFactura { get; set; }
    }
}
