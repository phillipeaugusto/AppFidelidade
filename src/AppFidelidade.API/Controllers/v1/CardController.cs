using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.CommandServices.Shared;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Dto.InputModelDto;
using AppFidelidade.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = AppFidelidade.Domain.Shared.Contracts.IResult;

namespace AppFidelidade.API.Controllers.v1;

[Route("v1/card")]
public class CardController: ControllerBase
{
    [HttpGet]
    [Authorize(Roles = RolesConstant.RoleAdministrator)]
    public async Task<ActionResult<IResult>> GetAll(
        [FromServices] CardService service,
        [FromQuery] PaginationParameters paginationParameters
    )
        
    {
        try
        {
            var serviceCommand = new GetAllPaginationService(paginationParameters);
            var result = await service.Service(serviceCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
        
    [Route("{id}")]
    [HttpGet]
    [Authorize(Roles = RolesConstant.RoleAdmUser)]
    public async Task<ActionResult<IResult>> GetById(
        [FromServices] CardService service,
        Guid id
    )
        
    {
        try
        {
            var serviceCommand = new GetByIdService(id);
            var result = await service.Service(serviceCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
        
    [Route("client/{id}")]
    [HttpGet]
    [Authorize(Roles = RolesConstant.RoleAdmUser)]
    public async Task<ActionResult<IResult>> GetByClientId(
        [FromServices] CardService service,
        Guid id
    )
    {
        try
        {
            var serviceCommand = new GetCardByClientIdCommand(id);
            var result = await service.Service(serviceCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
        
    [HttpPost]
    [Authorize(Roles = RolesConstant.RoleAdmUser)]
    public async Task<ActionResult<IResult>> Create(
        [FromServices] CardService service,
        [FromBody] CardInputModelDto cardInputModelDto
    )
    {
        try
        {
            var serviceCommand = new CreateCardServiceCommand(cardInputModelDto);
            var result = await service.Service(serviceCommand);
                
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}