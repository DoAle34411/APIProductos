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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<User> users = await _db.User.ToListAsync();
                return Ok(users); //Código de Respuesta "200"
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Cedula}/{Clave}")]
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

        [HttpGet("{Cedula}")]
        public async Task<IActionResult> Get(string Cedula)
        {
            try
            {
                User usuario_encontrado = await _db.User.Where(x => x.Cedula == Cedula).FirstOrDefaultAsync();

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

        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> Get(int IdUsuario)
        {
            try
            {
                User usuario = await _db.User.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
                if (usuario == null)
                {
                    return BadRequest(); //Retornar un Error 102 -> El Request está mal hecho
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                User user2 = await _db.User.FirstOrDefaultAsync(x => x.Cedula == user.Cedula);
                User user3= await _db.User.FirstOrDefaultAsync(x=>x.IdUsuario==user.IdUsuario);
                if (user2 == null && user != null && user3==null)
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
        [HttpPut("{IdUsuario}")]
        public async Task<IActionResult> Put(int IdUsuario, [FromBody] User user)
        {
            try
            {
                User user2 = await _db.User.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
                if (user != null && user2 != null)
                {
                    user2.Clave = user.Clave != null ? user.Clave : user2.Clave;
                    user2.Nombres = user.Nombres != null ? user.Nombres : user2.Nombres;
                    user2.Apellidos = user.Apellidos != null ? user.Apellidos : user2.Apellidos;
                    user2.CodigoAcceso = user.CodigoAcceso != null ? user.CodigoAcceso : user2.CodigoAcceso;
                    user2.HaRetirado = user.HaRetirado != null ? user.HaRetirado : user2.HaRetirado;
                    user2.IdLibroRetirado = user.IdLibroRetirado != null ? user.IdLibroRetirado : user2.IdLibroRetirado;
                    user2.Cedula = user.Cedula;
                    user2.IdUsuarioActivo = user.IdUsuarioActivo!=null? user.IdUsuarioActivo:user2.IdUsuarioActivo;
                    _db.User.Update(user2);
                    await _db.SaveChangesAsync();
                    return Ok(user2);
                }

                return BadRequest("El usuario no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
