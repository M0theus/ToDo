using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
using ToDo.API.ViewModels.AssigmentViewModel;
using ToDo.API.ViewModels.AssignmentListViewModel;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;

namespace ToDo.API.Controllers;

[ApiController]
public class AssignmentListController : ControllerBase
{
    private readonly IAssignmentListService _assignmentListService;
    private readonly IMapper _mapper;
    
    public AssignmentListController(IAssignmentListService assignmentListService, IMapper mapper)
    {
        _assignmentListService = assignmentListService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("api/v1/assignmentList/creat")]
    public async Task<IActionResult> Create([FromBody] CreateAssignmentListViewModel assignmentListViewModel)
    {
        try
        {
            var assignmentListDto = _mapper.Map<AssignmentListDto>(assignmentListViewModel);

            var assignmentListCreate = await _assignmentListService.Create(assignmentListDto);

            return Ok(new ResultViewModels
            {
                Message = "Usuário criado com sucesso",
                Success = true,
                Data = assignmentListCreate

            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
}