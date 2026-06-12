namespace MinhaPrimeiraApi
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = usuarios.FirstOrDefault (u => u.Id == id);

            if (usuario == null)
            {
                return  NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            usuario.Id = usuarios.Count + 1;
            usuarios.Add(usuario);
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }
          usuarioExistente.Nome = usuario.Nome;
          usuarioExistente.Email = usuario.Email;
          return Ok(usuarioExistente);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            usuarios.Remove(usuario);
            return Ok(usuario);
        }
    }
}
