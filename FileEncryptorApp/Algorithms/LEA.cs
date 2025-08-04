using System;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class LEA
    {
        private const int ROUNDS = 24; // Broj rundi za LEA enkripciju

        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];

        
            uint[] roundKeys = GenerateRoundKeys(key);

            //podaci se dopunjuju do 16 bajtova(128 bita)
            int paddedLength = ((data.Length + 15) / 16) * 16;
            byte[] paddedData = new byte[paddedLength];
            Array.Copy(data, paddedData, data.Length);

            // Kreiramo niz za rezultat koji je 4 bajta duzi jer sadrži originalnu duzinu
            byte[] result = new byte[paddedLength + 4];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);

            // Enkriptujemo u blokovima od 16 bajtova
            for (int i = 0; i < paddedLength; i += 16)
            {
                uint[] block = new uint[4]; 
                for (int j = 0; j < 4; j++)
                {
                    block[j] = BitConverter.ToUInt32(paddedData, i + j * 4); //konvertujemo po 4 bajta u uint
                }

                EncryptBlock(block, roundKeys);// Enkriptujemo blok

                for (int j = 0; j < 4; j++)
                {
                    BitConverter.GetBytes(block[j]).CopyTo(result, i + 4 + j * 4);//Dodajemo enkriptovane blokove u result
                }
            }

            return result;
        }

        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 20) return new byte[0];

            
            uint[] roundKeys = GenerateRoundKeys(key);

            // Citamo prva 4  bajta sto je originalna duzina
            int originalLength = BitConverter.ToInt32(data, 0);
            int encryptedLength = data.Length - 4;

            byte[] decryptedData = new byte[encryptedLength];

            
            for (int i = 0; i < encryptedLength; i += 16)
            {
                // Dekriptujemo u blokovima od 16 bajtova
                uint[] block = new uint[4];
                for (int j = 0; j < 4; j++)
                {
                    block[j] = BitConverter.ToUInt32(data, i + 4 + j * 4); // konvertujemo po 4 bajta u uint
                }

                DecryptBlock(block, roundKeys); //dekriptujemo blok

                for (int j = 0; j < 4; j++)
                {
                    BitConverter.GetBytes(block[j]).CopyTo(decryptedData, i + j * 4); // dodajemo dekriptovane blokove u decryptedData
                }
            }
                
            if (originalLength > decryptedData.Length)
                originalLength = decryptedData.Length;

            byte[] result = new byte[originalLength]; //izbacimo visak nula koje su dodate kao padding
            Array.Copy(decryptedData, result, originalLength);
            return result;
        }

        private static uint[] GenerateRoundKeys(string key)
        {
            //"zaokruzimo" kljuc hesiranjem na 32 bajta(256 bita)
            byte[] keyBytes;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(key);
                keyBytes = sha256.ComputeHash(inputBytes);
            }

            // Generisemo masytr key od 16 bajtova(128 bita)
            uint[] masterKey = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                masterKey[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }
            //24 runde po 6 reci nam je potrebno znaci 144 uint vrednosti za roundKeys
            uint[] roundKeys = new uint[ROUNDS * 6];
            //delta da se razbije regularnost kljuca LEA
            uint[] delta = { 0xc3efe9db, 0x44626b02, 0x79e27c8a, 0x78df30ec };

            for (int i = 0; i < ROUNDS; i++)
            {
                //Prva runda koristi nemodifikovani master
                if (i > 0)
                {
                    //Dodajemo delta kljucu i rotiramo ga za odg. indeks
                    masterKey[0] = unchecked(RotateLeft(masterKey[0] + delta[i % 4], i));
                    masterKey[1] = unchecked(RotateLeft(masterKey[1] + delta[(i + 1) % 4], i + 1));
                    masterKey[2] = unchecked(RotateLeft(masterKey[2] + delta[(i + 2) % 4], i + 2));
                    masterKey[3] = unchecked(RotateLeft(masterKey[3] + delta[(i + 3) % 4], i + 3));
                }

                //svaku rundu generisemo 6 vrednosti i smestamo u roudnKeys
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
                // Izracunavamo nove vrednosti bloka koristeci formulu 
                uint temp = unchecked(RotateLeft((block[0] ^ roundKeys[round * 6 + 0]) + (block[1] ^ roundKeys[round * 6 + 1]), 9));
                block[0] = unchecked(RotateLeft((block[1] ^ roundKeys[round * 6 + 2]) + (block[2] ^ roundKeys[round * 6 + 3]), 5) ^ temp);
                block[1] = unchecked(RotateLeft((block[2] ^ roundKeys[round * 6 + 4]) + (block[3] ^ roundKeys[round * 6 + 5]), 3) ^ temp);
                block[2] = temp;

                // Rotiramo stanje bloka
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
                // Vrsimo obrnutu rotaciju
                uint t = block[0];
                block[0] = block[1];
                block[1] = block[2];
                block[2] = block[3];
                block[3] = t;

                uint temp = block[2];

                // Inverzujemo formulu za dekripciju
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

        public static byte[] EncryptSingleBlock(byte[] block, string key)
        {
            if (block == null || block.Length != 16)
                throw new ArgumentException("Block must be exactly 16 bytes");
        
            uint[] roundKeys = GenerateRoundKeys(key);
    
            uint[] blockData = new uint[4];
            for (int j = 0; j < 4; j++)
            {
                blockData[j] = BitConverter.ToUInt32(block, j * 4);
            }
    
            EncryptBlock(blockData, roundKeys);
    
            byte[] result = new byte[16];
            for (int j = 0; j < 4; j++)
            {
                BitConverter.GetBytes(blockData[j]).CopyTo(result, j * 4);
            }
    
            return result;
        }
    }
}