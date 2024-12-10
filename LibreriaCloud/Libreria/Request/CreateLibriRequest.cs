using Libreria.Database;
using Libreria.Entita;

namespace Libreria.Request
{
    public class CreateLibroRequest
    {
        public string Titolo { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; }
        public string Editore { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;

        public Libro ToEntity()
        {
            var libro = new Libro
            {
                Titolo = Titolo,
                Autore = Autore,
                DataPubblicazione = DataPubblicazione,
                Editore = Editore,
                Categoria = Categoria
            };
            return libro;
        }
    }
}
