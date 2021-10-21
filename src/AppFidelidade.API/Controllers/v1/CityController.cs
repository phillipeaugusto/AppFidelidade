using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Pagination;
using AppFidelidade.Core.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppFidelidade.API.Controllers.v1
{
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
}