
using Eventos.Platinum.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eventos.Platinum.API.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class UsuarioTipoController : ControllerBase
{

    public UsuarioTipoController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<List<object>>
            {
                //Data = model.ToList(),
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
}
