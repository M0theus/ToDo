using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
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
    [Route("api/v1/assignmentList/create")] //deve estrar com erro
    public async Task<IActionResult> Create([FromBody] CreateAssignmentListViewModel assignmentListViewModel)
    {
        try
        {
            var assignmentListDto = _mapper.Map<AssignmentListDto>(assignmentListViewModel);

            var assignmentListCreate = await _assignmentListService.Create(assignmentListDto);

            return Ok(new ResultViewModels
            {
                Message = "AssignmentList criado com sucesso",
                Success = true,
                Data = assignmentListCreate

            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
    
    [HttpDelete]
    [Route("ap1/v1/assignmentList/remove{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _assignmentListService.Remove(id);

            return Ok(new ResultViewModels
            {
                Message = "AssignmentList removido com sucesso",
                Success = true,
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/assignmenList/get-by-name")]
    public async Task<IActionResult> GetByName(string name, int userId)
    {
        try
        {
            var assignmetList = await _assignmentListService.GetByName(name, userId);

            if (assignmetList == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhum AssignmenList com o nome informado foi encontrado",
                    Success = true,
                    Data = assignmetList
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "AssignmentList foi encontrado com sucesso",
                Success = true,
                Data = assignmetList
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/assignmentList/get{id}")]
    public async Task<IActionResult> Get(int id, int userId)
    {
        try
        {
            var assignmentList = await _assignmentListService.GetById(id, userId);

            if (assignmentList == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhuma AssignmentList foi encontrada com o Id informado.",
                    Success = true,
                    Data = assignmentList
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "AssignmentList encontrada com sucesso",
                Success = true,
                Data = assignmentList
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }

    [HttpGet]
    [Route("api/v1/assignmentList/get-all")]
    public async Task<IActionResult> GetAll(int userId)
    {
        try
        {
            var assignmentList = await _assignmentListService.GetAll(userId);

            if (assignmentList == null)
            {
                return Ok(new ResultViewModels
                {
                    Message = "Nenhuma AssignmentList foi encontrada com o userId informado",
                    Success = true,
                    Data = assignmentList
                });
            }

            return Ok(new ResultViewModels
            {
                Message = "AssignmentLists encontradas com sucesso!",
                Success = true,
                Data = assignmentList
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
}