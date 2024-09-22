using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class DialogSO : ScriptableObject
{
    public List<Sentence> sentences;
}

[Serializable]
public class Sentence
{
    public string characterName;

    public Sprite characterSprite;

    [TextArea(3, 10)] public string line;

    public Sentence(string characterName, Sprite characterSprite, string line)
    {
        this.characterName = characterName;
        this.characterSprite = characterSprite;
        this.line = line;
    }

    public void UpdateLine(string newLine)
    {
        this.line = newLine;
    }

    public void UpdateCharacterName(string newCharacterName)
    {
        this.characterName = newCharacterName;
    }
}



