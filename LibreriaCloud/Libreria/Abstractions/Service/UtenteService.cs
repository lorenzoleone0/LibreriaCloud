using Libreria.Entita;
using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.Repositories;
using Libreria.Request;


namespace Libreria.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        
        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }
        public async Task<Utente?> GetUtenteByIdAsync(int id)
        {
            return await _utenteRepository.GetByIdAsync(id);
        }

        public async Task<Utente?> GetByEmailAsync(string email)
        {
            return await _utenteRepository.GetByEmailAsync(email);
        }
        public async Task<Utente?> GetByEmailUtenteAsync(string email)
        {
            return await _utenteRepository.GetByEmailUtenteAsync(email);
        }

        public async Task<bool> VerificaPasswordAsync(string email, string password)
        {
            return await _utenteRepository.VerificaPasswordAsync(email, password);
        }

        public async Task AggiungiUtenteAsync(Utente utente)
        {
            await _utenteRepository.AggiungiAsync(utente);
            await _utenteRepository.SalvaAsync();
        }

    }
}
