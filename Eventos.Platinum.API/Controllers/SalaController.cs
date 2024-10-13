
using Eventos.Platinum.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eventos.Platinum.API.Controllers;

[Route("api/[controller]")]
//[ApiController, Authorize]
[ApiController]
public class SalaController : ControllerBase
{

    public SalaController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await Task.FromResult(new List<string> { "Sala 1", "Sala 2", "Sala 3" });
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<List<string>>
            {
                Data = result,
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new ServiceResponse<dynamic>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> Get(int usuarioId)
    {
        try
        {
            await Task.FromResult(usuarioId);
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<bool>
            {
                //Data = model,
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new ServiceResponse<dynamic>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] object item)
    {
        try
        {
            await Task.FromResult(item);
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<int>
            {
                //Data = item.UsuarioId,
                Success = true
            });
        }
        catch (CustomException cex)
        {
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<dynamic>
            {
                Success = false,
                Message = cex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new ServiceResponse<dynamic>
            {
                Success = false,
                Message = ex.Message
            });
        }

    }

    [HttpPost("{usuarioId}/cambiarpassword"), Authorize]
    public async Task<IActionResult> Post([FromRoute] int usuarioId, [FromBody] object item)
    {
        try
        {
            await Task.FromResult(item);
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<bool>
            {
                Data = true,
                Success = true
            });
        }
        catch (CustomException cex)
        {
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<dynamic>
            {
                Success = false,
                Message = cex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new ServiceResponse<dynamic>
            {
                Success = false,
                Message = ex.Message
            });
        }

    }
}
