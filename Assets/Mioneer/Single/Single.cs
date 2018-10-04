using UnityEngine;

public class Single <T> where T : class
{
    private static T _instance = null;
    public static T instance { get { return _instance; } }

    protected Single()
    {
        _instance = this as T;
    }
}
