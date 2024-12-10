using Libreria.Abstractions.IService;
using Libreria.Request;
using Libreria.Response;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreaTokenAsync(CreateTokenRequest request)
        {

            try
            {
                var token = await _tokenService.CreaTokenAsync(request);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ResponseFactory.WithError<string>(ex.Message)); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseFactory.WithError<string>(ex.Message)); 
            }
        }
    }
}