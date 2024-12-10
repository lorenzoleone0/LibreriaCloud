using FluentValidation;
using Libreria.Repositories;
using Libreria.Request;


namespace Libreria.Validatori
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        private readonly UtenteRepository _utenteRepository;

        public CreateUtenteRequestValidator(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("L'email è obbligatoria.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$") 
                .WithMessage("Inserisci un'email valida.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .MinimumLength(6)
                .WithMessage("il campo password deve essere almeno lungo 6 caratteri")
                .Matches("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$")
                .WithMessage("Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale");
        }
   
    }
}
