using System.Security.Cryptography;

namespace DoQL.Utilities
{
    public class EncryptionUtils
    {
        private const int _saltSize = 8;

        public static void Encrypt(FileInfo targetFile, string content, string password)
        {
            var keyGenerator = new Rfc2898DeriveBytes(password, _saltSize);
            var cipher = Aes.Create();

            // convert BlockSize and KeySize from bits to bytes (divide by 8)
            cipher.IV = keyGenerator.GetBytes(cipher.BlockSize / 8);
            cipher.Key = keyGenerator.GetBytes(cipher.KeySize / 8);

            using var fileStream = targetFile.Create();

            // write salt
            fileStream.Write(keyGenerator.Salt, 0, _saltSize);

            // encrypt
            using var cryptoStream = new CryptoStream(fileStream, cipher.CreateEncryptor(), CryptoStreamMode.Write);

            // write data
            using var streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(content);
        }

        public static string Decrypt(FileInfo sourceFile, string password)
        {
            // read salt
            var fileStream = sourceFile.OpenRead();
            var salt = new byte[_saltSize];
            fileStream.Read(salt, 0, _saltSize);

            // initialize algorithm with salt
            var keyGenerator = new Rfc2898DeriveBytes(password, salt);

            var cipher = Aes.Create();
            cipher.IV = keyGenerator.GetBytes(cipher.BlockSize / 8);
            cipher.Key = keyGenerator.GetBytes(cipher.KeySize / 8);

            // decrypt
            using var cryptoStream = new CryptoStream(fileStream, cipher.CreateDecryptor(), CryptoStreamMode.Read);

            // read data
            using var streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }
    }
}
