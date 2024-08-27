
using System.Security.Cryptography;

namespace DailyPlanner.Services.Hash
{
    public class Hash
    {
        //public static int SaltSize { get; set; } = 16;

        //public static string CreateHash(string password)
        //{
        //    byte[] salt;
        //    byte[] createBuffer;
        //    byte[] hash;

        //    if (password == null)
        //    {
        //        throw new ArgumentNullException("password");
        //    }

        //    using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
        //    {
        //        salt = RandomNumberGenerator.GetBytes(SaltSize);
        //        createBuffer = bytes.GetBytes(0x20);
        //    }

        //    hash = new byte[0x31];
        //    Buffer.BlockCopy(salt, 0, hash, 1, 0x10);
        //    Buffer.BlockCopy(createBuffer, 0, hash, 1, 0x10);
        //    return Convert.ToBase64String(hash);
        //}


        //public static bool VerifyHashedPassword(string hashedPassword, string password)
        //{
        //    if (hashedPassword == null)
        //    {
        //        return false;
        //    }

        //    if (password == null)
        //    {
        //        throw new ArgumentNullException("password");
        //    }

        //    string[] array = hash.Split(':');
        //    byte[] array2 = Convert.FromHexString(array[0]);
        //    byte[] salt = Convert.FromHexString(array[1]);
        //    byte[] second = Rfc2898DeriveBytes.Pbkdf2(secret, salt, Iterations, Algorithm, array2.Length);
        //    return array2.SequenceEqual(second);
        //}



        //public static string CreateHash(string secret)
        //{
        //    byte[] bytes = RandomNumberGenerator.GetBytes(SaltSize);
        //    byte[] inArray = Rfc2898DeriveBytes.Pbkdf2(secret, bytes, Iterations, Algorithm, KeySize);
        //    return string.Join(':', Convert.ToHexString(inArray), Convert.ToHexString(bytes));
        //}

        //public static bool Verify(string secret, string hash)
        //{
        //    string[] array = hash.Split(':');
        //    byte[] array2 = Convert.FromHexString(array[0]);
        //    byte[] salt = Convert.FromHexString(array[1]);
        //    byte[] second = Rfc2898DeriveBytes.Pbkdf2(secret, salt, Iterations, Algorithm, array2.Length);
        //    return array2.SequenceEqual(second);
        //}
    }
}
