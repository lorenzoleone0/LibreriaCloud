using Libreria.Entita;



namespace Libreria.ModelsDto
{
    public class LibroDto
    {
        public LibroDto()
        {
        }

        public LibroDto(Libro libro)
        {
            Id = libro.Id_libro;
            Titolo = libro.Titolo;
            Autore = libro.Autore;
            DataPubblicazione = libro.DataPubblicazione;
            Editore = libro.Editore;
            Categoria = libro.Categoria;
        }

        public int Id { get; set; }
        public string Titolo { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; }
        public string Editore { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;

    }
}

