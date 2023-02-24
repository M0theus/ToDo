using AutoMapper;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;
using ToDo.Core.Exceptions;
using ToDo.Domain.Contracts.Repository;
using ToDo.Domain.Models;

namespace ToDo.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    private readonly IMapper _mapper;
    private readonly IAssignmentListRepository _assignmentListRepository;

    public AssignmentListService(IMapper mapper, IAssignmentListRepository assignmentListRepository)
    {
        _mapper = mapper;
        _assignmentListRepository = assignmentListRepository;
    }
    
    public async Task<AssignmentListDto> Create(AssignmentListDto assignmentListDto)
    {
        var assignmentListExists = await _assignmentListRepository.SearchByName(assignmentListDto.Name);

        if (assignmentListExists == null) //tá bugado kakkakaka
        {
            throw new DomainExceptions("Já existe uma lista com o nome informado");
        }

        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.Validate();

        var assignmentListCreate = await _assignmentListRepository.Create(assignmentList);

        return _mapper.Map<AssignmentListDto>(assignmentListCreate);
    }

    public async Task<AssignmentListDto> Update(AssignmentListDto assignmentListDto)
    {
        var assignmenListExists = await _assignmentListRepository.GetById(assignmentListDto.Id, assignmentListDto.UserId);

        if (assignmenListExists == null)
        {
            throw new DomainExceptions("Não existe lista com o Id informado");
        }

        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.Validate();

        var assignmentListUpdate = await _assignmentListRepository.Update(assignmentList);

        return _mapper.Map<AssignmentListDto>(assignmentListUpdate);
    }

    public async Task<AssignmentListDto> GetByName(string name, int userId)
    {
        var assignmetList = await _assignmentListRepository.GetByName(name, userId);

        if (assignmetList == null)
        {
            throw new DomainExceptions("Não existe lista com o nome informado");
        }

        return _mapper.Map<AssignmentListDto>(assignmetList);
    }

    public async Task<List<AssignmentListDto>> SearchByName(string name)
    {
        var allAssignmentList = await _assignmentListRepository.SearchByName(name);

        return _mapper.Map<List<AssignmentListDto>>(allAssignmentList);
    }

    public async Task Remove(int id)
    { 
        await _assignmentListRepository.Remove(id);
    }

    public async Task<AssignmentListDto> GetById(int id, int userId)
    {
        var assignmentList = await _assignmentListRepository.GetById(id, userId);

        if (assignmentList == null)
        {
            throw new DomainExceptions("Não existe AssignmentList com o Id informado");
        }

        return _mapper.Map<AssignmentListDto>(assignmentList);
    }

    public async Task<List<AssignmentListDto>> GetAll(int userId)
    {
        var assignmentLists = await _assignmentListRepository.GetAll(userId);

        return _mapper.Map<List<AssignmentListDto>>(assignmentLists);
    }
}