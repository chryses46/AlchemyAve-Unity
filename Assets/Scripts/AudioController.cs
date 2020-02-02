using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    AudioSource audioSource;

    [SerializeField] AudioClip mainMenuMusic;
    [SerializeField] AudioClip shopMusic;

    public static AudioController instance;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayMainMenuMusic()
    {
        if(audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = mainMenuMusic;
        audioSource.Play();
    }

    public void PlayShopMusic()
    {
        if(audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = shopMusic;
        audioSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
