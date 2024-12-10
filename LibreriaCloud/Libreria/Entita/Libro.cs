using System;
using System.Text.Json.Serialization;

namespace Libreria.Entita
{
    public class Libro
    {
        public int Id_libro { get; set; }
        public string Titolo { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; }
        public string Editore { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
    }
}



