using System;
using System.Security.Cryptography;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class CTR
    {
        private const int BLOCK_SIZE = 16; // 128 bits (LEA block size)
        
        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];
            
            byte[] iv = GenerateIV(key, data);

            // Pravimo niz bajtova za rezultat koji sadrži originalnu duzinu, IV i enkriptovane podatke
            byte[] result = new byte[4 + BLOCK_SIZE + data.Length];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);
            iv.CopyTo(result, 4);

            // counter pocinje sa IV
            byte[] counter = new byte[BLOCK_SIZE];
            iv.CopyTo(counter, 0);
            
            //petlja kroz podatke u blokovima od 16 bajtova
            int offset = 4 + BLOCK_SIZE;
            for (int i = 0; i < data.Length; i += BLOCK_SIZE)
            {
                // Enkriptujemo counter koristeći LEA
                byte[] keystream = LEA.EncryptSingleBlock(counter, key);
                
                // XOR sa podacima
                int blockSize = Math.Min(BLOCK_SIZE, data.Length - i);
                for (int j = 0; j < blockSize; j++)
                {
                    result[offset + i + j] = (byte)(data[i + j] ^ keystream[j]);
                }
                
                IncrementCounter(counter);
            }
            
            return result;
        }
        
        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 4 + BLOCK_SIZE) return new byte[0];
            
            // Izvucemo originalnu duzinu i IV
            int originalLength = BitConverter.ToInt32(data, 0);
            byte[] iv = new byte[BLOCK_SIZE];
            Array.Copy(data, 4, iv, 0, BLOCK_SIZE);
            
            byte[] result = new byte[originalLength];
            
            byte[] counter = new byte[BLOCK_SIZE];
            iv.CopyTo(counter, 0);
            
            int offset = 4 + BLOCK_SIZE;
            for (int i = 0; i < originalLength; i += BLOCK_SIZE)
            {
                // Enkriptujemo counter koristeći LEA 
                byte[] keystream = LEA.EncryptSingleBlock(counter, key);
                
                // XOR sa enkriptovanim podacima
                int blockSize = Math.Min(BLOCK_SIZE, originalLength - i);
                for (int j = 0; j < blockSize; j++)
                {
                    result[i + j] = (byte)(data[offset + i + j] ^ keystream[j]);
                }
                
                IncrementCounter(counter);
            }
            
            return result;
        }
        
        private static byte[] GenerateIV(string key, byte[] data)
        {
            // Kombinujemo ključ sa hash-om podataka 
            using (var sha256 = SHA256.Create())
            {
                // Hash podataka
                byte[] dataHash = sha256.ComputeHash(data);
                
                // Kombinujemo ključ + hash podataka + salt
                string input = key + Convert.ToBase64String(dataHash) + "IV_SALT_V2";
                byte[] combinedBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] fullHash = sha256.ComputeHash(combinedBytes);
                
                // Uzimamo prvih 16 bajtova za IV
                byte[] iv = new byte[16];
                Array.Copy(fullHash, iv, 16);
                return iv;
            }
        }
        
        private static void IncrementCounter(byte[] counter)
        {
            // ide od poslednjeg bajta
            for (int i = counter.Length - 1; i >= 0; i--)
            {
                //ako se prelije odnosno postane 0 jer je bio 255 bajt onda se nastavlja inkrement u suprotnom se prekida petlja
                if (++counter[i] != 0)
                    break;
            }
        }
    }
}