using API_ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace API_ECommerce.Services
{
    public class PasswordService
    {
        // PASSWORDHASHER - PBKDF2
        private readonly PasswordHasher<Cliente> _hasher = new();
        //1 - Gerar um Hash
        public string HashPassword(Cliente cliente)
        {
            return _hasher.HashPassword(cliente, cliente.Senha);
        }
        //2 - Verificar o Hash
        public bool VerificarSenha(Cliente cliente, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada);
            return resultado == PasswordVerificationResult.Success;
        }
    }
}
