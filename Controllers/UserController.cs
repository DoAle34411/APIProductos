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
        public async Task<IActionResult> Get(string Cedula, string Clave)
        {
            try
            {
                User usuario_encontrado = await _db.User.Where(x => x.Cedula == Cedula && x.Clave == Clave).FirstOrDefaultAsync();

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                User user2 = await _db.User.FirstOrDefaultAsync(x => x.Cedula == user.Cedula);
                if (user2 == null && user != null)
                {
                    await _db.User.AddAsync(user);
                    await _db.SaveChangesAsync();
                    return Ok(user);
                }

                return BadRequest("El usuario ya existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
