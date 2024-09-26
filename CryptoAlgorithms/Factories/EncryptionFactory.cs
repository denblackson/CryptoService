namespace Entities.Factories
{
    public class EncryptionFactory
    {
        public IEncryptionAlgorithm GetEncryptionAlgorithm(EncryptionAlgorithm algorithm)
        {
            return algorithm switch
            {
                EncryptionAlgorithm.AES => new AESEncryption(),
                EncryptionAlgorithm.DES => new DESEncryption(),
                EncryptionAlgorithm.RC4 => new RC4Encryption(),
                EncryptionAlgorithm.CAES => new CaesarCipher(),
                EncryptionAlgorithm.VC => new VigenereCipher(),
                _ => throw new ArgumentException("Unknown encryption algorithm")
            };
        }
    }


}
