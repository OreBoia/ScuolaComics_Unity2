using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public void ReproduceAudio(string clipName)
    {
        AudioSourceManager.Instance.ReproduceSFXAudioSource(clipName);
    }
}