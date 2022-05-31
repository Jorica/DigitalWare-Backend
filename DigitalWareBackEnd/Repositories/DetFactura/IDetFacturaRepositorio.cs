using DigitalWareBackEnd.Models.Dto;

namespace DigitalWareBackEnd.Repositories.DetFactura
{
    public interface IDetFacturaRepositorio
    {
        Task <DetFacturaDto> create(DetFacturaDto detFacturaDto);

        Task<List<DetFacturaDto>> get(int id);

        Task<bool> delete(int id);
    
    }
}
