using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IModeService
    {
        Task<IEnumerable<Mode>> GetModes();
        Task<Mode> GetMode(int id);
        Task<bool> UpdateMode(int id, Mode mode);
        Task<Mode> CreateMode(Mode mode);
        Task<bool> DeleteMode(int id);
    }
}
