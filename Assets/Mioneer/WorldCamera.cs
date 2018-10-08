using UnityEngine;
using System.Collections.Generic;

public class WorldCamera : IUpdatable
{
    private Vector2 _worldPosition;

    private LinkedList<CameraDisplay> _displays;

    public WorldCamera()
    {
        _displays = new LinkedList<CameraDisplay>();
    }

    public void Update(float deltaTime)
    {

    }

    public void AddDisplay(IDisplay display)
    {
        CameraDisplay newDisplay = new CameraDisplay(this);

        _displays.AddLast(newDisplay);
    }
}

public class CameraDisplay
{
    private WorldCamera _worldCamera;

    private IDisplay _display;
    private FContainer _container;

    public CameraDisplay(WorldCamera worldCamera)
    {
        _worldCamera = worldCamera;

        _container = new FContainer();
    }
}