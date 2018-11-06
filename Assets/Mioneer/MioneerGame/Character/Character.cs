using UnityEngine;

public class Character : IPositionable, IUpdatable
{
    protected Vector3 _worldPosition;

    public Vector3 worldPosition
    {
        get
        { return _worldPosition; }
    }

    public virtual void Update(float deltaTime)
    {

    }
}
