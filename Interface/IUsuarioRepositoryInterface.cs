using MinhaPrimeiraApi.Repositories;
namespace MinhaPrimeiraApi.Interface
{
    public interface IUsuarioRepositoryInterface
    {
    List<Usuario> GetAll ();
    Usuario Add(Usuario usuario);
    Usuario? Update(int id, Usuario usuario);
    Usuario? Delete(int id);
    Usuario? GetById(int id);
    }
}
