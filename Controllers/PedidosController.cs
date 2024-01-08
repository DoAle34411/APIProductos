using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public PedidosController(ApplicationDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Pedidos> pedidos = await _db.Pedidos.ToListAsync();
                return Ok(pedidos); //Código de Respuesta "200"
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{IdPedido}")]
        public async Task<IActionResult> Get(int IdPedido)
        {
            try
            {
                Pedidos pedido = await _db.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == IdPedido);
                if (pedido == null)
                {
                    return BadRequest(); //Retornar un Error 102 -> El Request está mal hecho
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{IdUsuario}/{IdUsuarioActivo}")]
        public async Task<IActionResult> Get(int IdUsuario, int IdUsuarioActivo)
        {
            try
            {
                List<Pedidos> pedidos = await _db.Pedidos.Where(x=> x.IdUsuario == IdUsuario).ToListAsync();

                if (pedidos == null)
                {
                    return BadRequest();
                }
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedidos pedido)
        {
            try
            {
                Pedidos pedido2 = await _db.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == pedido.IdPedido);
                Pedidos pedido3 = await _db.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == pedido.IdPedido);
                if (pedido2 == null && pedido != null && pedido3 == null)
                {
                    await _db.Pedidos.AddAsync(pedido);
                    await _db.SaveChangesAsync();
                    return Ok(pedido);
                }

                return BadRequest("El pedido ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{IdPedido}")]
        public async Task<IActionResult> Put(int IdPedido, [FromBody] Pedidos pedido)
        {
            try
            {
                Pedidos pedidos2 = await _db.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == IdPedido);
                if (pedido != null && pedidos2 != null)
                {
                    pedidos2.IsActivo = pedido.IsActivo != null ? pedido.IsActivo : pedidos2.IsActivo;
                    _db.Pedidos.Update(pedidos2);
                    await _db.SaveChangesAsync();
                    return Ok(pedidos2);
                }

                return BadRequest("Se ha modificado el estado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
