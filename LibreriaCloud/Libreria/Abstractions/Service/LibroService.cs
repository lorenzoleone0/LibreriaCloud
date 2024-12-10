using Azure.Core;
using Libreria.Abstractions.IService;
using Libreria.Database;
using Libreria.Entita;
using Libreria.ModelsDto;
using Libreria.Repositories;
using Libreria.Request;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Libreria.Abstractions.Service
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _libroRepository;

        public LibroService(LibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
       
        }
        public async Task<Libro?> GetLibroByIdAsync(int id)
        {
            return await _libroRepository.GetByIdAsync(id); 
        }

        public async Task<List<Libro>> GetAllLibriAsync()
        {
            return await _libroRepository.GetAllAsync();
        }

        public async Task AggiungiLibroAsync(Libro libro)
        {
            await _libroRepository.AggiungiAsync(libro);
            await _libroRepository.SalvaAsync();
        }


        public async Task ModificaLibroAsync( Libro libro)
        {
            _libroRepository.Modifica(libro);
            await _libroRepository.SalvaAsync(); 
        }

        public async Task EliminaLibroAsync(int id)
        {
            await _libroRepository.EliminaAsync(id);
            await _libroRepository.SalvaAsync();
        }
    }
}
