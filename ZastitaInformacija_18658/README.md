# Za�tita Informacija - Enkriptor/Dekriptor sa TCP

Napredna aplikacija za enkriptovanje, dekriptovanje i mre�nu razmenu datoteka sa implementiranim algoritmima TEA, LEA i CRT.

## Funkcionalnosti

### 1. Algoritmi za enkripciju
- **TEA (Tiny Encryption Algorithm)** - Brz i jednostavan blok algoritam
- **LEA (Lightweight Encryption Algorithm)** - Lagan algoritam optimizovan za performanse
- **CRT (Chinese Remainder Theorem)** - Matemati?ki pristup enkripciji

### 2. File System Watcher (FSW)
- Automatsko pra?enje Target foldera za nove datoteke
- Automatska enkripcija detektovanih datoteka
- ?uvanje enkriptovanih datoteka u X folder sa prefiksom "encrypted_"
- Real-time status pra?enja

### 3. Ru?na enkripcija/dekripcija
- Manuelno biranje datoteka za enkriptovanje
- Dekriptovanje enkriptovanih datoteka
- Slobodan izbor lokacije za ?uvanje dekriptovanih datoteka

### 4. Mre�na razmena datoteka (TCP)
- **Server mod**: Primanje enkriptovanih datoteka preko TCP-a
- **Klijent mod**: Slanje enkriptovanih datoteka na drugi server
- SHA1 hash verifikacija za integritet datoteka
- Automatska provera hash vrednosti prilikom prijema

### 5. Kriptografska hash verifikacija
- SHA1 algoritam za generisanje hash vrednosti
- Automatska verifikacija integriteta prene�enih datoteka
- Upozorenja u slu?aju neispravnog hash-a

## Kori�?enje

### Pode�avanja
1. Izaberite algoritam enkripcije (TEA, LEA, ili CRT)
2. Postavite Target folder (gde FSW prati nove datoteke)
3. Postavite X folder (gde se ?uvaju enkriptovani datoteke)
4. Unesite klju? za enkripciju (default: "1234567890abcdef")

### File System Watcher
1. Idite na tab "File System Watcher"
2. Kliknite "Pokreni pra?enje"
3. Dodajte datoteke u Target folder
4. Aplikacija ?e automatski enkriptovati nove datoteke

### Ru?na enkripcija
1. Idite na tab "Ru?na enkripcija"
2. Za enkriptovanje: Kliknite "Enkriptuj fajl" i izaberite datoteku
3. Za dekriptovanje: Kliknite "Dekriptuj fajl" i izaberite enkriptovanu datoteku

### Mre�na razmena
1. Idite na tab "Mre�na razmena"
2. **Za primanje**: Unesite port i kliknite "Pokreni" server
3. **Za slanje**: Unesite IP adresu i port odredi�ta, zatim "Po�alji fajl"

## Protokol mre�ne razmene

Aplikacija koristi slede?i protokol za razmenu datoteka:

```
1. String: Ime datoteke
2. Long: Veli?ina datoteke u bajtovima
3. Int: Du�ina SHA1 hash-a (20 bajtova)
4. Byte[]: SHA1 hash enkriptovane datoteke
5. Byte[]: Enkriptovani sadr�aj datoteke
```

## Sigurnosne karakteristike

- Svi podaci se prenose u enkriptovanom obliku
- SHA1 hash verifikacija za integritet datoteka
- Podr�ka za razli?ite algoritme enkripcije
- Bezbedna razmena klju?eva (korisnik je odgovoran za distribuciju klju?a)

## Tehni?ki detalji

- **Framework**: .NET Framework 4.7.2
- **Jezik**: C# 7.3
- **UI**: Windows Forms
- **Mre�a**: TCP soketi
- **Hash algoritam**: SHA1
- **Enkriptovanje**: Implementirani TEA, LEA i CRT algoritmi

## Struktura projekta

```
ZastitaInformacija_18658/
??? Algorithms/
?   ??? TEA.cs          # TEA algoritam
?   ??? LEA.cs          # LEA algoritam
?   ??? CRT.cs          # CRT algoritam
??? Network/
?   ??? FileTransferServer.cs  # TCP server
?   ??? FileTransferClient.cs  # TCP klijent
??? Services/
?   ??? EncryptionManager.cs   # Manager za algoritme
??? Utils/
?   ??? HashUtils.cs           # SHA1 utilities
??? Enums/
?   ??? EncryptionAlgorithm.cs # Enum za algoritme
??? Form1.cs            # Glavna forma
??? Form1.Designer.cs   # UI dizajn
```

## Napomene

- Aplikacija kreira Target i X foldere automatski ako ne postoje
- Default lokacije su Desktop\Target i Desktop\X
- Svi algoritmi su implementirani "od nule" bez kori�?enja spoljnih biblioteka
- Aplikacija podr�ava i slanje i primanje datoteka istovremeno