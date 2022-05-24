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

[Route("v1/client")]
public class ClientController: ControllerBase
{
    [HttpGet]
    [Authorize(Roles = RolesConstant.RoleAdministrator)]
    public async Task<ActionResult<IResult>> GetAll(
        [FromServices] ClientService service,
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
        [FromServices] ClientService service,
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
        
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<IResult>> Create(
        [FromServices] ClientService service,
        [FromBody] ClientInputModelDto clientInputModelDto
    )
        
    {
        try
        {
            var serviceCommand = new CreateClientServiceCommand(clientInputModelDto);
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
        
    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = RolesConstant.RoleAdministrator)]
    public async Task<ActionResult<IResult>> Update(
        [FromServices] ClientService service,
        [FromBody] ClientInputModelDto clientInputModelDto,
        Guid id
    )
        
    {
        try
        {
            var serviceCommand = new UpdateClientServiceCommand(clientInputModelDto, id);
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