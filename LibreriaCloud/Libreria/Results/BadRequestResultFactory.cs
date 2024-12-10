using Libreria.Response;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())//restituisce un oggetto di tipo BadResponse
        {
            var retErrors = new List<string>();
            foreach (var key in context.ModelState)//cicla sul ModelState
            {
                var errors = key.Value.Errors;//verifica gli errori
                for (var i = 0; i < errors.Count(); i++)
                {
                    retErrors.Add(errors[0].ErrorMessage);//e se ce un errore per quella determinata chiave, aggiunge l'errore
                                                          //alla lista retErrors
                }

                var response = (BadResponse)Value;
                response.Errors = retErrors;

            }
        }
    }
}
