using System;
using System.Security.Cryptography;

namespace ZastitaInformacija_18658.Utils
{
    public static class HashUtils
    {
        public static byte[] ComputeSHA256Hash(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }

        public static byte[] ComputeHash(byte[] data)
        {
            return ComputeSHA256Hash(data);
        }

        public static bool VerifyHash(byte[] data, byte[] hash)
        {
            byte[] computedHash = ComputeSHA256Hash(data);
            
            //poredi prosledjeni hash sa hashom koji izracuna za prosledjene podatke

            //poredjenje duina
            if (computedHash.Length != hash.Length)
                return false;

            //poredjenje bajtova
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