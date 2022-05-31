using AutoMapper;
using DigitalWareBackEnd.DataContext;
using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DigitalWareBackEnd.Repositories.DetFactura
{
    public class DetFacturaRepositorio : IDetFacturaRepositorio
    {
        private readonly DigitalWareContext _context;
        private IMapper _mapper;

        public DetFacturaRepositorio(DigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DetFacturaDto> create(DetFacturaDto detFacturaDto)
        {
            DetFacturaModel detFactura = _mapper.Map<DetFacturaDto, DetFacturaModel>(detFacturaDto);
            
            await _context.detFactura.AddAsync(detFactura);
            await _context.SaveChangesAsync();
            return _mapper.Map<DetFacturaModel, DetFacturaDto>(detFactura);
        }

   
        public async Task<bool> delete(int id)
        {
            try
            {
                DetFacturaModel detFactura= await _context.detFactura.FindAsync(id);
                if (detFactura == null)
                {
                    return false;
                }
                _context.Remove(detFactura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<DetFacturaDto>> get(int id)
        {
            List<DetFacturaModel> detalle = await _context.detFactura.Where(d => d.idFactura == id).Include(p => p.ProductoModel).ToListAsync();
            return _mapper.Map<List<DetFacturaDto>>(detalle);
         
        }


    }
}
