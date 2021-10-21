using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Core.CommandServices;
using AppFidelidade.Core.CommandServices.Shared;
using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Dto.InputModelDto;
using AppFidelidade.Core.Pagination;
using AppFidelidade.Core.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppFidelidade.API.Controllers.v1
{
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
}