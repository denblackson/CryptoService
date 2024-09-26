using System.ComponentModel;

namespace Entities
{
    public enum EncryptionAlgorithm
    {
        [Description("Advanced Encryption Standard")]
        AES,

        [Description("Data Encryption Standard")]
        DES,

        [Description("RC4 encryption")]
        RC4,

        [Description("CaesarCipher encryption")]
        CAES,

        [Description("Vigenère Cipher encryption")]
        VC
    }

}
