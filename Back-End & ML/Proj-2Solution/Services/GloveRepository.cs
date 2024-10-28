using Entities;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GloveRepository : IGloveRepository
    {
        private readonly DataContext _context;

        public GloveRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SmartGlove> GetSignClassifications()
        {
            return _context.SmartGloves.ToList();
        }
    }
}
