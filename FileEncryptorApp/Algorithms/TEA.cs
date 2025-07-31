using System;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class TEA
    {
        private const uint DELTA = 0x9e3779b9;
        private const int ROUNDS = 32;

        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];
            
            // Convert key to 32-bit integers
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            if (keyBytes.Length < 16)
            {
                Array.Resize(ref keyBytes, 16);
            }

            uint[] teaKey = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                teaKey[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }

            // Pad data to multiple of 8 bytes
            int paddedLength = ((data.Length + 7) / 8) * 8;
            byte[] paddedData = new byte[paddedLength];
            Array.Copy(data, paddedData, data.Length);
            
            // Store original length at the beginning
            byte[] result = new byte[paddedLength + 4];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);

            // Encrypt in 8-byte blocks
            for (int i = 0; i < paddedLength; i += 8)
            {
                uint v0 = BitConverter.ToUInt32(paddedData, i);
                uint v1 = BitConverter.ToUInt32(paddedData, i + 4);
                
                uint sum = 0;

                for (int j = 0; j < ROUNDS; j++)
                {
                    sum = unchecked(sum + DELTA);
                    v0 = unchecked(v0 + (((v1 << 4) + teaKey[0]) ^ (v1 + sum) ^ ((v1 >> 5) + teaKey[1])));
                    v1 = unchecked(v1 + (((v0 << 4) + teaKey[2]) ^ (v0 + sum) ^ ((v0 >> 5) + teaKey[3])));
                }

                BitConverter.GetBytes(v0).CopyTo(result, i + 4);
                BitConverter.GetBytes(v1).CopyTo(result, i + 8);
            }

            return result;
        }

        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 12) return new byte[0];
            
            // Convert key to 32-bit integers
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            if (keyBytes.Length < 16)
            {
                Array.Resize(ref keyBytes, 16);
            }

            uint[] teaKey = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                teaKey[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }

            // Get original length
            int originalLength = BitConverter.ToInt32(data, 0);
            int encryptedLength = data.Length - 4;
            
            byte[] decryptedData = new byte[encryptedLength];

            // Decrypt in 8-byte blocks
            for (int i = 0; i < encryptedLength; i += 8)
            {
                uint v0 = BitConverter.ToUInt32(data, i + 4);
                uint v1 = BitConverter.ToUInt32(data, i + 8);
                
                uint sum = unchecked(DELTA * ROUNDS);

                for (int j = 0; j < ROUNDS; j++)
                {
                    v1 = unchecked(v1 - (((v0 << 4) + teaKey[2]) ^ (v0 + sum) ^ ((v0 >> 5) + teaKey[3])));
                    v0 = unchecked(v0 - (((v1 << 4) + teaKey[0]) ^ (v1 + sum) ^ ((v1 >> 5) + teaKey[1])));
                    sum = unchecked(sum - DELTA);
                }

                BitConverter.GetBytes(v0).CopyTo(decryptedData, i);
                BitConverter.GetBytes(v1).CopyTo(decryptedData, i + 4);
            }

            // Return only the original length
            if (originalLength > decryptedData.Length)
                originalLength = decryptedData.Length;
                
            byte[] result = new byte[originalLength];
            Array.Copy(decryptedData, result, originalLength);
            return result;
        }
    }
}