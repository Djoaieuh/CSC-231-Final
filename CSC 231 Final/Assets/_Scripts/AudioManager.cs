using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    AudioSource MusicSource;
    [SerializeField]
    AudioSource SFXSource;

    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    public AudioClip Button;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic(AudioClip background)
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }

    public void PlayGameMusic(AudioClip gameMusic)
    {
        MusicSource.clip = gameMusic;
        MusicSource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
