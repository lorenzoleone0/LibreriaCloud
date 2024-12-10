using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.ModelsDto;
using Libreria.Request;
using Libreria.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Libreria.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class UtentiController : ControllerBase
    {
        private readonly IUtenteService _utenteService;
        private readonly IValidator<CreateUtenteRequest> _validator;
        public UtentiController(IUtenteService utenteService, IValidator<CreateUtenteRequest> validator)
        {
            _utenteService = utenteService;
            _validator = validator;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUtenteById(int id)
        {
            try
            {
                var utente = await _utenteService.GetUtenteByIdAsync(id);

                if (utente == null)
                {
                    return NotFound(new { Message = "Utente non trovato" });
                }

               
                var utenteDto = new UtenteDto(utente);
                return Ok(ResponseFactory.WithSuccess(utenteDto));
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero dell'utente", Error = ex.Message });
            }
        }


        [HttpPost]
        [Route("new")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUtente(CreateUtenteRequest request)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                
                return BadRequest(ResponseFactory.WithError(validationResult.Errors));
            }

            var utente = request.ToEntity();

            //utente.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _utenteService.AggiungiUtenteAsync(utente); 
            

            var response = new CreateUtenteResponse();
            response.Utente = new UtenteDto(utente);
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
