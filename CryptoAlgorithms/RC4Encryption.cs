using Entities;
using System;
using System.Text;

public class RC4Encryption : IEncryptionAlgorithm
{
    public string Encrypt(string plainText, string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var cipherBytes = new byte[plainBytes.Length];

        var S = new byte[256];
        for (int i = 0; i < 256; i++)
            S[i] = (byte)i;

        int j = 0;
        for (int i = 0; i < 256; i++)
        {
            j = (j + S[i] + keyBytes[i % keyBytes.Length]) % 256;
            Swap(S, i, j);
        }

        int i2 = 0;
        j = 0;
        for (int k = 0; k < plainBytes.Length; k++)
        {
            i2 = (i2 + 1) % 256;
            j = (j + S[i2]) % 256;
            Swap(S, i2, j);
            cipherBytes[k] = (byte)(plainBytes[k] ^ S[(S[i2] + S[j]) % 256]);
        }

        return Convert.ToBase64String(cipherBytes); // Повертаємо у форматі Base64
    }

    public string Decrypt(string cipherText, string key)
    {
        var cipherBytes = Convert.FromBase64String(cipherText);
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var plainBytes = new byte[cipherBytes.Length];

        var S = new byte[256];
        for (int i = 0; i < 256; i++)
            S[i] = (byte)i;

        int j = 0;
        for (int i = 0; i < 256; i++)
        {
            j = (j + S[i] + keyBytes[i % keyBytes.Length]) % 256;
            Swap(S, i, j);
        }

        int i2 = 0;
        j = 0;
        for (int k = 0; k < cipherBytes.Length; k++)
        {
            i2 = (i2 + 1) % 256;
            j = (j + S[i2]) % 256;
            Swap(S, i2, j);
            plainBytes[k] = (byte)(cipherBytes[k] ^ S[(S[i2] + S[j]) % 256]);
        }

        return Encoding.UTF8.GetString(plainBytes); // Повертаємо розшифровану строку
    }

    private void Swap(byte[] array, int i, int j)
    {
        byte temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
