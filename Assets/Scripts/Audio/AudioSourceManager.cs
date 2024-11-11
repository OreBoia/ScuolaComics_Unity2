using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {        
        // Ottenere il componente AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();

        // Riprodurre l'audio
        // devi assegnare la clip all'AudioSource
        // utile per le colonne sonoree o audio lunghi
        audioSource.clip = audioClip;
        audioSource.Play();

        // normalmente l'audio source può riprodurre solo una clip per volta 
        // PlayOneShot permette di poter riprodurre un clip una volta
        // utile per fare effetti
        audioSource.PlayOneShot(audioClip);

        // Mettere in pausa l'audio
        audioSource.Pause();

        // Interrompere l'audio
        audioSource.Stop();

        // Modificare il volume
        audioSource.volume = 0.5f;

        // Cambiare il pitch
        audioSource.pitch = 1.2f;

        // Controllare se l'audio sta riproducendo
        if (audioSource.isPlaying)
        {
            // Fare qualcosa
        }
    }

    [SerializeField] private AudioMixer mixer;
    public void TransitionToSnapshot(string snapshotName, float transitionTime)
    {
        AudioMixerSnapshot snapshot = mixer.FindSnapshot(snapshotName);
        snapshot.TransitionTo(transitionTime);
    }
}

