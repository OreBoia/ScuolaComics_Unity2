using System;
using UnityEngine;

namespace SaveLoad.Runtime
{
    public class Player : MonoBehaviour
    {
        void Start()
        {
            Debug.Log(Application.persistentDataPath);
            var playerSave = new PlayerSaveData{position = transform.position, achievements = new []{1,2,3,4,5,6,7,8,9}};
            var saveProfile = new SaveProfile<PlayerSaveData>("Player1", playerSave);
            SaveManager.Save(saveProfile);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(SaveManager.Load<PlayerSaveData>("Player1").saveData.position);
            }
        }
    }
}