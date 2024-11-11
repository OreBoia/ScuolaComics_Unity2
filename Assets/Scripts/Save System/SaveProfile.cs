using System;
using UnityEngine;

namespace SaveLoad.Runtime
{
    //Quando una classe o un metodo è dichiarato come "sealed", 
    //significa che non può essere ereditato o sovrascritto da altre classi
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
    
    //Immutabili
    //utili per rappresentare oggetti semplici e immutabili, come i dati di un'entità in un database
    public abstract record SaveProfileData {}

    public record PlayerSaveData : SaveProfileData
    {
        public Vector3 position;
        public int[] achievements;
    }
    
    public record WorldSaveData : SaveProfileData
    {
        public int[,] blocks;
    }

    public record PlayerStatsData : SaveProfileData
    {
        public int health;
        public int damage;
        public int speed;
    }
}