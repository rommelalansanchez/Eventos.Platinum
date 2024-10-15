using Eventos.Platinum.Library.BusinessServices;
using Eventos.Platinum.Library.Models;
using Eventos.Platinum.Shared.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Eventos.Platinum.Library.BusinessServices.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioService _usuarioDataService;

        public AuthService(IUsuarioService usuarioDataService)
        {
            _usuarioDataService = usuarioDataService;
        }
        public async Task<string> Login(Login model, string configurationToken)
        {
            var user = (await _usuarioDataService.GetAllAsync()).Where(x => string.Equals(x.NombreUsuario, model.NombreUsuario, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (user == null) throw new CustomException($"El usuario {model.NombreUsuario} no existe.");

            if (!PasswordCorrecta(model.Password, user.PasswordHash, user.Salt))
            {
                throw new CustomException("Contraseña incorrecta.");
            }

            return CreateToken(user.UsuarioId, user.NombreUsuario, user.UsuarioTipoId, configurationToken);
        }

        public static bool PasswordCorrecta(string password, byte[] passwordHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private static string CreateToken(int usuarioId, string nombreUsuario, int usuarioTipoId, string configurationToken)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
                new Claim(ClaimTypes.Name, nombreUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioTipoId.ToString()) //Admin or not

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationToken));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return jwt;

        }
    }
}
