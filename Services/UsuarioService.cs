using MinhaPrimeiraApi.Interface;
using MinhaPrimeiraApi.Results;

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
        public ResultadoAtualizacao Update (int id, Usuario usuario)
        {
            var usuarioExistente = repository.GetById(id);
            if (usuarioExistente == null) 
            {
                return new ResultadoAtualizacao("Usuario não existe no banco",
                    null,
                    TipoErroAtualizacao.UsuarioNaoEncontrado);
            }
            var usuarioRepository = repository.GetAll();
            if(usuarioRepository.Any(u => u.Email == usuario.Email && u.Id != id ))
            {
                return new ResultadoAtualizacao("Email já cadastrado", 
                    null,
                    TipoErroAtualizacao.EmailDuplicado);
            }
            var usuarioAtualizado = repository.Update(id, usuario);
            if (usuarioAtualizado != null)
            {
                return new ResultadoAtualizacao( "Atualização realizada com sucesso", 
                    usuarioAtualizado,
                     TipoErroAtualizacao.Nenhum);
            }
            else
            {
                return new ResultadoAtualizacao("Usuario nulo", 
                    null,
                    TipoErroAtualizacao.UsuarioNaoEncontrado);
            }
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
