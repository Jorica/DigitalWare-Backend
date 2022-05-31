

using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using DigitalWareBackEnd.Repositories.Persona;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWareBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        protected ResponseDto _response;

        public PersonaController(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaModel>>> Get()
        {
            try
            {
                var lista = await _personaRepositorio.getAll();
                _response.Ok = true;
                _response.Result = lista;
                _response.Message = "Lista de Personas.";
                return Ok(_response);

            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Consulta Denegada.";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonaModel>> Post([FromBody] PersonaDto personaDto)
        {
            try
            {                
                if (await _personaRepositorio.existe(personaDto.dni))
                {
                    _response.Ok = false;
                    _response.Message = "Registro Existente, Verifique El Número DNI.";
                    return BadRequest(_response);
                }
                PersonaDto model = await _personaRepositorio.create(personaDto);
                _response.Ok = true;
                _response.Result = model;
                _response.Message = "Registro Exitoso.";
                return CreatedAtAction("GetPersona", new { dni = model.dni }, _response);

            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Registro Denegado.";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPut("{dni}")]
        public async Task<ActionResult> Put(int dni, [FromBody] PersonaDto personaDto) 
        {
            try
            {
                PersonaDto model = await _personaRepositorio.update(personaDto);
                _response.Ok = true;
                _response.Result = model;
                _response.Message = "Actualización Exitosa.";
                return Ok(_response);

            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Actualización Denegada.";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }

        }

        [HttpDelete("{dni}")]
        public async Task<IActionResult> Delete(int dni)
        {

            try
            {
                bool eliminado = await _personaRepositorio.delete(dni);
                if (eliminado)
                {
                    _response.Ok = true;
                    _response.Result = eliminado;
                    _response.Message = "Eliminiación Exitosa.";
                    return Ok(_response);
                }

                _response.Ok = false;
                _response.Result = eliminado;
                _response.Message = "ERROR! No Se Encuentra El Registro.";
                return NotFound(_response);


            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Eliminación Denegada";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpGet("{dni}")]
        public async Task<ActionResult<PersonaModel>> GetPersona(int dni)
        {
            try
            {
                var persona = await _personaRepositorio.get(dni);
                if(persona == null)
                {
                    _response.Ok = false;
                    _response.Message = "ERROR! No Se Encuentra El Registro.";
                    return NotFound(_response);
                }
                _response.Ok = true;
                _response.Message = "Datos";
                _response.Result = persona;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Consulta Denegada.";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
