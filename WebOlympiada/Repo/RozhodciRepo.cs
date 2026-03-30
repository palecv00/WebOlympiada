using System.Collections.Generic;
using System.Linq;
using WebOlympiada.Data;
using WebOlympiada.Models;

namespace WebOlympiada.Repo
{
    public class RozhodciRepo
    {
        private readonly ApplicationDbContext _context;

        public RozhodciRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rozhodci> GetAll()
        {
            return _context.Rozhodci.ToList();
        }
    }
}
