using UnityEngine;
using System.Collections.Generic;

public class WorldCamera : IUpdatable
{
    public const int PixelsPerTile = 24;

    private Vector3 _cameraPosition;
    private IPositionable _cameraTarget;

    private LinkedList<CameraGraphics> _graphics;

    private FContainer _container;

    public WorldCamera()
    {
        _graphics = new LinkedList<CameraGraphics>();

        _container = new FContainer();
        _container.shouldSortByZ = true;

        Futile.stage.AddChild(_container);
    }

    public void Update(float deltaTime)
    {
        _cameraPosition = Vector3.Lerp(_cameraPosition, _cameraTarget.worldPosition, deltaTime * 5f);

        foreach (CameraGraphics display in _graphics)
            display.GraphicUpdate(this);
    }

    public void SetCameraTarget(IPositionable cameraTarget, bool holdTarget)
    {
        _cameraTarget = cameraTarget;

        if (holdTarget)
            _cameraPosition = cameraTarget.worldPosition;
    }

    public Vector2 GetScreenPosition(Vector3 worldPosition)
    {
        return (worldPosition - _cameraPosition) * PixelsPerTile;
    }

    public Color GetColor(Vector3 worldPosition)
    {
        return Color.Lerp(Color.white, Color.black, (worldPosition - _cameraPosition).sqrMagnitude / 32f);
    }

    public float GetSortZ(Vector3 worldPosition)
    {
        return worldPosition.y;
    }

    public void AddGraphics(IGraphics graphics)
    {
        CameraGraphics newDisplay = new CameraGraphics(graphics, this);

        _graphics.AddLast(newDisplay);
    }

    public void AddChild(FNode node)
    {
        _container.AddChild(node);
    }
}

public class CameraGraphics
{
    private IGraphics _graphics;
    private FContainer _container;

    public CameraGraphics(IGraphics graphics, WorldCamera worldCamera)
    {
        _graphics = graphics;
        _container = new FContainer();

        worldCamera.AddChild(_container);
        _graphics.InitializeSprites(_container);
    }

    public void GraphicUpdate(WorldCamera worldCamera)
    {
        _graphics.GraphicUpdate(_container, worldCamera);
    }
}