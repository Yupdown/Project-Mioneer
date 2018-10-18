 using UnityEngine;
using System.Collections;

public class WorldMicrophone : IUpdatable
{
    private Vector2 _microphonePositon;

    public void Update(float deltaTime)
    {

    }

    public void PlaySound(AudioClip clip, Vector2 worldPosition)
    {
        Vector2 deltaVector = _microphonePositon - worldPosition;

        float volume = 1f / deltaVector.sqrMagnitude;
        float pan = deltaVector.normalized.x;

        AudioEngine.PlayAudio(clip, false, volume, 1f, pan);
    }
}
