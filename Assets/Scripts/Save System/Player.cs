using System;
using UnityEngine;

namespace SaveLoad.Runtime
{
    public class Player : MonoBehaviour
    {
        const string PLAYERPROFILENAME = "Player1";
        

        void Start()
        {
            Debug.Log(Application.persistentDataPath);

            SaveManager.Delete(PLAYERPROFILENAME);
            
            var playerSave = new PlayerSaveData{position = transform.position, achievements = new []{1,2,3,4,5,6,7,8,9}};
            
            var saveProfile = new SaveProfile<PlayerSaveData>(PLAYERPROFILENAME, playerSave);
            
            SaveManager.Save(saveProfile);
        }

        private void Update()
        {
            //Load save profile
            if (Input.GetKeyDown(KeyCode.E))
            {
                var pos = SaveManager.Load<PlayerSaveData>(PLAYERPROFILENAME).saveData.position;
                transform.position = pos;
            }

            //Overwrite save profile
            if(Input.GetKeyDown(KeyCode.S))
            {
                SaveManager.Delete(PLAYERPROFILENAME);

                var playerSave = new PlayerSaveData{position = transform.position, achievements = new []{1,2,3,4,5,6,7,8,9,10}};
                
                var saveProfile = new SaveProfile<PlayerSaveData>(PLAYERPROFILENAME, playerSave);
                
                SaveManager.Save(saveProfile);
            }
        }
    }
}