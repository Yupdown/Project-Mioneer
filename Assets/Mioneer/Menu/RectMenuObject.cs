using UnityEngine;
using System.Collections.Generic;

public class RectMenuObject : MenuObject, FSingleTouchableInterface
{
    private Vector2 _size;
    //김도엽김도엽김도엽김도엽김도엽김도엽
    public int touchPriority
    {
        get
        { return default(int); }
    }

    public bool HandleSingleTouchBegan(FTouch touch)
    {
        throw new System.NotImplementedException();
    }

    public void HandleSingleTouchCanceled(FTouch touch)
    {
        throw new System.NotImplementedException();
    }

    public void HandleSingleTouchEnded(FTouch touch)
    {
        throw new System.NotImplementedException();
    }

    public void HandleSingleTouchMoved(FTouch touch)
    {
        throw new System.NotImplementedException();
    }
}