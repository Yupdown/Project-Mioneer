using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioEngine : Single <AudioEngine>
{
    private List<AudioSource> _pooledAudios;
    private Transform _pooledObjectsOwner;

    public AudioEngine() : base()
    {
        _pooledAudios = new List<AudioSource>();
        _pooledObjectsOwner = new GameObject("Sound Objects").GetComponent<Transform>();
    }

    public static AudioSource PlayAudio(AudioClip clip, bool loop = false, float volume = 1f, float pitch = 1f, float stereoPan = 0f)
    {
        AudioSource audioSource = instance.GetAudioObject();

        audioSource.gameObject.name = clip.name;

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.panStereo = stereoPan;

        audioSource.Play();

        return audioSource;
    }

    private AudioSource GetAudioObject()
    {
        foreach (var pooledAudio in _pooledAudios)
        {
            if (pooledAudio.isPlaying == false)
                return pooledAudio;
        }

        GameObject audioObject = new GameObject();
        audioObject.transform.parent = _pooledObjectsOwner;

        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        _pooledAudios.Add(audioSource);

        return audioSource;
    }
}