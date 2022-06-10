using System.Collections.Generic;
using People.Models;

namespace People.Data
{
    public interface IUserRepo
    {
        Task<User> CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int? id);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
        Task<IEnumerable<User>> GetUsersByName(string name);
    }
}