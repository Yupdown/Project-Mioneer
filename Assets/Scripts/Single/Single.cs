using UnityEngine;

public class Single <T> where T : class
{
    private static T instance = null;
    public static T Instance { get { return instance; } }

    protected Single()
    {
        instance = this as T;
    }
}
