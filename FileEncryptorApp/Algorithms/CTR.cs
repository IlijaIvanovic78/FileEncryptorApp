using System;
using System.Security.Cryptography;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class CTR
    {
        private const int BLOCK_SIZE = 16; // 128 bits
        
        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];
            
            // Generate key and IV from the key string
            byte[] keyBytes = GenerateKey(key);
            byte[] iv = GenerateIV(key);
            
            // Store original length + IV + encrypted data
            byte[] result = new byte[4 + BLOCK_SIZE + data.Length];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);
            iv.CopyTo(result, 4);
            
            // CTR mode encryption
            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.ECB; // We'll implement CTR manually
                aes.Padding = PaddingMode.None;
                
                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] counter = new byte[BLOCK_SIZE];
                    iv.CopyTo(counter, 0);
                    
                    int offset = 4 + BLOCK_SIZE;
                    for (int i = 0; i < data.Length; i += BLOCK_SIZE)
                    {
                        // Encrypt the counter
                        byte[] keystream = new byte[BLOCK_SIZE];
                        encryptor.TransformBlock(counter, 0, BLOCK_SIZE, keystream, 0);
                        
                        // XOR with data
                        int blockSize = Math.Min(BLOCK_SIZE, data.Length - i);
                        for (int j = 0; j < blockSize; j++)
                        {
                            result[offset + i + j] = (byte)(data[i + j] ^ keystream[j]);
                        }
                        
                        // Increment counter
                        IncrementCounter(counter);
                    }
                }
            }
            
            return result;
        }
        
        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 4 + BLOCK_SIZE) return new byte[0];
            
            // Generate key from the key string
            byte[] keyBytes = GenerateKey(key);
            
            // Extract original length and IV
            int originalLength = BitConverter.ToInt32(data, 0);
            byte[] iv = new byte[BLOCK_SIZE];
            Array.Copy(data, 4, iv, 0, BLOCK_SIZE);
            
            byte[] result = new byte[originalLength];
            
            // CTR mode decryption (same as encryption)
            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.ECB; // We'll implement CTR manually
                aes.Padding = PaddingMode.None;
                
                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] counter = new byte[BLOCK_SIZE];
                    iv.CopyTo(counter, 0);
                    
                    int offset = 4 + BLOCK_SIZE;
                    for (int i = 0; i < originalLength; i += BLOCK_SIZE)
                    {
                        // Encrypt the counter
                        byte[] keystream = new byte[BLOCK_SIZE];
                        encryptor.TransformBlock(counter, 0, BLOCK_SIZE, keystream, 0);
                        
                        // XOR with encrypted data
                        int blockSize = Math.Min(BLOCK_SIZE, originalLength - i);
                        for (int j = 0; j < blockSize; j++)
                        {
                            result[i + j] = (byte)(data[offset + i + j] ^ keystream[j]);
                        }
                        
                        // Increment counter
                        IncrementCounter(counter);
                    }
                }
            }
            
            return result;
        }
        
        private static byte[] GenerateKey(string key)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
                return sha256.ComputeHash(keyBytes);
            }
        }
        
        private static byte[] GenerateIV(string key)
        {
            // Generate a deterministic IV from the key for simplicity
            // In production, you would use a random IV for each encryption
            using (var md5 = MD5.Create())
            {
                byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key + "IV_SALT");
                return md5.ComputeHash(keyBytes);
            }
        }
        
        private static void IncrementCounter(byte[] counter)
        {
            // Increment counter as a big-endian integer
            for (int i = counter.Length - 1; i >= 0; i--)
            {
                if (++counter[i] != 0)
                    break;
            }
        }
    }
}