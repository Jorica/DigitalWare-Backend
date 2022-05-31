using DigitalWareBackEnd.Models.Dto;

namespace DigitalWareBackEnd.Repositories.Producto
{
    public interface IProductoRepositorio
    {
        Task<List<ProductoDto>> getAll();

        Task<ProductoDto> create(ProductoDto productoDto);

        Task<ProductoDto> update(ProductoDto productoDto);

        Task<ProductoDto> get(int id);

        Task<bool> delete(int id);
    }
}
