using Entities;
using Entities.Factories;
using Microsoft.AspNetCore.Mvc;

namespace CryptoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptionController : ControllerBase
    {
       private readonly EncryptionFactory _encryptionFactory = new EncryptionFactory();

        [HttpPost("encrypt/AdvancedEncryptionStandard")]
        public ActionResult<string> EncryptAes([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.AES);
            var encrypted = algorithm.Encrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "AdvancedEncryptionStandard", EncryptedText = encrypted });
        }

        [HttpPost("decrypt/AdvancedEncryptionStandard")]
        public ActionResult<string> DecryptAes([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.AES);
            var decrypted = algorithm.Decrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "AdvancedEncryptionStandard", DecryptedText = decrypted });
        }

        [HttpPost("encrypt/DataEncryptionStandard")]
        public ActionResult<string> EncryptDes([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.DES);
            var encrypted = algorithm.Encrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "DataEncryptionStandard", EncryptedText = encrypted });
        }

        [HttpPost("decrypt/DataEncryptionStandard")]
        public ActionResult<string> DecryptDes([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.DES);
            var decrypted = algorithm.Decrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "DataEncryptionStandard", DecryptedText = decrypted });
        }

        [HttpPost("encrypt/CaesarCipher")]
        public ActionResult<string> EncryptCaesar([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.CAES);
            var encrypted = algorithm.Encrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "CaesarCipher", EncryptedText = encrypted });
        }

        [HttpPost("decrypt/CaesarCipher")]
        public ActionResult<string> DecryptCaesar([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.CAES);
            var decrypted = algorithm.Decrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "CaesarCipher", DecryptedText = decrypted });
        }

        [HttpPost("encrypt/RC4")]
        public ActionResult<string> EncryptRC4([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.RC4);
            var encrypted = algorithm.Encrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "RC4", EncryptedText = encrypted });
        }

        [HttpPost("decrypt/RC4")]
        public ActionResult<string> DecryptRC4([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.RC4);
            var decrypted = algorithm.Decrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "RC4", DecryptedText = decrypted });
        }

        [HttpPost("encrypt/VigenereCipher")]
        public ActionResult<string> EncryptVC([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.VC);
            var encrypted = algorithm.Encrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "VigenereCipher", EncryptedText = encrypted });
        }

        [HttpPost("decrypt/VigenereCipher")]
        public ActionResult<string> DecryptVC([FromBody] EncryptionRequest request)
        {
            var algorithm = _encryptionFactory.GetEncryptionAlgorithm(EncryptionAlgorithm.VC);
            var decrypted = algorithm.Decrypt(request.Text, request.Key);
            return Ok(new { Algorithm = "VigenereCipher", DecryptedText = decrypted });
        }
    }


}
