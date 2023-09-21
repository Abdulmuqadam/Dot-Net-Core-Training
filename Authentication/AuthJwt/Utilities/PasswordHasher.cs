using System.Security.Cryptography;
using System.Text;

namespace AuthJwt.Utilities
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                byte[] saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                byte[] resultBytes = salt.Concat(hashBytes).ToArray();
                string hashedPassword = Convert.ToBase64String(resultBytes);
                return hashedPassword;
            }
        }

        public static bool VerifyPassword(string storedPassword, string password)
        {
            byte[] storedPasswordBytes = Convert.FromBase64String(storedPassword);
            byte[] salt = storedPasswordBytes.Take(16).ToArray();
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();

            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                byte[] resultBytes = salt.Concat(hashBytes).ToArray();
                string hashedPassword = Convert.ToBase64String(resultBytes);
                return storedPassword == hashedPassword;
            }
        }
    }
}
