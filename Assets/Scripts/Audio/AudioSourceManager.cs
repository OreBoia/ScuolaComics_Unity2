using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    // [SerializeField] private AudioClip audioClip;

    [SerializeField] private List<AudioSourceObjectDictionary> _audioSourcePrefabs = new List<AudioSourceObjectDictionary>();
    [SerializeField] private List<AudioSourceObjectDictionary> _audioSourceObjectsInstantiated = new List<AudioSourceObjectDictionary>();    // [SerializeField] private AudioSource[] audioSource;

    [SerializeField] private ClipsCollector _clipsCollector;

    private static AudioSourceManager _instance;
    [SerializeField] private AudioMixer mixer;

    public float TransitionTime;

    public static AudioSourceManager Instance => _instance;

    void Awake()
    {
        _instance = this;

        _audioSourcePrefabs.ForEach((x) => 
            {
                _audioSourceObjectsInstantiated.Add(
                        new AudioSourceObjectDictionary() 
                        {
                            name = x.name, 
                            audioSourcePrefab = Instantiate(x.audioSourcePrefab)
                        });
            });
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SetBackgroundAudioSource();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            // Debug.Log("Transition");
            TransitionToSnapshot("Mute", TransitionTime);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            ReproduceSFXAudioSource("SFX");
        }
    }

    private void SetBackgroundAudioSource()
    {
        if(_audioSourceObjectsInstantiated[0].audioSourcePrefab.TryGetComponent<AudioSource>(out AudioSource source))
        {
            if(source.isPlaying)
            {
                source.Stop();
            }
            else
            {
                source.clip = _clipsCollector.Clips[0].audioClip;
                source.Play();
            }
        }
    }

    public void ReproduceSFXAudioSource(string clipName)
    {
        if(_audioSourceObjectsInstantiated[1].audioSourcePrefab.TryGetComponent<AudioSource>(out AudioSource source))
        {
            if(!source.isPlaying)
                source.PlayOneShot(_clipsCollector.Clips.Where(x => x.groupName == clipName).First().audioClip);
        }
    }

    private void AudioSourceExamples()
    {        
    //     // Riprodurre l'audio
    //     // devi assegnare la clip all'AudioSource
    //     // utile per le colonne sonore o audio lunghi
    //     audioSource[0].clip = audioClip;
    //     audioSource[0].Play();

    //     // normalmente l'audio source può riprodurre solo una clip per volta 
    //     // PlayOneShot permette di poter riprodurre un clip una volta
    //     // utile per fare effetti
    //     audioSource[0].PlayOneShot(audioClip);

    //     // Mettere in pausa l'audio
    //     audioSource[0].Pause();

    //     // Interrompere l'audio
    //     audioSource[0].Stop();

    //     // Modificare il volume
    //     audioSource[0].volume = 0.5f;

    //     // Cambiare il pitch
    //     audioSource[0].pitch = 1.2f;

    //     // Controllare se l'audio sta riproducendo
    //     if (audioSource[0].isPlaying)
    //     {
    //         // Fare qualcosa
    //     }
    // }
    }

    
    public void TransitionToSnapshot(string snapshotName, float transitionTime)
    {
        AudioMixerSnapshot snapshotEnd = mixer.FindSnapshot(snapshotName);
        // AudioMixerSnapshot snapshotStart = mixer.FindSnapshot("Snapshot");
        // Debug.Log("Transitioning to snapshot: " + snapshotEnd);
        // mixer.TransitionToSnapshots(new AudioMixerSnapshot[] { snapshotStart, snapshotEnd }, new float[] { 1f, 1f}, transitionTime);ù
        snapshotEnd.TransitionTo(transitionTime);
    }
}

[Serializable]
public struct AudioSourceObjectDictionary
{
    public string name;
    public GameObject audioSourcePrefab;

}

