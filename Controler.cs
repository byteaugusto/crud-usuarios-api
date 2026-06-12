using MinhaPrimeiraApi.Services;
namespace MinhaPrimeiraApi

{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService service;
        public UsuarioController(UsuarioService service)
        {
            this.service = service;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = service.GetById(id);
            
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var novoUsuario = service.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
             var usuarioAtualizado = service.Update(id, usuario);
            if (usuarioAtualizado == null)
            {
                return NotFound();
            }
            return Ok(usuarioAtualizado);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuarioRemovido = service.Delete(id);

            if (usuarioRemovido == null)
                return NotFound();
            return Ok(usuarioRemovido);
        }
    }
}
