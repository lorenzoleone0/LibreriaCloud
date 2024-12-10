using Libreria.ModelsDto;

namespace Libreria.Response
{
    public class GetLibriPaginatiResponse 
    {
        public int NumeroPagine { get; set; }
        public List<LibroDto> Libri { get; set; } = new List<LibroDto>();
        public string? MessaggioErrore { get; set; }
    }
}
