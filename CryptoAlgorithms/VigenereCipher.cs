using Entities;
using System.Text;

public class VigenereCipher : IEncryptionAlgorithm
{
    public string Encrypt(string plainText, string key)
    {
        return ProcessText(plainText, key, encrypt: true);
    }

    public string Decrypt(string cipherText, string key)
    {
        return ProcessText(cipherText, key, encrypt: false);
    }

    private string ProcessText(string text, string key, bool encrypt)
    {
        StringBuilder result = new StringBuilder();
        int keyLength = key.Length;

        for (int i = 0, j = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (char.IsLetter(c))
            {
                // Отримуємо символ з ключа (ігноруємо не літерні символи)
                char keyChar = key[j % keyLength];
                int shift = char.ToLower(keyChar) - 'a'; // Зсув на основі ключа

                if (!encrypt)
                {
                    shift = -shift; // Якщо розшифрування, зсув буде негативним
                }

                char offset = char.IsUpper(c) ? 'A' : 'a';
                char processedChar = (char)((((c + shift) - offset + 26) % 26) + offset);
                result.Append(processedChar);

                j++; // Збільшуємо індекс ключа лише для літера
            }
            else
            {
                result.Append(c); // Залишаємо символи, які не є літерами, незмінними
            }
        }

        return result.ToString();
    }
}
