using System.Collections.Generic;
using System.Linq;
using WebOlympiada.Data;
using WebOlympiada.Models;

namespace WebOlympiada.Repo
{
    public class sportovecRepo
    {
        private readonly ApplicationDbContext _context;

        public sportovecRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sportovec> GetAll()
        {
            return _context.Sportovec.ToList();
        }
    }
}