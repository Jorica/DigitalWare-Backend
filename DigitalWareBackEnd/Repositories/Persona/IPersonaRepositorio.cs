using DigitalWareBackEnd.Models.Dto;

namespace DigitalWareBackEnd.Repositories.Persona
{
    public interface IPersonaRepositorio
    {
        Task<List<PersonaDto>> getAll();

        Task<PersonaDto> create(PersonaDto personaDto);

        Task<PersonaDto> update(PersonaDto personaDto);

        Task<PersonaDto> get(int dni);

        Task<bool> delete(int dni);

        Task<bool> existe(int dni);
    }
}
