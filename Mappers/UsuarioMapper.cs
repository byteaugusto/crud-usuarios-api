using MinhaPrimeiraApi.DTOs;

namespace MinhaPrimeiraApi.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioResponseDto ParaResponseDto(Usuario usuario)
        {
            UsuarioResponseDto response = new UsuarioResponseDto()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
            return response;
        }
        public static Usuario ParaUsuario(UsuarioCreateDto usuarioDto)
        {
            Usuario usuario = new Usuario()
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email
            };
            return usuario;
        }
        public static Usuario ParaUsuario(UsuarioUpdateDto updateDto)
        {
            Usuario usuario = new Usuario()
            {
                Nome = updateDto.Nome,
                Email = updateDto.Email
            };
            return usuario;
        }
    }
}
