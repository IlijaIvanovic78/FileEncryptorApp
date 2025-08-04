using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ZastitaInformacija_18658.Utils;

namespace ZastitaInformacija_18658.Network
{
    public class FileTransferServer
    {
        private TcpListener tcpListener;
        private bool isListening;
        
        public event EventHandler<string> StatusChanged;
        public event EventHandler<FileReceivedEventArgs> FileReceived;

        public async Task StartServerAsync(int port)
        {
            try
            {
                //pokrecemo tcp na datom portu za bilo koju ip adresu
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                isListening = true;
                
                OnStatusChanged($"Server started on port {port}");

                while (isListening)
                {
                    //ceka nove klijente
                    var tcpClient = await AcceptTcpClientAsync();
                    if (tcpClient != null)
                    {
                        //svakog novog klijenta startuje u posebnan task
                        _ = Task.Run(() => HandleClient(tcpClient));
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged($"Server error: {ex.Message}");
            }
        }

        public void StopServer()
        {
            //gasi tcpListener i postavlja isListening na false
            isListening = false;
            tcpListener?.Stop();
            OnStatusChanged("Server stopped");
        }

        private async Task<TcpClient> AcceptTcpClientAsync()
        {
            try
            {
                //ceka klijenta da se poveze na tcplisener instancu
                return await tcpListener.AcceptTcpClientAsync();
            }
            catch (ObjectDisposedException)
            {
                return null;
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (client)
                using (var stream = client.GetStream())
                using (var reader = new BinaryReader(stream))
                {
                    OnStatusChanged("Client connected, receiving file...");
                    
                    string fileName = reader.ReadString();//cita ime fajla
                    long fileSize = reader.ReadInt64();//velicinu
                    int hashLength = reader.ReadInt32();//hash duzinu
                    byte[] receivedHash = reader.ReadBytes(hashLength);//hash

                    // cita enkriptovane podatke
                    byte[] encryptedData = reader.ReadBytes((int)fileSize);
                    
                    OnStatusChanged($"Received file: {fileName} ({fileSize} bytes)");
                    
                    // Proverava hash da li je validan
                    bool hashValid = HashUtils.VerifyHash(encryptedData, receivedHash);
                    
                    OnFileReceived(new FileReceivedEventArgs
                    {
                        FileName = fileName,
                        EncryptedData = encryptedData,
                        Hash = receivedHash,
                        IsHashValid = hashValid
                    });
                    
                    OnStatusChanged($"File transfer completed. SHA-256 Hash valid: {hashValid}");
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged($"Error handling client: {ex.Message}");
            }
        }

        protected virtual void OnStatusChanged(string status)
        {
            //event kada se status promeni
            StatusChanged?.Invoke(this, status);
        }

        protected virtual void OnFileReceived(FileReceivedEventArgs args)
        {
            //event kada je fajl primljen
            FileReceived?.Invoke(this, args);
        }
    }

    public class FileReceivedEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public byte[] EncryptedData { get; set; }
        public byte[] Hash { get; set; }
        public bool IsHashValid { get; set; }
    }
}