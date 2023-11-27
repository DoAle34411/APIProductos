using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;

        //Constructor
        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet("{IdUsuario}/{Clave}")]
        public async Task<IActionResult> Get(int IdUsuario, string Clave)
        {
            try
            {

                User usuario_encontrado = await _db.User.Where(x => x.IdUsuario == IdUsuario && x.Clave == Clave).FirstOrDefaultAsync();

                if (usuario_encontrado == null)
                {
                    Console.WriteLine("UsuarioEncontradoAPI");
                    return BadRequest();
                }
                return Ok(usuario_encontrado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("UsuarioNoEncontradoAPI");
                return BadRequest(ex.Message);
            }
        }
    }
}
