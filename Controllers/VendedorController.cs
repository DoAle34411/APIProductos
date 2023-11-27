using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public VendedorController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: VendedorController

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Vendedor> seller = await _db.Vendedor.ToListAsync();
                return Ok(seller); //Código de Respuesta "200"
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: VendedorController/Details/5
        [HttpGet("{Cedula}")]
        public async Task<IActionResult> Get(int Cedula)
        {
            try
            {
                Vendedor vendedor = await _db.Vendedor.FirstOrDefaultAsync(x => x.Cedula == Cedula);
                if (vendedor == null)
                {
                    return BadRequest(); //Retornar un Error 102 -> El Request está mal hecho
                }
                return Ok(vendedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: VendedorController/Create
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vendedor vendedor)
        {
            try
            {
                Vendedor vendedor2 = await _db.Vendedor.FirstOrDefaultAsync(x => x.Cedula == vendedor.Cedula);
                if (vendedor2 == null && vendedor != null)
                {
                    await _db.Vendedor.AddAsync(vendedor);
                    await _db.SaveChangesAsync();
                    return Ok(vendedor);
                }

                return BadRequest("El vendedor ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{Cedula}")]
        public async Task<IActionResult> Put(int Cedula, [FromBody] Vendedor vendedor)
        {
            try
            {
                Vendedor vendedor2 = await _db.Vendedor.FirstOrDefaultAsync(x => x.Cedula == Cedula);
                if (vendedor != null)
                {
                    vendedor2.Nombres = vendedor.Nombres != null ? vendedor.Nombres : vendedor2.Nombres;
                    vendedor2.Apellidos = vendedor.Apellidos != null ? vendedor.Apellidos : vendedor2.Apellidos;
                    vendedor2.CantidadVentas = vendedor.CantidadVentas != null ? vendedor.CantidadVentas : vendedor2.CantidadVentas;
                    vendedor2.EsActivo = vendedor.EsActivo != null ? vendedor.EsActivo : vendedor2.EsActivo;
                    _db.Vendedor.Update(vendedor2);
                    await _db.SaveChangesAsync();
                    return Ok(vendedor2);
                }
                return BadRequest("El vendedor no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{Cedula}")]
        public async Task<IActionResult> Delete(int Cedula)
        {
            try
            {
                Vendedor vendedor = await _db.Vendedor.FirstOrDefaultAsync(x => x.Cedula == Cedula);
                if (vendedor != null)
                {
                    _db.Vendedor.Remove(vendedor);
                    await _db.SaveChangesAsync();
                    return NoContent();
                }

                return BadRequest("El vendedor no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
