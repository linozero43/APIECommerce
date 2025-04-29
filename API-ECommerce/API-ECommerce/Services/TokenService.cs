using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API_ECommerce.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            //Claims - Informações do Usuario que quero guardar
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email)
            };
            //criar uma chave de seguranca e criptografar
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-senai"));
        }
    }
}
