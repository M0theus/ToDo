using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AssignmentListService(IMapper mapper, IAssignmentListRepository assignmentListRepository, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _assignmentListRepository = assignmentListRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<AssignmentListDto> Create(AssignmentListDto assignmentListDto)
    {
        var assignmentListExists = await _assignmentListRepository.GetByName(assignmentListDto.Name, GetUserId());

        if (assignmentListExists != null)
        {
            throw new DomainExceptions("Já existe uma lista com o nome informado");
        }

        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.Validate();


        assignmentList.UserId = GetUserId();
        var assignmentListCreate = await _assignmentListRepository.Create(assignmentList);

        return _mapper.Map<AssignmentListDto>(assignmentListCreate);
    }

    public async Task<AssignmentListDto> Update(AssignmentListDto assignmentListDto)
    {
        var assignmenListExists = await _assignmentListRepository.GetById(assignmentListDto.Id, GetUserId());

        if (assignmenListExists == null)
        {
            throw new DomainExceptions("Não existe lista com o Id informado");
        }

        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.Validate();

        var assignmentListUpdate = await _assignmentListRepository.Update(assignmentList);

        return _mapper.Map<AssignmentListDto>(assignmentListUpdate);
    }

    public async Task<AssignmentListDto> GetByName(string name)
    {
        var assignmetList = await _assignmentListRepository.GetByName(name, GetUserId());

        if (assignmetList == null)
        {
            throw new DomainExceptions("Não existe lista com o nome informado");
        }

        return _mapper.Map<AssignmentListDto>(assignmetList);
    }

    public async Task<List<AssignmentListDto>> SearchByName(string name)
    {
        var allAssignmentList = await _assignmentListRepository.SearchByName(name, GetUserId());

        return _mapper.Map<List<AssignmentListDto>>(allAssignmentList);
    }

    public async Task Remove(int id)
    { 
        await _assignmentListRepository.Remove(id);
    }

    public async Task<AssignmentListDto> GetById(int id)
    {
        var assignmentList = await _assignmentListRepository.GetById(id, GetUserId());

        if (assignmentList == null)
        {
            throw new DomainExceptions("Não existe AssignmentList com o Id informado");
        }

        return _mapper.Map<AssignmentListDto>(assignmentList);
    }

    public async Task<List<AssignmentListDto>> GetAll()
    {
        var assignmentLists = await _assignmentListRepository.GetAll(GetUserId());

        return _mapper.Map<List<AssignmentListDto>>(assignmentLists);
    }

    private int GetUserId()
    {
        var claim = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id");
        if (claim == null)
            return 0;
        
        return string.IsNullOrWhiteSpace(claim.Value) ? 0 : int.Parse(claim.Value);
    }
}