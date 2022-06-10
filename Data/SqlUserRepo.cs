using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using People.Models;

namespace People.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly UsersContext _context;

        public SqlUserRepo(UsersContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int? id)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            name = name.ToLower();
            var allUsers = await _context.Users.ToListAsync();
            var result = allUsers.FindAll(u => u.Name.ToLower().Contains(name));

            return result;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}