using AutoMapper;
using DigitalWareBackEnd.DataContext;
using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DigitalWareBackEnd.Repositories.Factrura
{
    public class FacturaRepositorio : IFacturaRepositorio
    {
        private readonly DigitalWareContext _context;
        private IMapper _mapper;

        public FacturaRepositorio(DigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FacturaDto> create(FacturaDto facturaDto)
        {
            FacturaModel factura = _mapper.Map<FacturaDto, FacturaModel>(facturaDto);
            factura.fechaCreacion = DateTime.Now;
            await _context.facturas.AddAsync(factura);
            await _context.SaveChangesAsync();
            return _mapper.Map<FacturaModel, FacturaDto>(factura);
        }

        public async Task<bool> delete(int id)
        {
            try
            {
                FacturaModel factura = await _context.facturas.FindAsync(id);
                if (factura == null)
                {
                    return false;
                }
                _context.Remove(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<FacturaDto> get(int id)
        {
            FacturaModel factura = await _context.facturas.Include(f => f.PersonaModel).FirstOrDefaultAsync(f => f.Id == id);
            return _mapper.Map<FacturaDto>(factura);
        }

        public async Task<List<FacturaDto>> getAll()
        {
            List<FacturaModel> lista = await _context.facturas.OrderByDescending(f => f.Id).Include(f => f.PersonaModel).ToListAsync();
            return _mapper.Map<List<FacturaDto>>(lista);
        }

        public async Task<FacturaDto> update(FacturaDto facturaDto)
        {
            FacturaModel factura = _mapper.Map<FacturaDto, FacturaModel>(facturaDto);
            _context.facturas.Update(factura);
            await _context.SaveChangesAsync();
            return _mapper.Map<FacturaModel, FacturaDto>(factura);
        }
    }
}
