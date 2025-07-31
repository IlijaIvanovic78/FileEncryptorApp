using System;
using System.IO;

namespace ZastitaInformacija_18658.Configuration
{
    public static class AppConfig
    {
        // Default values
        public const string DEFAULT_KEY = "1234567890abcdef";
        public const int DEFAULT_SERVER_PORT = 8080;
        public const string DEFAULT_SERVER_ADDRESS = "127.0.0.1";
        
        // File extensions
        public const string ENCRYPTED_FILE_PREFIX = "encrypted_";
        public const string ENCRYPTED_FILE_EXTENSION = ".txt";
        public const string DECRYPTED_FILE_PREFIX = "decrypted_";
        public const string RECEIVED_FILE_PREFIX = "received_";
        
        // Default folder names
        public const string TARGET_FOLDER_NAME = "Target";
        public const string OUTPUT_FOLDER_NAME = "X";
        
        // Network settings
        public const int FILE_TRANSFER_TIMEOUT = 30000; // 30 seconds
        public const int MAX_FILE_SIZE = 100 * 1024 * 1024; // 100 MB
        
        // Get default folders
        public static string GetDefaultTargetFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), TARGET_FOLDER_NAME);
        }
        
        public static string GetDefaultOutputFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), OUTPUT_FOLDER_NAME);
        }
        
        // Create encrypted filename
        public static string CreateEncryptedFileName(string originalFileName)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
            return $"{ENCRYPTED_FILE_PREFIX}{nameWithoutExtension}{ENCRYPTED_FILE_EXTENSION}";
        }
        
        // Create decrypted filename
        public static string CreateDecryptedFileName(string encryptedFileName)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(encryptedFileName);
            if (nameWithoutExtension.StartsWith(ENCRYPTED_FILE_PREFIX))
            {
                nameWithoutExtension = nameWithoutExtension.Substring(ENCRYPTED_FILE_PREFIX.Length);
            }
            return $"{DECRYPTED_FILE_PREFIX}{nameWithoutExtension}";
        }
        
        // Create received filename
        public static string CreateReceivedFileName(string originalFileName)
        {
            return $"{RECEIVED_FILE_PREFIX}{originalFileName}";
        }
        
        // Validate file size
        public static bool IsFileSizeValid(long fileSize)
        {
            return fileSize > 0 && fileSize <= MAX_FILE_SIZE;
        }
        
        // Validate port
        public static bool IsPortValid(int port)
        {
            return port >= 1024 && port <= 65535;
        }
        
        // Get timestamp string
        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}