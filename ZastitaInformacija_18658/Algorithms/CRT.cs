using System;
using System.Numerics;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class CRT
    {
        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];
            
            // Simple CRT implementation with predefined moduli
            var moduli = GetModuli();
            var keyValue = GetKeyFromString(key);
            
            byte[] result = new byte[data.Length + 4];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);
            
            for (int i = 0; i < data.Length; i++)
            {
                uint value = data[i];
                uint encrypted = 0;
                
                for (int j = 0; j < moduli.Length; j++)
                {
                    uint remainder = (value + keyValue[j % keyValue.Length]) % moduli[j];
                    encrypted = (encrypted + remainder * GetInverseProduct(moduli, j)) % GetProduct(moduli);
                }
                
                result[i + 4] = (byte)(encrypted % 256);
            }
            
            return result;
        }

        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 4) return new byte[0];
            
            var moduli = GetModuli();
            var keyValue = GetKeyFromString(key);
            
            int originalLength = BitConverter.ToInt32(data, 0);
            byte[] result = new byte[originalLength];
            
            for (int i = 0; i < originalLength; i++)
            {
                uint encrypted = data[i + 4];
                uint decrypted = 0;
                
                for (int j = 0; j < moduli.Length; j++)
                {
                    uint remainder = encrypted % moduli[j];
                    uint original = (remainder + moduli[j] - (keyValue[j % keyValue.Length] % moduli[j])) % moduli[j];
                    decrypted = (decrypted + original * GetInverseProduct(moduli, j)) % GetProduct(moduli);
                }
                
                result[i] = (byte)(decrypted % 256);
            }
            
            return result;
        }

        private static uint[] GetModuli()
        {
            return new uint[] { 3, 5, 7, 11, 13 };
        }

        private static uint[] GetKeyFromString(string key)
        {
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            uint[] result = new uint[Math.Max(keyBytes.Length, 4)];
            
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (uint)(keyBytes[i % keyBytes.Length] + 1);
            }
            
            return result;
        }

        private static uint GetProduct(uint[] moduli)
        {
            uint product = 1;
            foreach (uint mod in moduli)
            {
                product *= mod;
            }
            return product;
        }

        private static uint GetInverseProduct(uint[] moduli, int index)
        {
            uint product = 1;
            for (int i = 0; i < moduli.Length; i++)
            {
                if (i != index)
                {
                    product *= moduli[i];
                }
            }
            
            // Find modular inverse
            return ModInverse(product, moduli[index]);
        }

        private static uint ModInverse(uint a, uint m)
        {
            if (m == 1) return 0;
            
            int m0 = (int)m;
            int x1 = 1, y1 = 0;
            int x0 = 0, y0 = 1;
            
            while (a > 1)
            {
                int q = (int)(a / m);
                int t = (int)m;
                
                m = a % m;
                a = (uint)t;
                t = x0;
                
                x0 = x1 - q * x0;
                x1 = t;
                t = y0;
                
                y0 = y1 - q * y0;
                y1 = t;
            }
            
            if (x1 < 0) x1 += m0;
            
            return (uint)x1;
        }
    }
}