using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.Application.Models.Responses;
using Libreria.ModelsDto;
using Libreria.Request;
using Libreria.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Libreria.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class LibriController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly IValidator<CreateLibroRequest> _validator;

        public LibriController(ILibroService libroService, IValidator<CreateLibroRequest> validator)
        {
            _libroService = libroService;
            _validator = validator;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateLibroAsync(CreateLibroRequest request)
        {
          
            var validationResult = await _validator.ValidateAsync(request);


            var libro = request.ToEntity();
            
            await _libroService.AggiungiLibroAsync(libro);

            var response = new CreateLibroResponse();
            response.Libro = new LibroDto(libro);

            return Ok(ResponseFactory.WithSuccess(response));
        }


        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> ModificaLibroAsync(int id, ModificaLibroRequest request)
        {

   

            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound($"Libro con id {id} non trovato.");
            }


            libro.Titolo = request.Titolo;
            libro.Autore = request.Autore;
            libro.DataPubblicazione = request.DataPubblicazione;
            libro.Editore = request.Editore;
            libro.Categoria = request.Categoria;

            await _libroService.ModificaLibroAsync(libro);
            
            return Ok(ResponseFactory.WithSuccess(libro));
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> EliminaLibroAsync(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound(new { Messaggio = "Libro non trovato." });
            }

            await _libroService.EliminaLibroAsync(id);


            return Ok(new { Messaggio = "Libro eliminato con successo.", TitoloLibro = libro.Titolo });

        }
    }
}