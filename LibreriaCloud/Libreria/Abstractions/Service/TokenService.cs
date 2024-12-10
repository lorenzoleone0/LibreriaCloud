using Libreria.Abstractions.IService;
using Libreria.JwtAuthentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Libreria.Database;
using Microsoft.EntityFrameworkCore;
using Libreria.Repositories;
using Libreria.Request;

namespace Libreria.Abstractions.Service
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        private readonly MyDbContext _dbContext; 
       
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, MyDbContext dbContext)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _dbContext = dbContext;
            
        }
        public async Task<string> CreaTokenAsync(CreateTokenRequest richiesta)
        {
            var utente = await _dbContext.Utenti
                .FirstOrDefaultAsync(u => u.Email == richiesta.Email);

            
            if (utente == null || utente.Password != richiesta.Password)
            {
                throw new UnauthorizedAccessException("Email o password non validi.");
            }
      

            List<Claim> claims = new List<Claim>
            {
                new Claim("Nome", utente.Nome),
                new Claim("Cognome", utente.Cognome),  
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthOption.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                _jwtAuthOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
