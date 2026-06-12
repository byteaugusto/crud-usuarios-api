namespace MinhaPrimeiraApi.Services
{
    public class UsuarioService
    {
        private static List<Usuario> usuarios = new List<Usuario>();
        public List<Usuario> Get()
        {
            return usuarios;
        }
        public Usuario Add (Usuario usuario) 
        {
            usuario.Id = usuarios.Count + 1;
            usuarios.Add(usuario);
            return (usuario);
        }
        public Usuario Update (int id, Usuario usuario)
        {
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente == null)
            {
                return null;
            }
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            return (usuarioExistente);
        }
        public Usuario Delete (int id)
        {
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente == null)
            {
                return null;
            }
            usuarios.Remove(usuarioExistente);
            return (usuarioExistente);
        }
        public Usuario GetById (int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
