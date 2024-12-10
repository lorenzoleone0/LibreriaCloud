using Libreria.Request;

namespace Libreria.Abstractions.IService
{
    public interface ITokenService
    {
        Task<string> CreaTokenAsync(CreateTokenRequest richiesta);
    }
} 

