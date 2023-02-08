using AutoMapper;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Core.Exceptions;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;

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
        var assignmentExists = await _assignmentRepository.GetByName(assignmentDto.Name);

        if (assignmentExists != null)
        {
            throw new DomainExceptions("Já existe uma task com esse nome");
        }

        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();

        var assignmentCreate = await _assignmentRepository.Create(assignment);

        return _mapper.Map<AssignmentDto>(assignmentCreate);
    }

    public async Task<AssignmentDto> Update(AssignmentDto assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.GetById(assignmentDto.Id, assignmentDto.UserId);

        if (assignmentExists == null)
        {
            throw new DomainExceptions("Não existe nenhuma task com esse Id");
        }

        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();

        var assignmentUpdate = await _assignmentRepository.Update(assignment);

        return _mapper.Map<AssignmentDto>(assignmentUpdate);

    }

    public async Task Remove(int id)
    {
        await _assignmentRepository.Remove(id);
    }

    public async Task<AssignmentDto> Get(int id)
    {
        var assignment = await _assignmentRepository.Get(id);

        if (assignment == null)
        {
            throw new DomainExceptions("Não existe nenhuma task com o Id informado");
        }

        return _mapper.Map<AssignmentDto>(assignment);
    }

    public async Task<List<AssignmentDto>> Get()
    {
        var allAssignments = await _assignmentRepository.Get();

        return _mapper.Map<List<AssignmentDto>>(allAssignments);
    }

    public async Task<AssignmentDto> GetByName(string name)
    {
        var assignment = await _assignmentRepository.GetByName(name);

        if (assignment == null)
        {
            throw new Exception("Não existe nenhuma task com esse nome");
        }

        return _mapper.Map<AssignmentDto>(assignment);
    }

    public async Task<List<AssignmentDto>> SearchByName(string name)
    {
        var allAssignments = await _assignmentRepository.SearchByName(name);

        return _mapper.Map<List<AssignmentDto>>(allAssignments);
    }
}