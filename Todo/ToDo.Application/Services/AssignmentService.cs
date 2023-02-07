using AutoMapper;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Domain.Contracts.Repository;

namespace ToDo.Application.Services;

public class AssignmentService : IAssignmentService
{
    
    private readonly IMapper _mapper;
    private readonly IAssignmentRepository _assignmentRepository;
    
    public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
    }
    
    public async Task<AssignmentDto> Create(AssignmentDto assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.ge
    }

    public Task<AssignmentDto> Update(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentDto> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentDto>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentDto> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentDto>> SearchByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentDto>> SearchByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentDto> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentDto> GetByList(int id)
    {
        throw new NotImplementedException();
    }
}