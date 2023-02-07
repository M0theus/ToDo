using ToDo.Application.DTO;

namespace ToDo.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> Create(UserDto userDto);
    Task<UserDto> Update(UserDto userDto);
    Task Remove(int id);

    Task<UserDto> Get(int id);
    Task<List<UserDto>> Get();
    Task<List<UserDto>> SearchByName(string name);
    Task<List<UserDto>> SearchByEmail(string email);
    Task<UserDto> GetByEmail(string email);
} 