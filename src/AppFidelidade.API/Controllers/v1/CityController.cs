using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Domain.CommandServices.Shared;
using AppFidelidade.Domain.Constants;
using AppFidelidade.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = AppFidelidade.Domain.Shared.Contracts.IResult;

namespace AppFidelidade.API.Controllers.v1;

[Route("v1/city")]
public class CityController: ControllerBase
{
    [HttpGet]
    [Authorize(Roles = RolesConstant.RoleAdmUser)]
    public async Task<ActionResult<IResult>> GetAll(
        [FromServices] CityService service,
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
        [FromServices] CityService service,
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
}