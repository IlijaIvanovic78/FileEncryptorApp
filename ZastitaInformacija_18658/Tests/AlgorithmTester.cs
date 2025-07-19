using System;
using System.IO;
using System.Text;
using ZastitaInformacija_18658.Algorithms;
using ZastitaInformacija_18658.Services;
using ZastitaInformacija_18658.Enums;
using ZastitaInformacija_18658.Utils;

namespace ZastitaInformacija_18658.Tests
{
    public static class AlgorithmTester
    {
        public static void TestAllAlgorithms()
        {
            Console.WriteLine("=== Test algoritama za enkripciju ===");
            
            // Test data
            string testMessage = "Ovo je test poruka za enkriptovanje! 123 ????Šš";
            byte[] testData = Encoding.UTF8.GetBytes(testMessage);
            string key = "1234567890abcdef";
            
            Console.WriteLine($"Originalna poruka: {testMessage}");
            Console.WriteLine($"Klju?: {key}");
            Console.WriteLine($"Veli?ina originalnih podataka: {testData.Length} bajtova");
            Console.WriteLine();
            
            // Test each algorithm
            TestAlgorithm(EncryptionAlgorithm.TEA, testData, key);
            TestAlgorithm(EncryptionAlgorithm.LEA, testData, key);
            TestAlgorithm(EncryptionAlgorithm.CRT, testData, key);
            
            // Test hash
            TestHashFunction(testData);
        }
        
        private static void TestAlgorithm(EncryptionAlgorithm algorithm, byte[] data, string key)
        {
            try
            {
                Console.WriteLine($"=== Test {EncryptionManager.GetAlgorithmDisplayName(algorithm)} ===");
                
                // Encrypt
                byte[] encrypted = EncryptionManager.Encrypt(data, algorithm, key);
                Console.WriteLine($"Enkriptovana veli?ina: {encrypted.Length} bajtova");
                
                // Decrypt
                byte[] decrypted = EncryptionManager.Decrypt(encrypted, algorithm, key);
                Console.WriteLine($"Dekriptovana veli?ina: {decrypted.Length} bajtova");
                
                // Verify
                string decryptedMessage = Encoding.UTF8.GetString(decrypted);
                Console.WriteLine($"Dekriptovana poruka: {decryptedMessage}");
                
                bool success = data.Length == decrypted.Length;
                if (success)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] != decrypted[i])
                        {
                            success = false;
                            break;
                        }
                    }
                }
                
                Console.WriteLine($"Test rezultat: {(success ? "USPEŠAN" : "NEUSPEŠAN")}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška tokom testiranja {algorithm}: {ex.Message}");
                Console.WriteLine();
            }
        }
        
        private static void TestHashFunction(byte[] data)
        {
            Console.WriteLine("=== Test SHA1 Hash funkcije ===");
            
            byte[] hash1 = HashUtils.ComputeSHA1Hash(data);
            byte[] hash2 = HashUtils.ComputeSHA1Hash(data);
            
            Console.WriteLine($"Hash 1: {HashUtils.HashToString(hash1)}");
            Console.WriteLine($"Hash 2: {HashUtils.HashToString(hash2)}");
            Console.WriteLine($"Hash konzistentnost: {(HashUtils.HashToString(hash1) == HashUtils.HashToString(hash2) ? "DA" : "NE")}");
            
            // Test verification
            bool verificationResult = HashUtils.VerifyHash(data, hash1);
            Console.WriteLine($"Hash verifikacija: {(verificationResult ? "USPEŠNA" : "NEUSPEŠNA")}");
            Console.WriteLine();
        }
    }
}