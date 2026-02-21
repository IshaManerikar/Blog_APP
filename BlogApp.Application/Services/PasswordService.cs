using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlogApp.Application.Services
{
    public class PasswordService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public bool Verify(string enteredPassword, string storedHash)
        {
            var enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}
