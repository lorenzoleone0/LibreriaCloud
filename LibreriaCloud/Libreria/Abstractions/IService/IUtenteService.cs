using Libreria.Entita;


namespace Libreria.Abstractions.IService
{
    public interface IUtenteService
    {
        Task<Utente?> GetUtenteByIdAsync(int id);
        Task<Utente?> GetByEmailAsync(string email);
        Task<Utente?> GetByEmailUtenteAsync(string email);
        Task AggiungiUtenteAsync(Utente utente);
        Task<bool> VerificaPasswordAsync(string email, string password);
    }
}
