using FluentValidation;

using Libreria.Request;

namespace Libreria.Validators
{
    public class CreateLibroRequestValidator : AbstractValidator<CreateLibroRequest>
    {
        public CreateLibroRequestValidator()
        {
            RuleFor(m => m.Titolo)
                .NotEmpty()
                .WithMessage("Il campo titolo è obbligatorio");

            RuleFor(m => m.Autore)
                .NotEmpty()
                .WithMessage("Il campo autore è obbligatorio")
                ;

            RuleFor(m => m.Editore)
                .NotEmpty()
                .WithMessage("Il campo editore è obbligatorio");
          

            RuleFor(m => m.DataPubblicazione)
                .NotNull()
                .WithMessage("Il campo data di pubblicazione è obbligatorio")
                .LessThan(DateTime.Now)
                .WithMessage("La data di pubblicazione non può essere nel futuro");

            RuleFor(m => m.Categoria)
                .NotNull()
                .WithMessage("Il campo categoria è obbligatorio.")
                .NotEmpty()
                .WithMessage("Il campo categoria deve contenere almeno un elemento."); 

        }
    }
}

