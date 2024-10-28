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
    public class SignClassificationService : ISignClassificationService
    {
        private readonly DataContext _context;

        public SignClassificationService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SignClassification>> GetSignClassificationsAsync()
        {
            return await _context.SignClassifications.ToListAsync();
        }

        public async Task<SignClassification> GetSignClassificationAsync(int id)
        {
            return await _context.SignClassifications.FindAsync(id);
        }

        public async Task<bool> UpdateSignClassificationAsync(int id, SignClassification signClassification)
        {
            if (id != signClassification.Id)
            {
                return false;
            }

            _context.Entry(signClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignClassificationExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<SignClassification> AddSignClassificationAsync(SignClassification signClassification)
        {
            _context.SignClassifications.Add(signClassification);
            await _context.SaveChangesAsync();
            return signClassification;
        }

        public async Task<bool> DeleteSignClassificationAsync(int id)
        {
            var signClassification = await _context.SignClassifications.FindAsync(id);
            if (signClassification == null)
            {
                return false;
            }

            _context.SignClassifications.Remove(signClassification);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool SignClassificationExists(int id)
        {
            return _context.SignClassifications.Any(e => e.Id == id);
        }
    }
}
