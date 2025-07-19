using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using ZastitaInformacija_18658.Utils;

namespace ZastitaInformacija_18658.Network
{
    public class FileTransferClient
    {
        public event EventHandler<string> StatusChanged;

        public async Task SendFileAsync(string serverAddress, int port, string fileName, byte[] encryptedData)
        {
            try
            {
                OnStatusChanged($"Connecting to {serverAddress}:{port}...");
                
                using (var client = new TcpClient())
                {
                    await client.ConnectAsync(serverAddress, port);
                    OnStatusChanged("Connected to server");
                    
                    using (var stream = client.GetStream())
                    using (var writer = new BinaryWriter(stream))
                    {
                        // Compute hash of encrypted data
                        byte[] hash = HashUtils.ComputeSHA1Hash(encryptedData);
                        
                        // Send file information and data
                        writer.Write(fileName);
                        writer.Write((long)encryptedData.Length);
                        writer.Write(hash.Length);
                        writer.Write(hash);
                        writer.Write(encryptedData);
                        
                        OnStatusChanged($"File sent: {fileName} ({encryptedData.Length} bytes)");
                        OnStatusChanged($"Hash: {HashUtils.HashToString(hash)}");
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged($"Send error: {ex.Message}");
                throw;
            }
        }

        protected virtual void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(this, status);
        }
    }
}