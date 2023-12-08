using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public EventosController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Eventos> products = await _db.Eventos.ToListAsync();
                return Ok(products); //Código de Respuesta "200"
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idEvento}")]
        public async Task<IActionResult> Get(int idEvento)
        {
            try
            {
                Eventos eventos = await _db.Eventos.FirstOrDefaultAsync(x => x.idEvento == idEvento);
                if (eventos == null)
                {
                    return BadRequest(); //Retornar un Error 102 -> El Request está mal hecho
                }
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]  Eventos eventos)
        {
            try
            {
                Eventos eventos2 = await _db.Eventos.FirstOrDefaultAsync(x => x.idEvento == eventos.idEvento);
                if (eventos2 == null && eventos != null)
                {
                    await _db.Eventos.AddAsync(eventos);
                    await _db.SaveChangesAsync();
                    return Ok(eventos);
                }

                return BadRequest("El evento ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idEvento}")]
        public async Task<IActionResult> Put(int idEvento, [FromBody]  Eventos eventos)
        {
            try
            {
                Eventos eventos2 = await _db.Eventos.FirstOrDefaultAsync(x => x.idEvento == idEvento);
                if (eventos != null && eventos2 !=null)
                {
                    eventos2.NombreEvento = eventos.NombreEvento != null ? eventos.NombreEvento : eventos2.NombreEvento;
                    eventos2.DescripcionEvento = eventos.DescripcionEvento != null ? eventos.DescripcionEvento : eventos2.DescripcionEvento;
                    eventos2.Expositores = eventos.Expositores != null ? eventos.Expositores : eventos2.Expositores;
                    eventos2.diaEvento = eventos.diaEvento != null ? eventos.diaEvento : eventos2.diaEvento;
                    eventos2.horaEvento = eventos.horaEvento != null ? eventos.horaEvento : eventos2.horaEvento;
                    _db.Eventos.Update(eventos2);
                    await _db.SaveChangesAsync();
                    return Ok(eventos2);
                }

                return BadRequest("El evento no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{idEvento}")]
        public async Task<IActionResult> Delete(int idEvento)
        {
            try
            {
                Eventos eventos = await _db.Eventos.FirstOrDefaultAsync(x => x.idEvento == idEvento);
                if (eventos != null)
                {
                    _db.Eventos.Remove(eventos);
                    await _db.SaveChangesAsync();
                    return NoContent();
                }

                return BadRequest("El evento no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
