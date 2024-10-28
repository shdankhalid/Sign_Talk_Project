using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ModeService : IModeService
    {
        private readonly DataContext _context;

        public ModeService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mode>> GetModes()
        {
            return await _context.Modes.ToListAsync();
        }

        public async Task<Mode> GetMode(int id)
        {
            return await _context.Modes.FindAsync(id);
        }

        public async Task<bool> UpdateMode(int id, Mode mode)
        {
            if (id != mode.ModeId)
            {
                return false;
            }

            _context.Entry(mode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !ModeExists(id);
            }

            return true;
        }

        public async Task<Mode> CreateMode(Mode mode)
        {
            _context.Modes.Add(mode);
            await _context.SaveChangesAsync();

            return mode;
        }

        public async Task<bool> DeleteMode(int id)
        {
            var mode = await _context.Modes.FindAsync(id);
            if (mode == null)
            {
                return false;
            }

            _context.Modes.Remove(mode);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool ModeExists(int id)
        {
            return _context.Modes.Any(e => e.ModeId == id);
        }
    }

}
