using Entities;
using System.Security.Cryptography;

public class AESEncryption : IEncryptionAlgorithm
{
    public string Encrypt(string plainText, string key)
    {
        // Отримуємо ключ фіксованого розміру
        byte[] keyBytes = EncryptionHelper.GetFixedSizeKey(key, 32); // AES-256 (32 байти)

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV(); // Генеруємо ініціалізаційний вектор (IV)

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                byte[] encrypted = msEncrypt.ToArray();
                byte[] result = new byte[aes.IV.Length + encrypted.Length];

                // Поєднуємо IV і зашифровані дані для передачі
                Array.Copy(aes.IV, 0, result, 0, aes.IV.Length);
                Array.Copy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

                return Convert.ToBase64String(result);
            }
        }
    }

    public string Decrypt(string cipherText, string key)
    {
        // Отримуємо ключ фіксованого розміру
        byte[] keyBytes = EncryptionHelper.GetFixedSizeKey(key, 32); // AES-256 (32 байти)
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            // Розділяємо IV і зашифровані дані
            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            aes.Key = keyBytes;
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipher))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                return srDecrypt.ReadToEnd();
            }
        }
    }
}
