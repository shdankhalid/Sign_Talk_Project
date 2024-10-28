using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ISignClassificationService
    {
        Task<IEnumerable<SignClassification>> GetSignClassificationsAsync();
        Task<SignClassification> GetSignClassificationAsync(int id);
        Task<bool> UpdateSignClassificationAsync(int id, SignClassification signClassification);
        Task<SignClassification> AddSignClassificationAsync(SignClassification signClassification);
        Task<bool> DeleteSignClassificationAsync(int id);
        bool SignClassificationExists(int id);
    }
}
