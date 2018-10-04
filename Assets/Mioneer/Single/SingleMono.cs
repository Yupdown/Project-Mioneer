using UnityEngine;
using System.Collections;

public class SingleMono <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance { get { return _instance; } }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}