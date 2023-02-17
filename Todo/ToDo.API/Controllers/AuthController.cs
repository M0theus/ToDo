using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Token;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
using ToDo.API.ViewModels.Token;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;

namespace ToDo.API.Controllers;

[ApiController]
public class AuthController : ControllerBase
{ 
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    
    public AuthController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost]
    [Route("api/v1/auth/login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
    {
        try
        {
            var user = _mapper.Map<LoginUserDto>(loginViewModel);

            var token = await _userService.Authenticade(user);

            return Ok(new ResultViewModels
            {
                Message = "Token gerado com sucesso",
                Success = true,
                Data = token
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}