namespace Libreria.Request
{
    public class GetLibriPaginatiRequest
    {
        public int PageSize { get; set; } 
        public int PageNumber { get; set; } 
        public string? Autore { get; set; } 
 
    }
}
