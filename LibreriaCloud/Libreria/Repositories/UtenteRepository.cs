using Libreria.Database;
using Libreria.Entita;


namespace Libreria.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext context) : base(context)
        {
        }
    }
}
