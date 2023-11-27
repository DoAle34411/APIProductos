using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public ProductoController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<ProductoController>
        // IActionResult >> Interface Action Result
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Producto> products = await _db.Producto.ToListAsync();
                return Ok(products); //Código de Respuesta "200"
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{IdProducto}")]
        public async Task<IActionResult> Get(int IdProducto)
        {
            try
            {
                Producto producto = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
                if (producto == null)
                {
                    return BadRequest(); //Retornar un Error 102 -> El Request está mal hecho
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                Producto producto2 = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == producto.IdProducto);
                if (producto2 == null && producto != null)
                {
                    await _db.Producto.AddAsync(producto);
                    await _db.SaveChangesAsync();
                    return Ok(producto);
                }

                return BadRequest("El libro ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{IdProducto}")]
        public async Task<IActionResult> Put(int IdProducto, [FromBody] Producto producto)
        {
            try
            {
                Producto producto2 = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
                if (producto != null)
                {
                    producto2.Nombre = producto.Nombre != null ? producto.Nombre : producto2.Nombre;
                    producto2.Descripcion = producto.Descripcion != null ? producto.Descripcion : producto2.Descripcion;
                    producto2.Cantidad = producto.Cantidad != null ? producto.Cantidad : producto2.Cantidad;
                    producto2.Autor = producto.Autor != null ? producto.Autor : producto2.Autor;
                    producto2.Costo = producto.Costo != null ? producto.Costo : producto2.Costo;
                    producto2.Genero = producto.Genero != null ? producto.Genero : producto2.Genero;
                    _db.Producto.Update(producto2);
                    await _db.SaveChangesAsync();
                    return Ok(producto2);
                }

                return BadRequest("El libro no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{IdProducto}")]
        public async Task<IActionResult> Delete(int IdProducto)
        {
            try
            {
                Producto producto = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
                if (producto != null)
                {
                    _db.Producto.Remove(producto);
                    await _db.SaveChangesAsync();
                    return NoContent();
                }

                return BadRequest("El libro no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
