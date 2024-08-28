using DailyPlanner.Services.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace DailyPlanner.Services
{
    public class HashService : IHashService
    {
        private readonly char separator = ':';

        public async Task<string> CreateHashPassword(string password)
        {
            byte[] salt;
            byte[] hash;
            byte[] key;

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            salt = RandomNumberGenerator.GetBytes(password.Length);

            using (SHA256 algoritm = SHA256.Create())
            {

                key = algoritm.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = algoritm.ComputeHash(Encoding.UTF8.GetBytes(string.Join(Convert.ToHexString(salt), Convert.ToHexString(key))));
            }


            return string.Join(separator, Convert.ToHexString(salt), Convert.ToHexString(hash));
        }


        public async Task<bool> VerifyHashedPassword(string hashPassword, string password)
        {
            byte[] hash;
            byte[] key;

            if (hashPassword == null)
            {
                throw new ArgumentNullException("hash");
            }

            if (password == null)
            {
                return false;
            }

            var array = hashPassword.Split(separator);

            using (SHA256 algoritm = SHA256.Create())
            {

                key = algoritm.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = algoritm.ComputeHash(Encoding.UTF8.GetBytes(string.Join(array[0], Convert.ToHexString(key))));
            }

            return array[1] == Convert.ToHexString(hash);
        }
    }
}
