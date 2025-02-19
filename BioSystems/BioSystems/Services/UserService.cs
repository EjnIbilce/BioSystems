    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Data;
using BioSystems.Exceptions;
using BioSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace BioSystems.Services {
    public class UserService {
        private readonly AppDbContext _context;
        public UserService(AppDbContext dbContext) {
            _context = dbContext;
        }
        public async Task<User?> LoginUser(string email, string password) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);

            if (user == null) {
                throw new UserNotFoundException();
            } else if (!BCrypt.Net.BCrypt.Verify(password, user.password)) {
                throw new WrongPasswordException();
            }

            return user;
        }

        public async Task RegisterUser(string name, string email, string password) {
            try {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                var user = new User {
                    name = name,
                    email = email,
                    password = hashedPassword
                };

                var pu = await _context.Users.FirstOrDefaultAsync(u => u.email == email);

                if (pu == null) {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                } else {
                    throw new UserAlreadyExistsException();
                }
            } catch (UserAlreadyExistsException) {
                throw new UserAlreadyExistsException();
            } catch (Exception ex) {
                throw new InvalidOperationException("Erro ao registrar o usuário", ex);
            }
        }
    }
}