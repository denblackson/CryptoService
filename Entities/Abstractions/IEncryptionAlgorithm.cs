namespace Entities
{
    public interface IEncryptionAlgorithm
    {
        string Encrypt(string text, string key);
        string Decrypt(string encryptedText, string key);
    }
}
