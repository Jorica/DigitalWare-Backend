using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using DigitalWareBackEnd.Repositories.Factrura;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWareBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaRepositorio _facturaRepositorio;
        protected ResponseDto _response;

        public FacturaController(IFacturaRepositorio facturaRepositorio)
        {
            _facturaRepositorio = facturaRepositorio;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaModel>>> Get()
        {
            try
            {
                var lista = await _facturaRepositorio.getAll();
                _response.Ok = true;
                _response.Result = lista;
                _response.Message = "Lista de Facturas.";
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
        public async Task<ActionResult<FacturaModel>> Post([FromBody] FacturaDto facturaDto)
        {
            
            try
            {
                FacturaDto model = await _facturaRepositorio.create(facturaDto);
                _response.Ok = true;
                _response.Result = model;
                _response.Message = "Registro Exitoso.";
                return CreatedAtAction("GetFactura", new { Id = model.Id }, _response);
                

            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Registro Denegado.";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaDto facturaDto)
        {
            try
            {
                FacturaDto model = await _facturaRepositorio.update(facturaDto);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                bool eliminado = await _facturaRepositorio.delete(id);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaModel>> GetFactura(int id)
        {
            try
            {
                var factura = await _facturaRepositorio.get(id);
                if (factura == null)
                {
                    _response.Ok = false;
                    _response.Message = "ERROR! No Se Encuentra El Registro.";
                    return NotFound(_response);
                }
                _response.Ok = true;
                _response.Message = "Datos";
                _response.Result = factura;
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
