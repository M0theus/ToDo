using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Core.Exceptions;

namespace ToDo.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    
    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> Create(UserDto userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);

        if (userExists != null)
        {
            throw new DomainExceptions("");
        }

        var user = _mapper.Map<User>(userDto);
        user.Validate(); //validação de dopminio

        var userCreated = await _userRepository.Create(user);
        
        return _mapper.Map<UserDto>(User)
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserDto>> SearchByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserDto>> SearchByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}