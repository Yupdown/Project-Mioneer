using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioEngine : Single <AudioEngine>
{
    public float SoundVolume
    {
        get
        { return soundVolume; }
        set
        {
            soundVolume = value;

            foreach (AudioSource audioSource in pooledAudios)
            {
                if (audioSource != musicAudioSource || !IsMusicPlaying)
                    audioSource.volume = value;
            }
        }
    }
    private float soundVolume;

    public float MusicVolume
    {
        get
        { return musicVolume; }
        set
        {
            musicVolume = value;

            if (IsMusicPlaying)
                musicAudioSource.volume = value;
        }
    }
    private float musicVolume;

    public bool IsMusicPlaying
    {
        get
        {
            if (musicAudioSource != null)
                return musicAudioSource.isPlaying;

            return false;
        }
    }

    private AudioSource musicAudioSource;

    private List<AudioSource> pooledAudios;
    private Transform pooledObjectsowner;

    public AudioEngine() : base()
    {
        pooledAudios = new List<AudioSource>();
        pooledObjectsowner = new GameObject("Sound Objects").GetComponent<Transform>();
    }

    public static AudioSource PlaySound(AudioClip clip, bool loop = false, float volume = 1f, float pitch = 1f, float stereoPan = 0f)
    {
        AudioSource audioSource = Instance.GetAudioObject();

        audioSource.gameObject.name = clip.name;

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.panStereo = stereoPan;

        audioSource.Play();

        return audioSource;
    }

    public static AudioSource PlayMusic(AudioClip clip, bool loop = true)
    {
        bool playMusic = true;
        if (Instance.IsMusicPlaying)
            playMusic = clip != Instance.musicAudioSource.clip;

        if (playMusic)
        {
            Instance.musicAudioSource = PlaySound(clip, loop);
            return Instance.musicAudioSource;
        }

        else
            return null;
    }

    private AudioSource GetAudioObject()
    {
        foreach (var pooledAudio in pooledAudios)
        {
            if (pooledAudio.isPlaying == false)
                return pooledAudio;
        }

        GameObject audioObject = new GameObject();
        audioObject.transform.parent = pooledObjectsowner;

        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        pooledAudios.Add(audioSource);

        return audioSource;
    }
}