using System;
using UnityEngine;

namespace SaveLoad.Runtime
{
    public class Player : MonoBehaviour
    {
        const string PLAYER_PROFILE_NAME = "Player1";
        

        void Start()
        {
            Debug.Log(Application.persistentDataPath);

            SaveManager.Delete(PLAYER_PROFILE_NAME);
            
            var playerSave = new PlayerSaveData{position = transform.position, achievements = new []{1,2,3,4,5,6,7,8,9}};
            
            var saveProfile = new SaveProfile<PlayerSaveData>(PLAYER_PROFILE_NAME, playerSave);
            
            // SaveManager.Save(saveProfile);
            EncryptedSaveSystem.SaveData(saveProfile);
        }

        private void Update()
        {
            //Load save profile
            if (Input.GetKeyDown(KeyCode.E))
            {
                var pos = EncryptedSaveSystem.LoadData<PlayerSaveData>(PLAYER_PROFILE_NAME).saveData.position;
                transform.position = pos;
            }

            //Overwrite save profile
            if(Input.GetKeyDown(KeyCode.S))
            {
                SaveManager.Delete(PLAYER_PROFILE_NAME);

                var playerSave = new PlayerSaveData{position = transform.position, achievements = new []{1,2,3,4,5,6,7,8,9,10}};
                
                var saveProfile = new SaveProfile<PlayerSaveData>(PLAYER_PROFILE_NAME, playerSave);
                
                EncryptedSaveSystem.SaveData(saveProfile);
            }
        }
    }
}