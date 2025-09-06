using System;
using System.IO;

namespace ZastitaInformacija_18658.Configuration
{
    public static class AppConfig
    {
        public const string DEFAULT_KEY = "1234567890abcdef";
        public const int DEFAULT_SERVER_PORT = 8080;
        public const string DEFAULT_SERVER_ADDRESS = "127.0.0.1";
        
        public const string ENCRYPTED_FILE_PREFIX = "encrypted_";
        public const string ENCRYPTED_FILE_EXTENSION = ".enc";
        public const string DECRYPTED_FILE_PREFIX = "decrypted_";
        public const string RECEIVED_FILE_PREFIX = "received_";
        
        public const string TARGET_FOLDER_NAME = "Target";
        public const string OUTPUT_FOLDER_NAME = "X";
        
        public const int FILE_TRANSFER_TIMEOUT = 30000; // 30 seconds
        public const int MAX_FILE_SIZE = 100 * 1024 * 1024; // 100 MB
        
        public static string GetDefaultTargetFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), TARGET_FOLDER_NAME);
        }
        
        public static string GetDefaultOutputFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), OUTPUT_FOLDER_NAME);
        }
        
        public static string CreateEncryptedFileName(string originalFileName)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
            string originalExtension = Path.GetExtension(originalFileName);
            
            // Kombinujemo originalno ime + originalnu ekstenziju + encrypted ekstenziju
            return $"{ENCRYPTED_FILE_PREFIX}{nameWithoutExtension}{originalExtension}{ENCRYPTED_FILE_EXTENSION}";
        }
        
        public static string CreateDecryptedFileName(string encryptedFileName)
        {
            // Uklanjamo .enc ekstenziju na kraju
            string nameWithoutEncExtension = encryptedFileName;
            if (nameWithoutEncExtension.EndsWith(ENCRYPTED_FILE_EXTENSION))
            {
                nameWithoutEncExtension = nameWithoutEncExtension.Substring(0, nameWithoutEncExtension.Length - ENCRYPTED_FILE_EXTENSION.Length);
            }
            
            // Uklanjamo encrypted_ prefix
            if (nameWithoutEncExtension.StartsWith(ENCRYPTED_FILE_PREFIX))
            {
                nameWithoutEncExtension = nameWithoutEncExtension.Substring(ENCRYPTED_FILE_PREFIX.Length);
            }
            
            // Dodajemo decrypted_ prefix pre originalnog imena sa ekstenzijom
            return $"{DECRYPTED_FILE_PREFIX}{nameWithoutEncExtension}";
        }
        
        public static string CreateReceivedFileName(string originalFileName)
        {
            return $"{RECEIVED_FILE_PREFIX}{originalFileName}";
        }
        
        public static string ExtractOriginalFileName(string encryptedFileName)
        {
            string fileName = encryptedFileName;
            
            if (fileName.EndsWith(ENCRYPTED_FILE_EXTENSION))
            {
                fileName = fileName.Substring(0, fileName.Length - ENCRYPTED_FILE_EXTENSION.Length);
            }

            if (fileName.StartsWith(ENCRYPTED_FILE_PREFIX))
            {
                fileName = fileName.Substring(ENCRYPTED_FILE_PREFIX.Length);
            }
            
            return fileName;
        }
        
        public static bool IsFileSizeValid(long fileSize)
        {
            return fileSize > 0 && fileSize <= MAX_FILE_SIZE;
        }
        
        public static bool IsPortValid(int port)
        {
            return port >= 1024 && port <= 65535;
        }
        
        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}