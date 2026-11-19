using MinhaPrimeiraApi.Services;
using MinhaPrimeiraApi.Results;
using MinhaPrimeiraApi.DTOs;
using MinhaPrimeiraApi.Mappers;

namespace MinhaPrimeiraApi

{
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;
    using MinhaPrimeiraApi.Results;


    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService service;
        private readonly IValidator<UsuarioCreateDto> validator;
        private readonly IValidator<UsuarioUpdateDto> validatorUpdate;
        public UsuarioController(
                                    UsuarioService service,
                                    IValidator<UsuarioCreateDto> validator,
                                    IValidator<UsuarioUpdateDto> validatorUpdate)
                                                {
                                                    this.service = service;
                                                    this.validator = validator;
                                                    this.validatorUpdate = validatorUpdate;
                                                }

        [HttpGet]
        public ActionResult<ApiResponse<List<UsuarioResponseDto>>> GetAll()
        {
            var get = service.GetAll()
                .Select(item => UsuarioMapper.ParaResponseDto(item))
                .ToList();
            var apiResponse = new ApiResponse<List<UsuarioResponseDto>>()
            {
                Success = true,
                Message = "Usuários listados com sucesso!",
                Data = get
            };

            return Ok(apiResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<UsuarioResponseDto>> GetById(int id)
        {
            var usuario = service.GetById(id);
            
            if (usuario == null)
            {
                var apiResponseErro = new ApiResponse<UsuarioResponseDto>()
                {
                    Success = false,
                    Message = "Usuário não encontrado.",
                    Data = null
                };
                return NotFound(apiResponseErro);
            }
            var response = UsuarioMapper.ParaResponseDto(usuario);
            var apiResponse = new ApiResponse<UsuarioResponseDto>()
            {
                Success = true,
                Message = "Usuário encontrado com sucesso!",
                Data = response
            };

            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<UsuarioResponseDto>>> Post(UsuarioCreateDto usuarioDto)
        {
            var validation = await validator.ValidateAsync(usuarioDto);
            if (validation.IsValid == false)
            {
                var apiResponseErro = new ApiResponse<object>
                {
                    Success = false,
                    Message = "Erro de validação dos dados.",
                    Data = validation.Errors
                };
                return BadRequest(apiResponseErro);
            }
            var usuario = UsuarioMapper.ParaUsuario(usuarioDto);
            var novoUsuario = service.Add(usuario);
            var response = UsuarioMapper.ParaResponseDto(novoUsuario);
            var apiResponse = new ApiResponse<UsuarioResponseDto>
            {
                Success = true,
                Message = "Usuário cadastrado com sucesso!",
                Data = response
            };
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioUpdateDto updateDto)
        {
            var validation = await validatorUpdate.ValidateAsync(updateDto);
            if (!validation.IsValid)
            {
                var apiResponseErro = new ApiResponse<object>
                {
                    Success = false,
                    Message = "Erro de validação dos dados.",
                    Data= validation.Errors
                };
                return BadRequest(apiResponseErro);
            }
            var update = UsuarioMapper.ParaUsuario(updateDto);
            var resultado = service.Update(id, update);

            if (resultado.TipoErro == TipoErroAtualizacao.Nenhum)
            {
                if (resultado.Usuario != null)
                {
                    var response = UsuarioMapper.ParaResponseDto(resultado.Usuario);
                    var apiResponse = new ApiResponse<UsuarioResponseDto>
                    {
                        Success = true,
                        Message = "Usuário atualizado com sucesso!",
                        Data = response
                    };

                    return Ok(apiResponse);
                }
                else
                {
                    return BadRequest();
                }
            }
            else if (resultado.TipoErro == TipoErroAtualizacao.UsuarioNaoEncontrado)
            {
               
                return NotFound(resultado.Message);
            }
            else if (resultado.TipoErro == TipoErroAtualizacao.EmailDuplicado)
            {
                return Conflict(resultado.Message);
            }
            else
            {
                return BadRequest(resultado.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuarioRemovido = service.Delete(id);
            if (usuarioRemovido != null)
            {
                var response = UsuarioMapper.ParaResponseDto(usuarioRemovido);
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
