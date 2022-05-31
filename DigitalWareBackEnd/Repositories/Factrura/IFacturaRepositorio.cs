using DigitalWareBackEnd.Models.Dto;

namespace DigitalWareBackEnd.Repositories.Factrura
{
    public interface IFacturaRepositorio
    {
        Task<List<FacturaDto>> getAll();

        Task<FacturaDto> create(FacturaDto facturaDto);

        Task<FacturaDto> update(FacturaDto facturaDto);

        Task<FacturaDto> get(int id);

        Task<bool> delete(int id);
    }
}
