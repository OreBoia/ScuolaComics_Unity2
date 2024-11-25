using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System;
using System.Text;

namespace SaveLoad.Runtime
{
    public static class SaveManager
    {
        private static readonly string saveFolder = Application.persistentDataPath + "/SaveData";

        public static void Delete(string profileName)
        {
            if (!File.Exists(saveFolder + "/" + profileName))
            {
                Debug.LogError("Profile not found: " + profileName);
            }

            Debug.Log("Deleting profile: " + profileName);
            File.Delete(saveFolder + "/" + profileName);
        }
        
        public static SaveProfile<T> Load<T>(string profileName) where T : SaveProfileData
        {
            if (!File.Exists(saveFolder + "/" + profileName))
            {
                throw new FileNotFoundException("Profile not found: " + profileName);
            }
            
            var fileContents = File.ReadAllText(saveFolder + "/" + profileName);
            //decrypt
            Debug.Log(fileContents);
            return JsonConvert.DeserializeObject<SaveProfile<T>>(fileContents);
        }
        
        public static void Save<T>(SaveProfile<T> saveProfile) where T : SaveProfileData
        {
            if (File.Exists(saveFolder + "/" + saveProfile.name))
            {
                throw new FileNotFoundException("Profile already exists: " + saveProfile.name);
            }

            /*
            La proprietà ReferenceLoopHandling specifica come gestire i riferimenti circolari durante la serializzazione. 
            Un riferimento circolare si verifica quando un oggetto contiene un riferimento a un altro oggetto che, a sua volta, contiene un riferimento all'oggetto originale.
            */
            var serializedData = JsonConvert.SerializeObject(saveProfile, Formatting.Indented, 
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            //encrypt
            if(!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);
            
            File.WriteAllText(saveFolder + "/" + saveProfile.name, serializedData);
        }
    }


    public static class EncryptedSaveSystem
    {
        private static readonly string saveFolder = Application.persistentDataPath + "/SaveData";
        // Chiave e IV devono essere della lunghezza corretta per AES (32 bytes per chiave, 16 bytes per IV).
        private static readonly byte[] key = Encoding.UTF8.GetBytes("QuestoÈUnEsempioDiChiaveLunga32"); // 32 caratteri
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("QuestoIV16Bytes!"); // 16 caratteri

        

        // Metodo per salvare i dati in formato criptato
        public static void SaveData<T>(SaveProfile<T> data) where T  : SaveProfileData
        {
            // Serializza i dati in JSON
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            
            // Cripta i dati JSON
            string encryptedData = EncryptString(jsonData);
            
            // Salva i dati criptati nel file
            File.WriteAllText(saveFolder + "/" + data.name, encryptedData);
        }

        // Metodo per caricare e decriptare i dati
        public static SaveProfile<T> LoadData<T>(string profileName) where T : SaveProfileData
        {
            if (!File.Exists(saveFolder + "/" + profileName)) throw new FileNotFoundException("File di salvataggio non trovato.");

            // Legge i dati criptati dal file
            string encryptedData = File.ReadAllText(saveFolder + "/" + profileName);
            
            // Decripta i dati
            string decryptedData = DecryptString(encryptedData);
            
            // Deserializza i dati JSON in un oggetto
            return JsonConvert.DeserializeObject<SaveProfile<T>>(decryptedData);
        }

        // Metodo per criptare una stringa usando AES
        private static string EncryptString(string plainText)
        {
            Debug.Log(key.Length);
            Debug.Log(iv.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // Metodo per decriptare una stringa usando AES
        private static string DecryptString(string encryptedText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

}