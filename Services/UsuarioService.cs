using MinhaPrimeiraApi.Interface;

namespace MinhaPrimeiraApi.Services
{
    
    public class UsuarioService

   
    {
        public UsuarioService(IUsuarioRepositoryInterface repository)
        {
            this.repository = repository;
        }
        private readonly IUsuarioRepositoryInterface repository;
        public List<Usuario> GetAll()
        {
           return repository.GetAll();
        }
        public Usuario Add (Usuario usuario) 
        {
            return repository.Add(usuario);
        }
        public Usuario Update (int id, Usuario usuario)
        {
            return repository.Update(id, usuario);
        }
        public Usuario Delete (int id)
        {
            return repository.Delete(id);
        }
        public Usuario GetById (int id)
        {
            return repository.GetById(id);
        }
    }
}
