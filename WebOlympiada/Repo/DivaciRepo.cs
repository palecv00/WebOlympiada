using System.Collections.Generic;
using System.Linq;
using WebOlympiada.Data;
using WebOlympiada.Models;

namespace WebOlympiada.Repo
{
    public class DivaciRepo
    {
        private readonly ApplicationDbContext _context;

        public DivaciRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Divaci> GetAll()
        {
            return _context.Divaci.ToList();
        }
    }
}