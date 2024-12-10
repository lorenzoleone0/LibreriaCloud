using Libreria.Entita;

namespace Libreria.Request
{
    public class ModificaLibroRequest
    {

        public string Titolo { get; set; } = string.Empty; 

        public string Autore { get; set; } = string.Empty; 

        public DateTime DataPubblicazione { get; set; } 

        public string Editore { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

    }
}
