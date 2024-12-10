using Libreria.Entita;
using Microsoft.AspNetCore.Identity;

namespace Libreria.ModelsDto
{
    public class UtenteDto
    {
        public UtenteDto()
        {
        }

        public UtenteDto(Utente utente)
        {
            Id = utente.Id_utente;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Email = utente.Email;
            Password= utente.Password;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
    }
}
