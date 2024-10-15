using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Eventos.Platinum.Library
{
    public static class Helpers
    {
        private const string key = "";
        public static void CrearPassword(string password, out byte[] passwordHash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static string GetClaimFromToken(HttpRequest request, string claimType)
        {
            var result = "";

            if (request.Headers.TryGetValue("Authorization", out var bearer))
            {
                if (bearer.ToString().Length < 8)
                {
                    return "";
                }

                var jwtInput = bearer.ToString()[7..];
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtOutput = string.Empty;

                // Check Token Format
                if (!jwtHandler.CanReadToken(jwtInput))
                {
                    throw new Exception("The token doesn't seem to be in a proper JWT format.");
                }

                var token = jwtHandler.ReadJwtToken(jwtInput);

                var claim = token.Claims.FirstOrDefault(x => x.Type == claimType);
                if (claim != null)
                {
                    return claim.Value;
                }
            }
            return result;
        }
    }
}
