
using Libreria.Entita;


namespace Libreria.Abstractions.IService
{
    public interface ILibroService
    {
        Task<Libro?> GetLibroByIdAsync(int id);
        Task<List<Libro>> GetAllLibriAsync();
        Task ModificaLibroAsync(Libro libro);
        Task EliminaLibroAsync(int id);
        Task AggiungiLibroAsync(Libro libro);
    }
}

