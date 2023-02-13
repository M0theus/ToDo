using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
using ToDo.API.ViewModels.AssigmentViewModel;
using ToDo.Application.DTO;
using ToDo.Application.Interfaces;

namespace ToDo.API.Controllers;

[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;
    
    public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
    {
        _assignmentService = assignmentService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("api/v1/assignment/creat")]
    public async Task<IActionResult> Create([FromBody] CreateAssignmentViewModel assignmentViewModel)
    {
        try
        {
            var assignmentDto = _mapper.Map<AssignmentDto>(assignmentViewModel);

            var userCreated = await _assignmentService.Create(assignmentDto);

            return Ok(new ResultViewModels
            {
                Message = "Usuário criado com sucesso",
                Success = true,
                Data = userCreated

            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
}