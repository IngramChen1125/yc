using Microsoft.EntityFrameworkCore;
using System;
using YC.Data;
using YC.Model;

namespace YC.Service
{
    public class UserService : IUserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {            
            var _user = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (_user != null)
            {
                // 更新帳號的欄位
                _user.Account = user.Account;
                _user.Password = user.Password;

                // 更新資料庫
                _context.Users.Update(_user);
                _context.SaveChanges();
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            { 
                return false;
            }

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
