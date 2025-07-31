namespace ZastitaInformacija_18658
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBoxAlgorithm = new System.Windows.Forms.GroupBox();
            this.radioButtonCRT = new System.Windows.Forms.RadioButton();
            this.radioButtonLEA = new System.Windows.Forms.RadioButton();
            this.radioButtonTEA = new System.Windows.Forms.RadioButton();
            this.groupBoxFolders = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.btnBrowseTarget = new System.Windows.Forms.Button();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.lblTargetFolder = new System.Windows.Forms.Label();
            this.groupBoxKey = new System.Windows.Forms.GroupBox();
            this.txtEncryptionKey = new System.Windows.Forms.TextBox();
            this.lblEncryptionKey = new System.Windows.Forms.Label();
            this.tabFileWatcher = new System.Windows.Forms.TabPage();
            this.btnStopMonitoring = new System.Windows.Forms.Button();
            this.btnStartMonitoring = new System.Windows.Forms.Button();
            this.lblFileWatcherStatus = new System.Windows.Forms.Label();
            this.txtFileWatcherStatus = new System.Windows.Forms.TextBox();
            this.tabManualEncryption = new System.Windows.Forms.TabPage();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.lblManualStatus = new System.Windows.Forms.Label();
            this.txtManualStatus = new System.Windows.Forms.TextBox();
            this.tabNetworking = new System.Windows.Forms.TabPage();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.numericUpDownTargetPort = new System.Windows.Forms.NumericUpDown();
            this.lblTargetPort = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.lblNetworkStatus = new System.Windows.Forms.Label();
            this.txtNetworkStatus = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBoxAlgorithm.SuspendLayout();
            this.groupBoxFolders.SuspendLayout();
            this.groupBoxKey.SuspendLayout();
            this.tabFileWatcher.SuspendLayout();
            this.tabManualEncryption.SuspendLayout();
            this.tabNetworking.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.groupBoxClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTargetPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabFileWatcher);
            this.tabControl.Controls.Add(this.tabManualEncryption);
            this.tabControl.Controls.Add(this.tabNetworking);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(20, 8);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1038, 650);
            this.tabControl.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.Lavender;
            this.tabSettings.Controls.Add(this.groupBoxAlgorithm);
            this.tabSettings.Controls.Add(this.groupBoxFolders);
            this.tabSettings.Controls.Add(this.groupBoxKey);
            this.tabSettings.Location = new System.Drawing.Point(4, 42);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(25);
            this.tabSettings.Size = new System.Drawing.Size(1030, 604);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "⚙️ Podešavanja";
            // 
            // groupBoxAlgorithm
            // 
            this.groupBoxAlgorithm.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBoxAlgorithm.Controls.Add(this.radioButtonCRT);
            this.groupBoxAlgorithm.Controls.Add(this.radioButtonLEA);
            this.groupBoxAlgorithm.Controls.Add(this.radioButtonTEA);
            this.groupBoxAlgorithm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.groupBoxAlgorithm.Location = new System.Drawing.Point(25, 25);
            this.groupBoxAlgorithm.Name = "groupBoxAlgorithm";
            this.groupBoxAlgorithm.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxAlgorithm.Size = new System.Drawing.Size(977, 120);
            this.groupBoxAlgorithm.TabIndex = 0;
            this.groupBoxAlgorithm.TabStop = false;
            this.groupBoxAlgorithm.Text = "🔐 Algoritam enkripcije";
            // 
            // radioButtonCRT
            // 
            this.radioButtonCRT.AutoSize = true;
            this.radioButtonCRT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButtonCRT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.radioButtonCRT.Location = new System.Drawing.Point(668, 50);
            this.radioButtonCRT.Name = "radioButtonCRT";
            this.radioButtonCRT.Size = new System.Drawing.Size(295, 27);
            this.radioButtonCRT.TabIndex = 2;
            this.radioButtonCRT.Text = "CRT (Chinese Remainder Theorem)";
            this.radioButtonCRT.UseVisualStyleBackColor = true;
            // 
            // radioButtonLEA
            // 
            this.radioButtonLEA.AutoSize = true;
            this.radioButtonLEA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButtonLEA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.radioButtonLEA.Location = new System.Drawing.Point(318, 50);
            this.radioButtonLEA.Name = "radioButtonLEA";
            this.radioButtonLEA.Size = new System.Drawing.Size(330, 27);
            this.radioButtonLEA.TabIndex = 1;
            this.radioButtonLEA.Text = "LEA (Lightweight Encryption Algorithm)";
            this.radioButtonLEA.UseVisualStyleBackColor = true;
            // 
            // radioButtonTEA
            // 
            this.radioButtonTEA.AutoSize = true;
            this.radioButtonTEA.Checked = true;
            this.radioButtonTEA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButtonTEA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.radioButtonTEA.Location = new System.Drawing.Point(30, 50);
            this.radioButtonTEA.Name = "radioButtonTEA";
            this.radioButtonTEA.Size = new System.Drawing.Size(273, 27);
            this.radioButtonTEA.TabIndex = 0;
            this.radioButtonTEA.TabStop = true;
            this.radioButtonTEA.Text = "TEA (Tiny Encryption Algorithm)";
            this.radioButtonTEA.UseVisualStyleBackColor = true;
            // 
            // groupBoxFolders
            // 
            this.groupBoxFolders.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBoxFolders.Controls.Add(this.btnBrowseOutput);
            this.groupBoxFolders.Controls.Add(this.txtOutputFolder);
            this.groupBoxFolders.Controls.Add(this.lblOutputFolder);
            this.groupBoxFolders.Controls.Add(this.btnBrowseTarget);
            this.groupBoxFolders.Controls.Add(this.txtTargetFolder);
            this.groupBoxFolders.Controls.Add(this.lblTargetFolder);
            this.groupBoxFolders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.groupBoxFolders.Location = new System.Drawing.Point(25, 165);
            this.groupBoxFolders.Name = "groupBoxFolders";
            this.groupBoxFolders.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxFolders.Size = new System.Drawing.Size(977, 160);
            this.groupBoxFolders.TabIndex = 1;
            this.groupBoxFolders.TabStop = false;
            this.groupBoxFolders.Text = "📁 Direktorijumi";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBrowseOutput.FlatAppearance.BorderSize = 0;
            this.btnBrowseOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseOutput.ForeColor = System.Drawing.Color.White;
            this.btnBrowseOutput.Location = new System.Drawing.Point(856, 105);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(98, 30);
            this.btnBrowseOutput.TabIndex = 5;
            this.btnBrowseOutput.Text = "Pretraži";
            this.btnBrowseOutput.UseVisualStyleBackColor = false;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOutputFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtOutputFolder.Location = new System.Drawing.Point(200, 105);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(620, 30);
            this.txtOutputFolder.TabIndex = 4;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOutputFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblOutputFolder.Location = new System.Drawing.Point(26, 112);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(136, 23);
            this.lblOutputFolder.TabIndex = 3;
            this.lblOutputFolder.Text = "Izlazni folder (X):";
            // 
            // btnBrowseTarget
            // 
            this.btnBrowseTarget.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBrowseTarget.FlatAppearance.BorderSize = 0;
            this.btnBrowseTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseTarget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseTarget.ForeColor = System.Drawing.Color.White;
            this.btnBrowseTarget.Location = new System.Drawing.Point(856, 53);
            this.btnBrowseTarget.Name = "btnBrowseTarget";
            this.btnBrowseTarget.Size = new System.Drawing.Size(98, 30);
            this.btnBrowseTarget.TabIndex = 2;
            this.btnBrowseTarget.Text = "Pretraži";
            this.btnBrowseTarget.UseVisualStyleBackColor = false;
            this.btnBrowseTarget.Click += new System.EventHandler(this.btnBrowseTarget_Click);
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTargetFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtTargetFolder.Location = new System.Drawing.Point(200, 53);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(620, 30);
            this.txtTargetFolder.TabIndex = 1;
            // 
            // lblTargetFolder
            // 
            this.lblTargetFolder.AutoSize = true;
            this.lblTargetFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTargetFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblTargetFolder.Location = new System.Drawing.Point(26, 60);
            this.lblTargetFolder.Name = "lblTargetFolder";
            this.lblTargetFolder.Size = new System.Drawing.Size(162, 23);
            this.lblTargetFolder.TabIndex = 0;
            this.lblTargetFolder.Text = "Ciljni folder (Target):";
            // 
            // groupBoxKey
            // 
            this.groupBoxKey.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBoxKey.Controls.Add(this.txtEncryptionKey);
            this.groupBoxKey.Controls.Add(this.lblEncryptionKey);
            this.groupBoxKey.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.groupBoxKey.Location = new System.Drawing.Point(25, 345);
            this.groupBoxKey.Name = "groupBoxKey";
            this.groupBoxKey.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxKey.Size = new System.Drawing.Size(977, 100);
            this.groupBoxKey.TabIndex = 2;
            this.groupBoxKey.TabStop = false;
            this.groupBoxKey.Text = "🔑 Ključ za enkripciju";
            // 
            // txtEncryptionKey
            // 
            this.txtEncryptionKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEncryptionKey.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtEncryptionKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtEncryptionKey.Location = new System.Drawing.Point(234, 49);
            this.txtEncryptionKey.Name = "txtEncryptionKey";
            this.txtEncryptionKey.Size = new System.Drawing.Size(720, 27);
            this.txtEncryptionKey.TabIndex = 1;
            this.txtEncryptionKey.Text = "1234567890abcdef";
            // 
            // lblEncryptionKey
            // 
            this.lblEncryptionKey.AutoSize = true;
            this.lblEncryptionKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEncryptionKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblEncryptionKey.Location = new System.Drawing.Point(26, 53);
            this.lblEncryptionKey.Name = "lblEncryptionKey";
            this.lblEncryptionKey.Size = new System.Drawing.Size(127, 23);
            this.lblEncryptionKey.TabIndex = 0;
            this.lblEncryptionKey.Text = "Ključ enkripcije:";
            // 
            // tabFileWatcher
            // 
            this.tabFileWatcher.BackColor = System.Drawing.Color.Lavender;
            this.tabFileWatcher.Controls.Add(this.btnStopMonitoring);
            this.tabFileWatcher.Controls.Add(this.btnStartMonitoring);
            this.tabFileWatcher.Controls.Add(this.lblFileWatcherStatus);
            this.tabFileWatcher.Controls.Add(this.txtFileWatcherStatus);
            this.tabFileWatcher.Location = new System.Drawing.Point(4, 42);
            this.tabFileWatcher.Name = "tabFileWatcher";
            this.tabFileWatcher.Padding = new System.Windows.Forms.Padding(25);
            this.tabFileWatcher.Size = new System.Drawing.Size(1030, 604);
            this.tabFileWatcher.TabIndex = 1;
            this.tabFileWatcher.Text = "👁️ File System Watcher";
            // 
            // btnStopMonitoring
            // 
            this.btnStopMonitoring.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStopMonitoring.Enabled = false;
            this.btnStopMonitoring.FlatAppearance.BorderSize = 0;
            this.btnStopMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMonitoring.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStopMonitoring.ForeColor = System.Drawing.Color.White;
            this.btnStopMonitoring.Location = new System.Drawing.Point(217, 25);
            this.btnStopMonitoring.Name = "btnStopMonitoring";
            this.btnStopMonitoring.Size = new System.Drawing.Size(186, 45);
            this.btnStopMonitoring.TabIndex = 1;
            this.btnStopMonitoring.Text = "⏹️ Zaustavi praćenje";
            this.btnStopMonitoring.UseVisualStyleBackColor = false;
            this.btnStopMonitoring.Click += new System.EventHandler(this.btnStopMonitoring_Click);
            // 
            // btnStartMonitoring
            // 
            this.btnStartMonitoring.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStartMonitoring.FlatAppearance.BorderSize = 0;
            this.btnStartMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMonitoring.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartMonitoring.ForeColor = System.Drawing.Color.White;
            this.btnStartMonitoring.Location = new System.Drawing.Point(25, 25);
            this.btnStartMonitoring.Name = "btnStartMonitoring";
            this.btnStartMonitoring.Size = new System.Drawing.Size(186, 45);
            this.btnStartMonitoring.TabIndex = 0;
            this.btnStartMonitoring.Text = "▶️ Pokreni praćenje";
            this.btnStartMonitoring.UseVisualStyleBackColor = false;
            this.btnStartMonitoring.Click += new System.EventHandler(this.btnStartMonitoring_Click);
            // 
            // lblFileWatcherStatus
            // 
            this.lblFileWatcherStatus.AutoSize = true;
            this.lblFileWatcherStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFileWatcherStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblFileWatcherStatus.Location = new System.Drawing.Point(25, 90);
            this.lblFileWatcherStatus.Name = "lblFileWatcherStatus";
            this.lblFileWatcherStatus.Size = new System.Drawing.Size(95, 25);
            this.lblFileWatcherStatus.TabIndex = 2;
            this.lblFileWatcherStatus.Text = "📋 Status:";
            // 
            // txtFileWatcherStatus
            // 
            this.txtFileWatcherStatus.BackColor = System.Drawing.Color.GhostWhite;
            this.txtFileWatcherStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileWatcherStatus.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtFileWatcherStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtFileWatcherStatus.Location = new System.Drawing.Point(25, 120);
            this.txtFileWatcherStatus.Multiline = true;
            this.txtFileWatcherStatus.Name = "txtFileWatcherStatus";
            this.txtFileWatcherStatus.ReadOnly = true;
            this.txtFileWatcherStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFileWatcherStatus.Size = new System.Drawing.Size(977, 469);
            this.txtFileWatcherStatus.TabIndex = 3;
            // 
            // tabManualEncryption
            // 
            this.tabManualEncryption.BackColor = System.Drawing.Color.Lavender;
            this.tabManualEncryption.Controls.Add(this.btnDecryptFile);
            this.tabManualEncryption.Controls.Add(this.btnEncryptFile);
            this.tabManualEncryption.Controls.Add(this.lblManualStatus);
            this.tabManualEncryption.Controls.Add(this.txtManualStatus);
            this.tabManualEncryption.Location = new System.Drawing.Point(4, 42);
            this.tabManualEncryption.Name = "tabManualEncryption";
            this.tabManualEncryption.Padding = new System.Windows.Forms.Padding(25);
            this.tabManualEncryption.Size = new System.Drawing.Size(1030, 604);
            this.tabManualEncryption.TabIndex = 2;
            this.tabManualEncryption.Text = "🔒 Ručna enkripcija";
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDecryptFile.FlatAppearance.BorderSize = 0;
            this.btnDecryptFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecryptFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDecryptFile.ForeColor = System.Drawing.Color.White;
            this.btnDecryptFile.Location = new System.Drawing.Point(217, 25);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(186, 45);
            this.btnDecryptFile.TabIndex = 1;
            this.btnDecryptFile.Text = "🔓 Dekriptuj fajl";
            this.btnDecryptFile.UseVisualStyleBackColor = false;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEncryptFile.FlatAppearance.BorderSize = 0;
            this.btnEncryptFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncryptFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEncryptFile.ForeColor = System.Drawing.Color.White;
            this.btnEncryptFile.Location = new System.Drawing.Point(25, 25);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(186, 45);
            this.btnEncryptFile.TabIndex = 0;
            this.btnEncryptFile.Text = "🔐 Enkriptuj fajl";
            this.btnEncryptFile.UseVisualStyleBackColor = false;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // lblManualStatus
            // 
            this.lblManualStatus.AutoSize = true;
            this.lblManualStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblManualStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblManualStatus.Location = new System.Drawing.Point(25, 90);
            this.lblManualStatus.Name = "lblManualStatus";
            this.lblManualStatus.Size = new System.Drawing.Size(95, 25);
            this.lblManualStatus.TabIndex = 2;
            this.lblManualStatus.Text = "📋 Status:";
            // 
            // txtManualStatus
            // 
            this.txtManualStatus.BackColor = System.Drawing.Color.GhostWhite;
            this.txtManualStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManualStatus.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtManualStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtManualStatus.Location = new System.Drawing.Point(25, 120);
            this.txtManualStatus.Multiline = true;
            this.txtManualStatus.Name = "txtManualStatus";
            this.txtManualStatus.ReadOnly = true;
            this.txtManualStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtManualStatus.Size = new System.Drawing.Size(942, 469);
            this.txtManualStatus.TabIndex = 3;
            // 
            // tabNetworking
            // 
            this.tabNetworking.BackColor = System.Drawing.Color.Lavender;
            this.tabNetworking.Controls.Add(this.groupBoxServer);
            this.tabNetworking.Controls.Add(this.groupBoxClient);
            this.tabNetworking.Controls.Add(this.lblNetworkStatus);
            this.tabNetworking.Controls.Add(this.txtNetworkStatus);
            this.tabNetworking.Location = new System.Drawing.Point(4, 42);
            this.tabNetworking.Name = "tabNetworking";
            this.tabNetworking.Padding = new System.Windows.Forms.Padding(25);
            this.tabNetworking.Size = new System.Drawing.Size(1030, 604);
            this.tabNetworking.TabIndex = 3;
            this.tabNetworking.Text = "🌐 Mrežna razmena";
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBoxServer.Controls.Add(this.btnStopServer);
            this.groupBoxServer.Controls.Add(this.btnStartServer);
            this.groupBoxServer.Controls.Add(this.numericUpDownPort);
            this.groupBoxServer.Controls.Add(this.lblPort);
            this.groupBoxServer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.groupBoxServer.Location = new System.Drawing.Point(25, 25);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxServer.Size = new System.Drawing.Size(460, 130);
            this.groupBoxServer.TabIndex = 0;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "📥 Server (Prijem fajlova)";
            // 
            // btnStopServer
            // 
            this.btnStopServer.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStopServer.Enabled = false;
            this.btnStopServer.FlatAppearance.BorderSize = 0;
            this.btnStopServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStopServer.ForeColor = System.Drawing.Color.White;
            this.btnStopServer.Location = new System.Drawing.Point(339, 82);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(109, 35);
            this.btnStopServer.TabIndex = 3;
            this.btnStopServer.Text = "⏹️ Zaustavi";
            this.btnStopServer.UseVisualStyleBackColor = false;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStartServer.FlatAppearance.BorderSize = 0;
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStartServer.ForeColor = System.Drawing.Color.White;
            this.btnStartServer.Location = new System.Drawing.Point(224, 82);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(109, 35);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "▶️ Pokreni";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.numericUpDownPort.Location = new System.Drawing.Point(78, 45);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(120, 30);
            this.numericUpDownPort.TabIndex = 1;
            this.numericUpDownPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblPort.Location = new System.Drawing.Point(23, 52);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(45, 23);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBoxClient.Controls.Add(this.btnSendFile);
            this.groupBoxClient.Controls.Add(this.numericUpDownTargetPort);
            this.groupBoxClient.Controls.Add(this.lblTargetPort);
            this.groupBoxClient.Controls.Add(this.txtServerAddress);
            this.groupBoxClient.Controls.Add(this.lblServerAddress);
            this.groupBoxClient.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.groupBoxClient.Location = new System.Drawing.Point(542, 25);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxClient.Size = new System.Drawing.Size(460, 130);
            this.groupBoxClient.TabIndex = 1;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "📤 Klijent (Slanje fajlova)";
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSendFile.FlatAppearance.BorderSize = 0;
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Location = new System.Drawing.Point(338, 82);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(110, 35);
            this.btnSendFile.TabIndex = 4;
            this.btnSendFile.Text = "📋 Pošalji fajl";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // numericUpDownTargetPort
            // 
            this.numericUpDownTargetPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownTargetPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownTargetPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.numericUpDownTargetPort.Location = new System.Drawing.Point(90, 82);
            this.numericUpDownTargetPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownTargetPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownTargetPort.Name = "numericUpDownTargetPort";
            this.numericUpDownTargetPort.Size = new System.Drawing.Size(120, 30);
            this.numericUpDownTargetPort.TabIndex = 3;
            this.numericUpDownTargetPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // lblTargetPort
            // 
            this.lblTargetPort.AutoSize = true;
            this.lblTargetPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTargetPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblTargetPort.Location = new System.Drawing.Point(18, 89);
            this.lblTargetPort.Name = "lblTargetPort";
            this.lblTargetPort.Size = new System.Drawing.Size(45, 23);
            this.lblTargetPort.TabIndex = 2;
            this.lblTargetPort.Text = "Port:";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServerAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtServerAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtServerAddress.Location = new System.Drawing.Point(90, 43);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(150, 30);
            this.txtServerAddress.TabIndex = 1;
            this.txtServerAddress.Text = "127.0.0.1";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblServerAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblServerAddress.Location = new System.Drawing.Point(18, 50);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(66, 23);
            this.lblServerAddress.TabIndex = 0;
            this.lblServerAddress.Text = "Adresa:";
            // 
            // lblNetworkStatus
            // 
            this.lblNetworkStatus.AutoSize = true;
            this.lblNetworkStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNetworkStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblNetworkStatus.Location = new System.Drawing.Point(25, 175);
            this.lblNetworkStatus.Name = "lblNetworkStatus";
            this.lblNetworkStatus.Size = new System.Drawing.Size(95, 25);
            this.lblNetworkStatus.TabIndex = 2;
            this.lblNetworkStatus.Text = "📋 Status:";
            // 
            // txtNetworkStatus
            // 
            this.txtNetworkStatus.BackColor = System.Drawing.Color.GhostWhite;
            this.txtNetworkStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetworkStatus.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtNetworkStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtNetworkStatus.Location = new System.Drawing.Point(25, 205);
            this.txtNetworkStatus.Multiline = true;
            this.txtNetworkStatus.Name = "txtNetworkStatus";
            this.txtNetworkStatus.ReadOnly = true;
            this.txtNetworkStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNetworkStatus.Size = new System.Drawing.Size(977, 384);
            this.txtNetworkStatus.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Svi fajlovi (*.*)|*.*";
            this.openFileDialog.Title = "Izaberite fajl za enkripciju";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Svi fajlovi (*.*)|*.*";
            this.saveFileDialog.Title = "Sačuvajte dekriptovani fajl";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1038, 650);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🔐 Zaštita Informacija - Enkriptor/Dekriptor sa TCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBoxAlgorithm.ResumeLayout(false);
            this.groupBoxAlgorithm.PerformLayout();
            this.groupBoxFolders.ResumeLayout(false);
            this.groupBoxFolders.PerformLayout();
            this.groupBoxKey.ResumeLayout(false);
            this.groupBoxKey.PerformLayout();
            this.tabFileWatcher.ResumeLayout(false);
            this.tabFileWatcher.PerformLayout();
            this.tabManualEncryption.ResumeLayout(false);
            this.tabManualEncryption.PerformLayout();
            this.tabNetworking.ResumeLayout(false);
            this.tabNetworking.PerformLayout();
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTargetPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabFileWatcher;
        private System.Windows.Forms.TabPage tabManualEncryption;
        private System.Windows.Forms.TabPage tabNetworking;
        
        private System.Windows.Forms.GroupBox groupBoxAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonCRT;
        private System.Windows.Forms.RadioButton radioButtonLEA;
        private System.Windows.Forms.RadioButton radioButtonTEA;
        
        private System.Windows.Forms.GroupBox groupBoxFolders;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.Button btnBrowseTarget;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Label lblTargetFolder;
        
        private System.Windows.Forms.GroupBox groupBoxKey;
        private System.Windows.Forms.TextBox txtEncryptionKey;
        private System.Windows.Forms.Label lblEncryptionKey;
        
        private System.Windows.Forms.Button btnStopMonitoring;
        private System.Windows.Forms.Button btnStartMonitoring;
        private System.Windows.Forms.Label lblFileWatcherStatus;
        private System.Windows.Forms.TextBox txtFileWatcherStatus;
        
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Label lblManualStatus;
        private System.Windows.Forms.TextBox txtManualStatus;
        
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label lblPort;
        
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.NumericUpDown numericUpDownTargetPort;
        private System.Windows.Forms.Label lblTargetPort;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label lblServerAddress;
        
        private System.Windows.Forms.Label lblNetworkStatus;
        private System.Windows.Forms.TextBox txtNetworkStatus;
        
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

