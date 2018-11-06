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

    public static AudioSource PlayAudio(AudioClip audioClip, bool loop = false, float volume = 1f, float pitch = 1f, float stereoPan = 0f)
    {
        AudioSource audioSource = instance.GetPooledAudioObject();

        audioSource.gameObject.name = audioClip.name;

        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.panStereo = stereoPan;

        audioSource.Play();

        return audioSource;
    }

    private AudioSource GetPooledAudioObject()
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