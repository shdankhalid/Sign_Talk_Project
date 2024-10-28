using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<bool> UpdateUser(int id, User user);
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> Register(User user);
        Task<string> Login(string email, string password);
    }
}
