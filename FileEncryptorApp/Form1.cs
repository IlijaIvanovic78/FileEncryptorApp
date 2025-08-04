using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZastitaInformacija_18658.Algorithms;
using ZastitaInformacija_18658.Enums;
using ZastitaInformacija_18658.Services;
using ZastitaInformacija_18658.Network;
using ZastitaInformacija_18658.Utils;
using ZastitaInformacija_18658.Configuration;

namespace ZastitaInformacija_18658
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher fileSystemWatcher;
        private FileTransferServer fileTransferServer;
        private FileTransferClient fileTransferClient;
        private Task serverTask;

        public Form1()
        {
            InitializeComponent();
            InitializeDefaultSettings();
            InitializeNetworkComponents();
        }

        private void InitializeDefaultSettings()
        {
            txtTargetFolder.Text = AppConfig.GetDefaultTargetFolder();
            txtOutputFolder.Text = AppConfig.GetDefaultOutputFolder();
            
            txtEncryptionKey.Text = AppConfig.DEFAULT_KEY;
            
            numericUpDownPort.Value = AppConfig.DEFAULT_SERVER_PORT;
            numericUpDownTargetPort.Value = AppConfig.DEFAULT_SERVER_PORT;
            txtServerAddress.Text = AppConfig.DEFAULT_SERVER_ADDRESS;
            
            radioButtonTEA.Checked = true;
        }

        private void InitializeNetworkComponents()
        {
            fileTransferClient = new FileTransferClient();
            fileTransferClient.StatusChanged += (sender, status) => 
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddNetworkStatus(status)));
                }
                else
                {
                    AddNetworkStatus(status);
                }
            };
        }

        #region Settings Tab Events

        private void btnBrowseTarget_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtTargetFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        #endregion

        #region File Watcher Tab Events

        private void btnStartMonitoring_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTargetFolder.Text) || string.IsNullOrWhiteSpace(txtOutputFolder.Text))
                {
                    MessageBox.Show("Molimo specificirajte i Target i X folder.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEncryptionKey.Text))
                {
                    MessageBox.Show("Molimo unesite ključ za enkripciju.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Directory.Exists(txtTargetFolder.Text))
                    Directory.CreateDirectory(txtTargetFolder.Text);
                
                if (!Directory.Exists(txtOutputFolder.Text))
                    Directory.CreateDirectory(txtOutputFolder.Text);

                fileSystemWatcher = new FileSystemWatcher();
                fileSystemWatcher.Path = txtTargetFolder.Text;
                fileSystemWatcher.Filter = "*.*";
                fileSystemWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName;
                fileSystemWatcher.Created += OnFileCreated;
                fileSystemWatcher.EnableRaisingEvents = true;

                btnStartMonitoring.Enabled = false;
                btnStopMonitoring.Enabled = true;

                AddFileWatcherStatus($"Praćenje pokrenuto za folder: {txtTargetFolder.Text}");
                AddFileWatcherStatus($"Enkriptovani fajlovi će biti sačuvani u: {txtOutputFolder.Text}");
                AddFileWatcherStatus($"Koristi se algoritam: {GetSelectedAlgorithmDisplayName()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri pokretanju praćenja: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopMonitoring_Click(object sender, EventArgs e)
        {
            StopFileWatcher();
        }

        private void StopFileWatcher()
        {
            if (fileSystemWatcher != null)
            {
                fileSystemWatcher.EnableRaisingEvents = false;
                fileSystemWatcher.Dispose();
                fileSystemWatcher = null;
            }

            btnStartMonitoring.Enabled = true;
            btnStopMonitoring.Enabled = false;
            AddFileWatcherStatus("Praćenje zaustavljeno.");
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                //Cekamo da budemo sigurni da je fajl potpuno kreiran
                System.Threading.Thread.Sleep(100);

                if (!File.Exists(e.FullPath))
                    return;

                byte[] fileContent = File.ReadAllBytes(e.FullPath);
                
                EncryptionAlgorithm algorithm = GetSelectedAlgorithm();
                string key = txtEncryptionKey.Text;
                
                byte[] encryptedContent = EncryptionManager.Encrypt(fileContent, algorithm, key);

                string outputFileName = AppConfig.CreateEncryptedFileName(e.Name);
                string outputPath = Path.Combine(txtOutputFolder.Text, outputFileName);

                File.WriteAllBytes(outputPath, encryptedContent);

                Invoke(new Action(() =>
                {
                    AddFileWatcherStatus($"Fajl obrađen: {e.Name} -> {outputFileName}");
                    AddFileWatcherStatus($"Algoritam: {EncryptionManager.GetAlgorithmDisplayName(algorithm)}");
                    AddFileWatcherStatus($"Originalnu veličina: {fileContent.Length} bajtova");
                    AddFileWatcherStatus($"Enkriptovana veličina: {encryptedContent.Length} bajtova");
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    AddFileWatcherStatus($"Greška pri obradi fajla {e.Name}: {ex.Message}");
                }));
            }
        }

        #endregion

        #region Manual Encryption Tab Events

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEncryptionKey.Text))
                {
                    MessageBox.Show("Molimo unesite ključ za enkripciju.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtOutputFolder.Text))
                {
                    MessageBox.Show("Molimo specificirajte X folder.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFile = openFileDialog.FileName;
                    AddManualStatus($"Učitava se fajl: {inputFile}");
                    
                    byte[] fileContent = File.ReadAllBytes(inputFile);
                    AddManualStatus($"Pročitano {fileContent.Length} bajtova");
                    
                    EncryptionAlgorithm algorithm = GetSelectedAlgorithm();
                    string key = txtEncryptionKey.Text;
                    
                    byte[] encryptedContent = EncryptionManager.Encrypt(fileContent, algorithm, key);
                    AddManualStatus($"Enkripcija završena. Enkriptovano {encryptedContent.Length} bajtova");
                    
                    if (!Directory.Exists(txtOutputFolder.Text))
                        Directory.CreateDirectory(txtOutputFolder.Text);
                    
                    string originalFileName = Path.GetFileNameWithoutExtension(inputFile);
                    string outputFileName = $"encrypted_{originalFileName}.txt";
                    string outputPath = Path.Combine(txtOutputFolder.Text, outputFileName);
                    
                    File.WriteAllBytes(outputPath, encryptedContent);
                    AddManualStatus($"Enkriptovani fajl sačuvan: {outputPath}");
                    AddManualStatus($"Algoritam: {EncryptionManager.GetAlgorithmDisplayName(algorithm)}");
                }
            }
            catch (Exception ex)
            {
                AddManualStatus($"Greška pri enkripciji: {ex.Message}");
                MessageBox.Show($"Greška pri enkripciji: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEncryptionKey.Text))
                {
                    MessageBox.Show("Molimo unesite ključ za dekripciju.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                openFileDialog.Title = "Izaberite enkriptovani fajl";
                openFileDialog.Filter = "Enkriptovani fajlovi (*.txt)|*.txt|Svi fajlovi (*.*)|*.*";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFile = openFileDialog.FileName;
                    AddManualStatus($"Učitava se enkriptovani fajl: {inputFile}");
                    
                    byte[] encryptedContent = File.ReadAllBytes(inputFile);
                    AddManualStatus($"Pročitano {encryptedContent.Length} bajtova");
                    
                    EncryptionAlgorithm algorithm = GetSelectedAlgorithm();
                    string key = txtEncryptionKey.Text;
                    
                    byte[] decryptedContent = EncryptionManager.Decrypt(encryptedContent, algorithm, key);
                    AddManualStatus($"Dekripcija završena. Dekriptovano {decryptedContent.Length} bajtova");
                    
                    saveFileDialog.Title = "Sačuvajte dekriptovani fajl";
                    saveFileDialog.Filter = "Svi fajlovi (*.*)|*.*";
                    string originalName = Path.GetFileNameWithoutExtension(inputFile);
                    if (originalName.StartsWith("encrypted_"))
                    {
                        originalName = originalName.Substring(10); // Sklonimo enkripted prefix
                    }
                    saveFileDialog.FileName = $"decrypted_{originalName}";
                    
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, decryptedContent);
                        AddManualStatus($"Dekriptovani fajl sačuvan: {saveFileDialog.FileName}");
                        AddManualStatus($"Algoritam: {EncryptionManager.GetAlgorithmDisplayName(algorithm)}");
                        
                        MessageBox.Show("Dekripcija uspešno završena!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                openFileDialog.Title = "Izaberite fajl za enkripciju";
                openFileDialog.Filter = "Svi fajlovi (*.*)|*.*";
            }
            catch (Exception ex)
            {
                AddManualStatus($"Greška pri dekripciji: {ex.Message}");
                MessageBox.Show($"Greška pri dekripciji: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Networking Tab Events

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileTransferServer != null)
                {
                    MessageBox.Show("Server je već pokrenut!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int port = (int)numericUpDownPort.Value;
                
                fileTransferServer = new FileTransferServer();
                fileTransferServer.StatusChanged += (s, status) =>
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => AddNetworkStatus(status)));
                    }
                    else
                    {
                        AddNetworkStatus(status);
                    }
                };
                
                fileTransferServer.FileReceived += OnFileReceived;
                
                serverTask = Task.Run(() => fileTransferServer.StartServerAsync(port));
                
                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;
                
                AddNetworkStatus($"Pokretanje servera na portu {port}...");
                
                await Task.Delay(500);
            }
            catch (Exception ex)
            {
                AddNetworkStatus($"Greška pri pokretanju servera: {ex.Message}");
                MessageBox.Show($"Greška pri pokretanju servera: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (fileTransferServer != null)
            {
                fileTransferServer.StopServer();
                fileTransferServer = null;
            }
            
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
            
            AddNetworkStatus("Server zaustavljen.");
        }

        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServerAddress.Text))
                {
                    MessageBox.Show("Molimo unesite adresu servera.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEncryptionKey.Text))
                {
                    MessageBox.Show("Molimo unesite ključ za enkripciju.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                openFileDialog.Title = "Izaberite fajl za slanje";
                openFileDialog.Filter = "Svi fajlovi (*.*)|*.*";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFile = openFileDialog.FileName;
                    string fileName = Path.GetFileName(inputFile);
                    
                    AddNetworkStatus($"Priprema fajla za slanje: {fileName}");
                    
                    byte[] fileContent = File.ReadAllBytes(inputFile);
                    EncryptionAlgorithm algorithm = GetSelectedAlgorithm();
                    string key = txtEncryptionKey.Text;
                    
                    byte[] encryptedContent = EncryptionManager.Encrypt(fileContent, algorithm, key);
                    
                    AddNetworkStatus($"Fajl enkriptovan ({encryptedContent.Length} bajtova)");
                    AddNetworkStatus($"Algoritam: {EncryptionManager.GetAlgorithmDisplayName(algorithm)}");
                    
                    string serverAddress = txtServerAddress.Text;
                    int port = (int)numericUpDownTargetPort.Value;
                    
                    await fileTransferClient.SendFileAsync(serverAddress, port, fileName, encryptedContent);
                    
                    AddNetworkStatus("Fajl uspešno poslat!");
                }
            }
            catch (Exception ex)
            {
                AddNetworkStatus($"Greška pri slanju fajla: {ex.Message}");
                MessageBox.Show($"Greška pri slanju fajla: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFileReceived(object sender, FileReceivedEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => OnFileReceived(sender, e)));
                    return;
                }

                AddNetworkStatus($"Fajl primljen: {e.FileName}");
                AddNetworkStatus($"Veličina: {e.EncryptedData.Length} bajtova");
                AddNetworkStatus($"Hash valjan: {e.IsHashValid}");
                
                if (!e.IsHashValid)
                {
                    AddNetworkStatus("UPOZORENJE: Hash nije valjan! Fajl možda nije ispravno primljen.");
                    if (MessageBox.Show("Hash nije valjan! Da li želite da dekriptujete fajl?", "Upozorenje", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
                
                DialogResult result = MessageBox.Show($"Da li želite da dekriptujete i sačuvate primljeni fajl '{e.FileName}'?", 
                    "Dekriptovanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    EncryptionAlgorithm algorithm = GetSelectedAlgorithm();
                    string key = txtEncryptionKey.Text;
                    
                    byte[] decryptedContent = EncryptionManager.Decrypt(e.EncryptedData, algorithm, key);
                    
                    saveFileDialog.Title = "Sačuvajte primljeni fajl";
                    saveFileDialog.FileName = $"received_{e.FileName}";
                    
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, decryptedContent);
                        AddNetworkStatus($"Dekriptovani fajl sačuvan: {saveFileDialog.FileName}");
                        AddNetworkStatus($"Dekriptovano {decryptedContent.Length} bajtova");
                        
                        MessageBox.Show("Fajl uspešno primljen i dekriptovan!", "Uspeh", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                AddNetworkStatus($"Greška pri obradi primljenog fajla: {ex.Message}");
                MessageBox.Show($"Greška pri obradi primljenog fajla: {ex.Message}", "Greška", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private EncryptionAlgorithm GetSelectedAlgorithm()
        {
            if (radioButtonTEA.Checked) return EncryptionAlgorithm.TEA;
            if (radioButtonLEA.Checked) return EncryptionAlgorithm.LEA;
            if (radioButtonCRT.Checked) return EncryptionAlgorithm.CTR;
            
            return EncryptionAlgorithm.TEA;
        }

        private string GetSelectedAlgorithmDisplayName()
        {
            return EncryptionManager.GetAlgorithmDisplayName(GetSelectedAlgorithm());
        }

        private void AddFileWatcherStatus(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtFileWatcherStatus.AppendText($"[{timestamp}] {message}\r\n");
            txtFileWatcherStatus.SelectionStart = txtFileWatcherStatus.Text.Length;
            txtFileWatcherStatus.ScrollToCaret();
        }

        private void AddManualStatus(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtManualStatus.AppendText($"[{timestamp}] {message}\r\n");
            txtManualStatus.SelectionStart = txtManualStatus.Text.Length;
            txtManualStatus.ScrollToCaret();
        }

        private void AddNetworkStatus(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtNetworkStatus.AppendText($"[{timestamp}] {message}\r\n");
            txtNetworkStatus.SelectionStart = txtNetworkStatus.Text.Length;
            txtNetworkStatus.ScrollToCaret();
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopFileWatcher();
            StopServer();
        }

    }
}
