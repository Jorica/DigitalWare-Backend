using AutoMapper;
using DigitalWareBackEnd.DataContext;
using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DigitalWareBackEnd.Repositories.Persona
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly DigitalWareContext _context;
        private IMapper _mapper;

        public PersonaRepositorio(DigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PersonaDto> create(PersonaDto personaDto)
        {

            PersonaModel persona = _mapper.Map<PersonaDto, PersonaModel>(personaDto);

            await _context.personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonaModel, PersonaDto>(persona);

        }

        public async Task<bool> existe(int dni)
        {
            try
            {
                PersonaModel persona = await _context.personas.FindAsync(dni);
                Console.Write(persona);
                if (persona == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<bool> delete(int dni)
        {
            try
            {
                PersonaModel persona = await _context.personas.FindAsync(dni);
                if (persona == null)
                {
                    return false;
                }
                _context.Remove(persona);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<PersonaDto>> getAll()
        {
            List<PersonaModel> lista = await _context.personas.ToListAsync();
            return _mapper.Map<List<PersonaDto>>(lista);
        }

        public async Task<PersonaDto> get(int dni)
        {
            PersonaModel persona = await _context.personas.FindAsync(dni);
            return _mapper.Map<PersonaDto>(persona);
        }

        public async Task<PersonaDto> update(PersonaDto personaDto)
        {
            PersonaModel persona = _mapper.Map<PersonaDto, PersonaModel>(personaDto);
            _context.personas.Update(persona);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonaModel, PersonaDto>(persona);
        }
    }
}
