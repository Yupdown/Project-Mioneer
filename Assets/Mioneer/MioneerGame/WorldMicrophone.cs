 using UnityEngine;
using System.Collections;

public class WorldMicrophone : IUpdatable
{
    private Vector3 _microphonePositon;

    public void Update(float deltaTime)
    {

    }

    public void PlaySound(AudioClip audioClip, IPositionable behaviour)
    {
        Vector2 deltaVector = _microphonePositon - behaviour.worldPosition;

        float volume = 1f / deltaVector.sqrMagnitude;
        float pan = deltaVector.normalized.x;

        AudioEngine.PlayAudio(audioClip, false, volume, 1f, pan);
    }
}
