# Information Security - Encryptor/Decryptor with TCP

An advanced application for encrypting, decrypting, and network file transfer with implemented TEA, LEA, and CRT algorithms.

## Features

### 1. Encryption Algorithms
- **TEA (Tiny Encryption Algorithm)** - Fast and simple block cipher  
- **LEA (Lightweight Encryption Algorithm)** - Lightweight algorithm optimized for performance  
- **CRT (Chinese Remainder Theorem)** - Mathematical approach to encryption  

### 2. File System Watcher (FSW)
- Automatic monitoring of the Target folder for new files  
- Automatic encryption of detected files  
- Saves encrypted files in the X folder with the prefix `encrypted_`  
- Real-time monitoring status  

### 3. Manual Encryption/Decryption
- Manual file selection for encryption  
- Decryption of encrypted files  
- Freedom to choose output location for decrypted files  

### 4. Network File Transfer (TCP)
- **Server mode**: Receive encrypted files via TCP  
- **Client mode**: Send encrypted files to another server  
- SHA1 hash verification for file integrity  
- Automatic hash check on file reception  

### 5. Cryptographic Hash Verification
- SHA1 algorithm for hash generation  
- Automatic verification of transferred file integrity  
- Alerts on hash mismatch  

## Usage

### Settings
1. Choose the encryption algorithm (TEA, LEA, or CRT)  
2. Set the Target folder (where FSW monitors new files)  
3. Set the X folder (where encrypted files are saved)  
4. Enter the encryption key (default: `1234567890abcdef`)  

### File System Watcher
1. Go to the "File System Watcher" tab  
2. Click "Start Monitoring"  
3. Add files to the Target folder  
4. The application will automatically encrypt new files  

### Manual Encryption
1. Go to the "Manual Encryption" tab  
2. To encrypt: Click "Encrypt File" and select a file  
3. To decrypt: Click "Decrypt File" and select an encrypted file  

### Network Transfer
1. Go to the "Network Transfer" tab  
2. **To receive**: Enter the port and click "Start" (server mode)  
3. **To send**: Enter the destination IP and port, then click "Send File"  

## File Transfer Protocol

The application uses the following protocol for file transfer:

String: File name

Long: File size in bytes

Int: SHA1 hash length (20 bytes)

Byte[]: SHA1 hash of the encrypted file

Byte[]: Encrypted file content


## Security Features

- All data is transferred encrypted  
- SHA1 hash verification ensures file integrity  
- Supports multiple encryption algorithms  
- Secure key exchange (user responsible for key distribution)  

## Technical Details

- **Framework**: .NET Framework 4.7.2  
- **Language**: C# 7.3  
- **UI**: Windows Forms  
- **Network**: TCP sockets  
- **Hash Algorithm**: SHA1  
- **Encryption**: Custom implementations of TEA, LEA, and CRT algorithms  

## Notes

- The app automatically creates Target and X folders if they don't exist  
- Default locations are `Desktop\Target` and `Desktop\X`  
- All algorithms are implemented from scratch without external libraries  
- Supports simultaneous sending and receiving of files  
