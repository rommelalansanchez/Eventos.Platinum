
using Eventos.Platinum.Library.BusinessServices;
using Eventos.Platinum.Library.HelperServices;
using Eventos.Platinum.Library.Models;
using Eventos.Platinum.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eventos.Platinum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly IEncryptorService _encryptorService;
        private readonly IEmailSender _emailSender;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login item)
        {
            try
            {
                string tokenFromSettings = _config.GetValue<string>("AppSettings:Token");
                if (string.IsNullOrEmpty(tokenFromSettings))
                {
                    throw new CustomException("No hay token de seguridad en configuración");
                }
                var token = await _authService.Login(item, tokenFromSettings);

                return StatusCode((int)HttpStatusCode.OK, new ServiceResponse<string>
                {
                    Data = token,
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
}
