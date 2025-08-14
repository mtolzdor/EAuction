using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> AddUser(string username, string email, string password)
        {
            var account = await _context.Users.AnyAsync(u => u.UserName == username || u.Email == email);
            if (account)
            {
                return null;
            }

            var user = new UserEntity();
            var passwordHasher = new PasswordHasher<UserEntity>();


            user.UserName = username;
            user.Email = email;
            user.Role = "Admin"; // Default role, added for simplicity
            user.Password = passwordHasher.HashPassword(user, password);


            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<UserEntity?> GetUserByCredentials(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<UserEntity>();

            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }
    }
}