using System.ComponentModel.DataAnnotations;

namespace MinhaPrimeiraApi.DTOs
{
    public class UsuarioCreateDto
    {
        
        public string Nome { get; set; } = string.Empty;
       
        public string Email {  get; set; } = string.Empty;
    }
}
