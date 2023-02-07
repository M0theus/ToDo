using AutoMapper;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Core.Exceptions;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;

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
            throw new DomainExceptions("Já existe um usuário cadastrado com o email informado.");
        }

        var user = _mapper.Map<User>(userDto);
        user.Validate(); //validação de dopminio

        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDto>(userCreated);
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        var userExists = await _userRepository.Get(userDto.Id);

        if (userExists == null)
        {
            throw new DomainExceptions("Não existe usuário com o Id informado.");
        }

        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userUpdated = await _userRepository.Update(user);

        return _mapper.Map<UserDto>(userUpdated);
    }

    public async Task Remove(int id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDto> Get(int id)
    {
        var user = await _userRepository.Get(id);

        if (user == null)
        {
            throw new DomainExceptions("Não existe usuário com o Id informado.");
        }

        return _mapper.Map<UserDto>(user);
    }
    
    public async Task<List<UserDto>> Get()
    {
        var allUsers = await _userRepository.Get();

        return _mapper.Map<List<UserDto>>(allUsers);
    }

    public async Task<List<UserDto>> SearchByName(string name)
    {
        var allUSer = await _userRepository.GetByName(name);

        return _mapper.Map<List<UserDto>>(allUSer);
    }

    public async Task<List<UserDto>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDto>>(allUsers);
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        if (user == null)
        {
            throw new DomainExceptions("Não existe usuário com o email informado");
        }

        return _mapper.Map<UserDto>(user);
    }
}