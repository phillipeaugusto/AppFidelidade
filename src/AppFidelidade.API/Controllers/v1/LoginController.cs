using System;
using System.Threading.Tasks;
using AppFidelidade.Application.Services;
using AppFidelidade.Domain.CommandServices;
using AppFidelidade.Domain.Dto.InputModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = AppFidelidade.Domain.Shared.Contracts.IResult;

namespace AppFidelidade.API.Controllers.v1;

[Route("v1/login")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [Route("")]
    public async Task<ActionResult<IResult>> Login(
        [FromServices] LoginService service,
        [FromBody] LoginInputModelDto login
    )
        
    {
        try
        {
            var serviceCommand = new GetTokenByClientCommand(login);
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