using System;
using System.Security.Cryptography;

namespace ZastitaInformacija_18658.Utils
{
    public static class HashUtils
    {
        public static byte[] ComputeSHA1Hash(byte[] data)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(data);
            }
        }

        public static bool VerifyHash(byte[] data, byte[] hash)
        {
            byte[] computedHash = ComputeSHA1Hash(data);
            
            if (computedHash.Length != hash.Length)
                return false;
                
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != hash[i])
                    return false;
            }
            
            return true;
        }

        public static string HashToString(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}