using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
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
}