using AutoMapper;
using DigitalWareBackEnd.DataContext;
using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DigitalWareBackEnd.Repositories.Producto
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly DigitalWareContext _context;
        private IMapper _mapper;

        public ProductoRepositorio(DigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductoDto> create(ProductoDto productoDto)
        {
            ProductoModel producto = _mapper.Map<ProductoDto, ProductoModel>(productoDto);

            await _context.productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoModel, ProductoDto>(producto);
        }

        public async Task<bool> delete(int id)
        {
            try
            {
                ProductoModel producto = await _context.productos.FindAsync(id);
                if (producto== null)
                {
                    return false;
                }
                _context.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductoDto> get(int id)
        {
            ProductoModel producto = await _context.productos.FindAsync(id);
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<List<ProductoDto>> getAll()
        {
            List<ProductoModel> lista = await _context.productos.ToListAsync();
            return _mapper.Map<List<ProductoDto>>(lista);
        }

        public async Task<ProductoDto> update(ProductoDto productoDto)
        {
            ProductoModel producto = _mapper.Map<ProductoDto, ProductoModel>(productoDto);
            _context.productos.Update(producto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoModel, ProductoDto>(producto);
        }
    }
}
