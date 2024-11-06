using System;
using UnityEngine;

namespace SaveLoad.Runtime
{
    [Serializable]
    public sealed class SaveProfile<T> where T : SaveProfileData
    {
        public string name;
        public T saveData;

        private SaveProfile()
        {
            
        }
        
        public SaveProfile(string name, T saveData)
        {
            this.name = name;
            this.saveData = saveData;
        }
    }
    
    public abstract record SaveProfileData {}

    public record PlayerSaveData : SaveProfileData
    {
        public Vector2 position;
        public int[] achievements;
    }
    
    public record WorldSaveData : SaveProfileData
    {
        public int[,] blocks;
    }
}