using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    public static AudioController instance;

    AudioSource audioSource;

    [SerializeField] AudioClip mainMenuMusic;
    public AudioClip shopBell;
    public AudioClip[] ingredientPlopSFX;

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

    public void PlaySoundEffect(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayIngredientEffect()
    {
        int effect = Random.Range(0,3);

        audioSource.PlayOneShot(ingredientPlopSFX[effect]);
    }
}
