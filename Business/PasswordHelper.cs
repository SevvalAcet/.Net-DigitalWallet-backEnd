using System.Security.Cryptography;
using System.Text;

namespace Business
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashedpassword);
        }
    }
}