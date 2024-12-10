using Libreria.Entita;
using Libreria.ModelsDto;
using Microsoft.AspNetCore.Components.Forms;

namespace Libreria.Request
{
    public class CreateUtenteRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Email = Email;
            utente.Password = Password;

            return utente;
        }
    }
}



