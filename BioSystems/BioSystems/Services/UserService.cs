using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Data;
using BioSystems.Models;

namespace BioSystems.Services {
    public class UserService {
        private readonly AppDbContext _context;
        public UserService(AppDbContext dbContext) {
            _context = dbContext;
        }

        public async Task RegisterUser(string name, string email, string password) {
            try {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                var user = new User {
                    name = name,
                    email = email,
                    password = hashedPassword
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            } catch (Exception ex) {
                throw new InvalidOperationException("An error occurred while registering the user.", ex);
            }
        }
    }
}
