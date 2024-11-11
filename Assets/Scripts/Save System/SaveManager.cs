using System.IO;
using UnityEngine;
using Newtonsoft.Json;

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
            
            var serializedData = JsonConvert.SerializeObject(saveProfile, Formatting.Indented, 
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            //encrypt
            if(!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);
            
            File.WriteAllText(saveFolder + "/" + saveProfile.name, serializedData);
        }
    }
}