using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using DigitalWareBackEnd.Repositories.DetFactura;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWareBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class DetFaturaController : ControllerBase
    {
        private readonly IDetFacturaRepositorio _detFacturaRepositorio;
        protected ResponseDto _response;

        public DetFaturaController(IDetFacturaRepositorio detFacturaRepositorio)
        {
            _detFacturaRepositorio = detFacturaRepositorio;
            _response = new ResponseDto();
        }

     
        [HttpPost]
        public async Task<ActionResult<DetFacturaModel>> Post([FromBody] DetFacturaDto detFacturaDto)
        {
            try
            {
                DetFacturaDto model = await _detFacturaRepositorio.create(detFacturaDto);
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                bool eliminado = await _detFacturaRepositorio.delete(id);
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
        // Se solicita el ID de la Factura, no del detalle. Esto debido a que trae un listado de todos los productos asociados a la factura.
        public async Task<ActionResult<DetFacturaModel>> GetFactura(int id) 
        {
            try
            {
                var factura = await _detFacturaRepositorio.get(id);
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
