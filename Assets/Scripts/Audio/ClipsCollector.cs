using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClipsCollector", menuName = "Audio/ClipsCollector")]
public class ClipsCollector : ScriptableObject
{
    public List<Clip> Clips;
}

[Serializable]
public struct Clip
{
    public string groupName;
    public AudioClip audioClip;
}
