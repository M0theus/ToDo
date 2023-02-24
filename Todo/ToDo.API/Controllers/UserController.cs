using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
using ToDo.API.ViewModels.UserViewModel;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Core.Exceptions;

namespace ToDo.API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<UserDto>(userViewModel);

            var userCreated = await _userService.Create(userDto);

            return Ok(new ResultViewModels
            {
                Message = "Usuário criado com sucesso",
                Success = true,
                Data = userCreated

            });
        }
        catch (DomainExceptions ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch(Exception)
        {
            return StatusCode(500, Responses.ApplicartionErrorMensage());
        }
    }

    [HttpPut] //essa desgrça tá dando erro, olhar depois '-'
    [Route("api/v1/users/update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<UserDto>(userViewModel);

            var userUpdate = await _userService.Update(userDto);

            return Ok(new ResultViewModels
            {
                Message = "usuario atualizado com sucesso",
                Success = true,
                Data = userUpdate
            });
        }
        catch (DomainExceptions ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicartionErrorMensage());
        }
    }
    
    [Authorize]
    [HttpDelete]
    [Route("ap1/v1/users/remove{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.Remove(id);

            return Ok(new ResultViewModels
            {
                Message = "Usuario removido com sucesso",
                Success = true,
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/users/get{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhum usuário foi encontrado com o Id informado.",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "Usuário encontrado com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/users/get-all")]
    public async Task<IActionResult> get()
    {
        try
        {
             var allUsers= await _userService.Get();

            return Ok(new ResultViewModels
            {
                Message = "Usuário encontrados com sucesso",
                Success = true,
                Data = allUsers
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/users/get-by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email) 
    {
        try
        {
            var user = await _userService.GetByEmail(email);

            if (user == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhum usuário com o email informado foi encontrado",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "Usuário encontrado com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/users/search-by-email")]
    public async Task<IActionResult> SearchByEmail(string email) //erro quando não encontra nenhum usuário
    {
        try
        {
            var users = await _userService.SearchByEmail(email);

            if (users == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhum usuário com o email informado foi encontrado.",
                    Success = true,
                    Data = users
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "Usuários encontrados com sucesso.",
                Success = true,
                Data = users
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/users/search-by-name")]
    public async Task<IActionResult> SearchByName(string name) //essa desgraça não está prestando ;-;
    {
        try
        {
            var users = await _userService.SearchByName(name);

            if (name == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhum usuário foi encontrado com o nome informado",
                    Success = true,
                    Data = users
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "Usuário encontrado com sucesso",
                Success = true,
                Data = users
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
}