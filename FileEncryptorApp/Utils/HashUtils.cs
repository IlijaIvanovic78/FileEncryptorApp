﻿using System;

namespace ZastitaInformacija_18658.Utils
{
    public static class HashUtils
    {
        // SHA-256 konstante (prvi 32 bita frakcionih delova kubnih korena prva 64 proste broja)
        private static readonly uint[] K = {
            0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
            0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
            0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
            0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
            0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
            0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
            0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
            0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
        };

        // Pocetne hash vrednosti (prvi 32 bita frakcionih delova kvadratnih korena prva 8 prostih brojeva)
        private static readonly uint[] H = {
            0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a,
            0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19
        };

        public static byte[] ComputeSHA256Hash(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            // Kreiranje kopije početnih hash vrednosti
            uint[] hash = new uint[8];
            Array.Copy(H, hash, 8);

            // Padding poruke
            byte[] paddedMessage = PadMessage(data);

            // Obradi poruku u blokovima od 512 bita (64 bajta)
            for (int i = 0; i < paddedMessage.Length; i += 64)
            {
                ProcessBlock(paddedMessage, i, hash);
            }

            // Konvertuj hash u byte array
            byte[] result = new byte[32];
            for (int i = 0; i < 8; i++)
            {
                result[i * 4] = (byte)(hash[i] >> 24);
                result[i * 4 + 1] = (byte)(hash[i] >> 16);
                result[i * 4 + 2] = (byte)(hash[i] >> 8);
                result[i * 4 + 3] = (byte)hash[i];
            }

            return result;
        }

        private static byte[] PadMessage(byte[] data)
        {
            long originalLength = data.Length;
            long bitLength = originalLength * 8;

            // Dodaj '1' bit na kraj
            int paddingLength = 1;
            
            // Dodaj nule tako da duzina bude congruent sa 448 mod 512
            while ((originalLength + paddingLength) % 64 != 56)
            {
                paddingLength++;
            }

            byte[] paddedMessage = new byte[originalLength + paddingLength + 8];
            Array.Copy(data, 0, paddedMessage, 0, originalLength);
            
            paddedMessage[originalLength] = 0x80; // Dodaj '1' bit

            for (int i = 0; i < 8; i++)
            {
                paddedMessage[paddedMessage.Length - 1 - i] = (byte)(bitLength >> (i * 8));
            }

            return paddedMessage;
        }

        private static void ProcessBlock(byte[] message, int offset, uint[] hash)
        {
            uint[] w = new uint[64];

            // Kopiraj blok u prvih 16 reci schedule-a
            for (int i = 0; i < 16; i++)
            {
                w[i] = ((uint)message[offset + i * 4] << 24) |
                       ((uint)message[offset + i * 4 + 1] << 16) |
                       ((uint)message[offset + i * 4 + 2] << 8) |
                       ((uint)message[offset + i * 4 + 3]);
            }

            // Prosiri prvih 16 reci u 64 reči
            for (int i = 16; i < 64; i++)
            {
                uint s0 = RightRotate(w[i - 15], 7) ^ RightRotate(w[i - 15], 18) ^ (w[i - 15] >> 3);
                uint s1 = RightRotate(w[i - 2], 17) ^ RightRotate(w[i - 2], 19) ^ (w[i - 2] >> 10);
                w[i] = w[i - 16] + s0 + w[i - 7] + s1;
            }

            // Inicijalizuj radne promenljive
            uint a = hash[0], b = hash[1], c = hash[2], d = hash[3];
            uint e = hash[4], f = hash[5], g = hash[6], h = hash[7];

            // Glavni loop
            for (int i = 0; i < 64; i++)
            {
                uint S1 = RightRotate(e, 6) ^ RightRotate(e, 11) ^ RightRotate(e, 25);
                uint ch = (e & f) ^ ((~e) & g);
                uint temp1 = h + S1 + ch + K[i] + w[i];
                uint S0 = RightRotate(a, 2) ^ RightRotate(a, 13) ^ RightRotate(a, 22);
                uint maj = (a & b) ^ (a & c) ^ (b & c);
                uint temp2 = S0 + maj;

                h = g;
                g = f;
                f = e;
                e = d + temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 + temp2;
            }

            // Dodaj kompresovane chunk na trenutni hash
            hash[0] += a;
            hash[1] += b;
            hash[2] += c;
            hash[3] += d;
            hash[4] += e;
            hash[5] += f;
            hash[6] += g;
            hash[7] += h;
        }

        private static uint RightRotate(uint value, int bits)
        {
            return (value >> bits) | (value << (32 - bits));
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