using System;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class LEA
    {
        private const int ROUNDS = 24;

        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];

            // Generate round keys
            uint[] roundKeys = GenerateRoundKeys(key);

            // Pad data to multiple of 16 bytes
            int paddedLength = ((data.Length + 15) / 16) * 16;
            byte[] paddedData = new byte[paddedLength];
            Array.Copy(data, paddedData, data.Length);

            // Store original length at the beginning
            byte[] result = new byte[paddedLength + 4];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);

            // Encrypt in 16-byte blocks
            for (int i = 0; i < paddedLength; i += 16)
            {
                uint[] block = new uint[4];
                for (int j = 0; j < 4; j++)
                {
                    block[j] = BitConverter.ToUInt32(paddedData, i + j * 4);
                }

                EncryptBlock(block, roundKeys);

                for (int j = 0; j < 4; j++)
                {
                    BitConverter.GetBytes(block[j]).CopyTo(result, i + 4 + j * 4);
                }
            }

            return result;
        }

        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 20) return new byte[0];

            // Generate round keys
            uint[] roundKeys = GenerateRoundKeys(key);

            // Get original length
            int originalLength = BitConverter.ToInt32(data, 0);
            int encryptedLength = data.Length - 4;

            byte[] decryptedData = new byte[encryptedLength];

            // Decrypt in 16-byte blocks
            for (int i = 0; i < encryptedLength; i += 16)
            {
                uint[] block = new uint[4];
                for (int j = 0; j < 4; j++)
                {
                    block[j] = BitConverter.ToUInt32(data, i + 4 + j * 4);
                }

                DecryptBlock(block, roundKeys);

                for (int j = 0; j < 4; j++)
                {
                    BitConverter.GetBytes(block[j]).CopyTo(decryptedData, i + j * 4);
                }
            }

            // Return only the original length
            if (originalLength > decryptedData.Length)
                originalLength = decryptedData.Length;

            byte[] result = new byte[originalLength];
            Array.Copy(decryptedData, result, originalLength);
            return result;
        }

        private static uint[] GenerateRoundKeys(string key)
        {
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            if (keyBytes.Length < 16)
            {
                Array.Resize(ref keyBytes, 16);
            }

            uint[] masterKey = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                masterKey[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }

            uint[] roundKeys = new uint[ROUNDS * 6];
            uint[] delta = { 0xc3efe9db, 0x44626b02, 0x79e27c8a, 0x78df30ec };

            // Fixed key schedule - properly update master key for each round
            for (int i = 0; i < ROUNDS; i++)
            {
                // Update master key based on previous round
                if (i > 0)
                {
                    masterKey[0] = unchecked(RotateLeft(masterKey[0] + delta[i % 4], i));
                    masterKey[1] = unchecked(RotateLeft(masterKey[1] + delta[(i + 1) % 4], i + 1));
                    masterKey[2] = unchecked(RotateLeft(masterKey[2] + delta[(i + 2) % 4], i + 2));
                    masterKey[3] = unchecked(RotateLeft(masterKey[3] + delta[(i + 3) % 4], i + 3));
                }

                roundKeys[i * 6 + 0] = masterKey[0];
                roundKeys[i * 6 + 1] = masterKey[1];
                roundKeys[i * 6 + 2] = masterKey[2];
                roundKeys[i * 6 + 3] = masterKey[3];
                roundKeys[i * 6 + 4] = masterKey[0];
                roundKeys[i * 6 + 5] = masterKey[1];
            }

            return roundKeys;
        }

        private static void EncryptBlock(uint[] block, uint[] roundKeys)
        {
            for (int round = 0; round < ROUNDS; round++)
            {
                uint temp = unchecked(RotateLeft((block[0] ^ roundKeys[round * 6 + 0]) + (block[1] ^ roundKeys[round * 6 + 1]), 9));
                block[0] = unchecked(RotateLeft((block[1] ^ roundKeys[round * 6 + 2]) + (block[2] ^ roundKeys[round * 6 + 3]), 5) ^ temp);
                block[1] = unchecked(RotateLeft((block[2] ^ roundKeys[round * 6 + 4]) + (block[3] ^ roundKeys[round * 6 + 5]), 3) ^ temp);
                block[2] = temp;

                // Rotate state
                uint t = block[3];
                block[3] = block[2];
                block[2] = block[1];
                block[1] = block[0];
                block[0] = t;
            }
        }

        private static void DecryptBlock(uint[] block, uint[] roundKeys)
        {
            for (int round = ROUNDS - 1; round >= 0; round--)
            {
                // Reverse rotate state
                uint t = block[0];
                block[0] = block[1];
                block[1] = block[2];
                block[2] = block[3];
                block[3] = t;

                uint temp = block[2];

                // Fixed decryption formulas - properly reverse the encryption operations
                block[2] = unchecked((RotateRight(block[1] ^ temp, 3) - (block[3] ^ roundKeys[round * 6 + 5])) ^ roundKeys[round * 6 + 4]);
                block[1] = unchecked((RotateRight(block[0] ^ temp, 5) - (block[2] ^ roundKeys[round * 6 + 3])) ^ roundKeys[round * 6 + 2]);
                block[0] = unchecked((RotateRight(temp, 9) - (block[1] ^ roundKeys[round * 6 + 1])) ^ roundKeys[round * 6 + 0]);
            }
        }

        private static uint RotateLeft(uint value, int bits)
        {
            bits = bits % 32;
            return (value << bits) | (value >> (32 - bits));
        }

        private static uint RotateRight(uint value, int bits)
        {
            bits = bits % 32;
            return (value >> bits) | (value << (32 - bits));
        }
    }
}