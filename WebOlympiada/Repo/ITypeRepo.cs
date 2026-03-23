

namespace WebOlympiada.Repo
{
    public interface ITypeRepo
    {
        IEnumerable<Models.Type> GetAll();
    }
}