using WebOlympiada.Data;
using Type= WebOlympiada.Models.Type;

namespace WebOlympiada.Repo
{
    public class TypeRepo(ApplicationDbContext context) : ITypeRepo
    {

        public IEnumerable<Type> GetAll()
        {
            return context.Types.ToList();
        }
    }
}
