using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Interface;

namespace MinhaPrimeiraApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepositoryInterface
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

            public List<Usuario> GetAll()
            {
                return _appDbContext.Usuarios.ToList();
            }
            public Usuario Add(Usuario usuario)
            {
                _appDbContext.Usuarios.Add(usuario);
                _appDbContext.SaveChanges();
                return (usuario);
            }
            public Usuario? Update(int id, Usuario usuario)
            {
                var usuarioExistente = _appDbContext.Usuarios.FirstOrDefault(u => u.Id == id);
               
                if (usuarioExistente == null)
                {
                    return null;
                }
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
                _appDbContext.SaveChanges();
                return (usuarioExistente);
            }
            public Usuario? Delete(int id)
            {
                var usuarioExistente = _appDbContext.Usuarios.FirstOrDefault(u => u.Id == id);
                if (usuarioExistente == null)
                {
                    return null;
                }
                _appDbContext.Remove(usuarioExistente);
                _appDbContext.SaveChanges();
                return (usuarioExistente);
            }
            public Usuario? GetById(int id)
            {
                return _appDbContext.Usuarios.FirstOrDefault(u => u.Id == id);
            }
        }
    }

