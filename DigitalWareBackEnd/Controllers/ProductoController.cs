using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;
using DigitalWareBackEnd.Repositories.Producto;
using Microsoft.AspNetCore.Mvc;


namespace DigitalWareBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;
        protected ResponseDto _response;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> Get()
        {
            try
            {
                var lista = await _productoRepositorio.getAll();
                _response.Ok = true;
                _response.Result = lista;
                _response.Message = "Lista De Productos.";
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoModel>> GetProdcuto(int id)
        {
            try
            {
                var producto = await _productoRepositorio.get(id);
                if (producto == null)
                {
                    _response.Ok = false;
                    _response.Message = "ERROR! No Se Encuentra El Registro.";
                    return NotFound(_response);
                }
                _response.Ok = true;
                _response.Message = "Datos";
                _response.Result = producto;
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
        public async Task<ActionResult<ProductoModel>> Post([FromBody] ProductoDto productoDto)
        {
            try
            {

                ProductoDto model = await _productoRepositorio.create(productoDto);
                _response.Ok = true;
                _response.Result = model;
                _response.Message = "Registro Exitoso.";
                return CreatedAtAction("GetProdcuto", new { Id = model.Id }, _response);

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
        public async Task<ActionResult> Put(int id, [FromBody] ProductoDto productoDto)
        {
            try
            {
                ProductoDto model = await _productoRepositorio.update(productoDto);
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
                bool eliminado = await _productoRepositorio.delete(id);
                if (eliminado)
                {
                    _response.Ok = true;
                    _response.Result = eliminado;
                    _response.Message = "Eliminación Exitosa.";
                    return Ok(_response);
                }

                _response.Ok = false;
                _response.Result = eliminado;
                _response.Message = "ERROR! No Se Encuentra El Registro";
                return NotFound(_response);


            }
            catch (Exception e)
            {
                _response.Ok = false;
                _response.Message = "ERROR! Eliminación Denegada-";
                _response.Errors = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
