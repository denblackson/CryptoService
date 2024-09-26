using System.Security.Cryptography;
using System.Text;

namespace Entities
{
    public class EncryptionHelper
    {
        public static byte[] GetFixedSizeKey(string key, int sizeInBytes)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] hash = sha256.ComputeHash(keyBytes);

                byte[] fixedSizeKey = new byte[sizeInBytes];
                Array.Copy(hash, fixedSizeKey, Math.Min(hash.Length, sizeInBytes));
                return fixedSizeKey;
            }
        }
    }

}
