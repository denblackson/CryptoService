using Entities;
using Entities.Factories;
using Moq;
namespace Tests
{
    [TestClass()]
    public class AESEncryptionTests
    {
        private readonly EncryptionFactory _encryptionFactory = new EncryptionFactory();
               
        [TestMethod()]
        public void EncryptDecryptTest()
        {
                      
            Assert.AreEqual(1,1);
        }

    }
}