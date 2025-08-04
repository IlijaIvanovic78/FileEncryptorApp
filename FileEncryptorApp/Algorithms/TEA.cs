using System;

namespace ZastitaInformacija_18658.Algorithms
{
    public static class TEA
    {
        private const uint DELTA = 0x9e3779b9; // Delta konstanta za TEA
        private const int ROUNDS = 32; // Broj rundi za TEA enkripciju

        public static byte[] Encrypt(byte[] data, string key)
        {
            if (data == null || data.Length == 0) return new byte[0];

            uint[] teaKey = GenerateTeaKey(key);

            //podaci se dopunjuju do 8 bajtova(64 bita)
            int paddedLength = ((data.Length + 7) / 8) * 8;
            byte[] paddedData = new byte[paddedLength];
            Array.Copy(data, paddedData, data.Length);

            // Kreiramo niz za rezultat koji je 4 bajta duzi jer sadrži originalnu duzinu
            byte[] result = new byte[paddedLength + 4];
            BitConverter.GetBytes(data.Length).CopyTo(result, 0);

            //Enkriptujemo u blokovima od 8 bajtova
            for (int i = 0; i < paddedLength; i += 8)
            {
                //svaki blok delimo na dva dela od 4 bajta
                uint v0 = BitConverter.ToUInt32(paddedData, i);
                uint v1 = BitConverter.ToUInt32(paddedData, i + 4);

                uint sum = 0;

                for (int j = 0; j < ROUNDS; j++)
                {
                    // Izracunavamo nove vrednosti v1 i v0 koristeci formulu 
                    sum = unchecked(sum + DELTA);
                    v0 = unchecked(v0 + (((v1 << 4) + teaKey[0]) ^ (v1 + sum) ^ ((v1 >> 5) + teaKey[1])));
                    v1 = unchecked(v1 + (((v0 << 4) + teaKey[2]) ^ (v0 + sum) ^ ((v0 >> 5) + teaKey[3])));
                }

                //offset za prva 4 bajta zbog originalne duzine
                BitConverter.GetBytes(v0).CopyTo(result, i + 4);
                BitConverter.GetBytes(v1).CopyTo(result, i + 8);
            }

            return result;
        }

        public static byte[] Decrypt(byte[] data, string key)
        {
            if (data == null || data.Length < 12) return new byte[0];

            uint[] teaKey = GenerateTeaKey(key);

            // Citamo prva 4  bajta sto je originalna duzina
            int originalLength = BitConverter.ToInt32(data, 0);
            int encryptedLength = data.Length - 4;

            byte[] decryptedData = new byte[encryptedLength];

            // Dekriptujemo u blokovima od 8 bajtova
            for (int i = 0; i < encryptedLength; i += 8)
            {
                // Offsetovani su za 4 bajta jer prvi 4 bajta sadrže originalnu dužinu
                uint v0 = BitConverter.ToUInt32(data, i + 4);
                uint v1 = BitConverter.ToUInt32(data, i + 8);

                // Sum se stavlja na maksimalnu vrednost
                uint sum = unchecked(DELTA * ROUNDS);

                // Inverzujemo formulu za dekripciju
                for (int j = 0; j < ROUNDS; j++)
                {
                    v1 = unchecked(v1 - (((v0 << 4) + teaKey[2]) ^ (v0 + sum) ^ ((v0 >> 5) + teaKey[3])));
                    v0 = unchecked(v0 - (((v1 << 4) + teaKey[0]) ^ (v1 + sum) ^ ((v1 >> 5) + teaKey[1])));
                    sum = unchecked(sum - DELTA);
                }

                BitConverter.GetBytes(v0).CopyTo(decryptedData, i);
                BitConverter.GetBytes(v1).CopyTo(decryptedData, i + 4);
            }

            if (originalLength > decryptedData.Length)
                originalLength = decryptedData.Length;

            byte[] result = new byte[originalLength]; //izbacimo visak nula koje su dodate kao padding
            Array.Copy(decryptedData, result, originalLength);
            return result;
        }

        private static uint[] GenerateTeaKey(string key)
        {
            //"zaokruzimo" kljuc hesiranjem na 32 bajta(256 bita)
            byte[] keyBytes;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(key);
                keyBytes = sha256.ComputeHash(inputBytes);
            }

            // TEA koristi 128 bita (16 bajtova) kao 4 uint vrednosti
            uint[] teaKey = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                teaKey[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }

            return teaKey;
        }

    }
}