using Entities;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class DESEncryption : IEncryptionAlgorithm
{
    public string Encrypt(string plainText, string key)
    {
        // Отримуємо ключ фіксованого розміру
        byte[] keyBytes = EncryptionHelper.GetFixedSizeKey(key, 8); // DES (8 байт)

        using (DESCryptoServiceProvider des = new())
        {
            des.Key = keyBytes;
            des.GenerateIV(); // Генеруємо ініціалізаційний вектор (IV)

            ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                byte[] encrypted = msEncrypt.ToArray();
                byte[] result = new byte[des.IV.Length + encrypted.Length];

                // Поєднуємо IV і зашифровані дані для передачі
                Array.Copy(des.IV, 0, result, 0, des.IV.Length);
                Array.Copy(encrypted, 0, result, des.IV.Length, encrypted.Length);

                return Convert.ToBase64String(result);
            }
        }
    }

    public string Decrypt(string cipherText, string key)
    {
        // Отримуємо ключ фіксованого розміру
        byte[] keyBytes = EncryptionHelper.GetFixedSizeKey(key, 8); // DES (8 байт)
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using (DESCryptoServiceProvider des = new ())
        {
            byte[] iv = new byte[des.BlockSize / 8];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            // Розділяємо IV і зашифровані дані
            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            des.Key = keyBytes;
            des.IV = iv;

            ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipher))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                return srDecrypt.ReadToEnd();
            }
        }
    }
}
