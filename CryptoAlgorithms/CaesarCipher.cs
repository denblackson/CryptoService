using Entities;
using System;
using System.Text;

public class CaesarCipher : IEncryptionAlgorithm
{
    public string Encrypt(string plainText, string key)
    {
        return ProcessText(plainText, key, true);
    }

    public string Decrypt(string cipherText, string key)
    {
        return ProcessText(cipherText, key, false);
    }

    private string ProcessText(string text, string key, bool encrypt)
    {
        StringBuilder result = new StringBuilder();
        int keyLength = key.Length;

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (char.IsLetter(c))
            {
                // Визначаємо зсув на основі символу з ключа
                int shift = (key[i % keyLength] - 'A') % 26; // Зберігаємо зсув в межах 0-25
                if (!encrypt) // Для дешифрування зсув потрібно взяти в зворотному напрямку
                {
                    shift = -shift;
                }
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char processedChar = (char)((((c + shift) - offset + 26) % 26) + offset);
                result.Append(processedChar);
            }
            else
            {
                // Залишаємо символи, які не є літерами, незмінними
                result.Append(c);
            }
        }

        return result.ToString();
    }
}
