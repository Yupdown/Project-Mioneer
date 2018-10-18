using UnityEngine;
using System.Collections.Generic;

public class WorldCamera : IUpdatable
{
    public const int PixelsPerTile = 16;

    private Vector2 _cameraPosition;

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
        _cameraPosition += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 8f * Time.deltaTime;

        foreach (CameraGraphics display in _graphics)
            display.GraphicUpdate(this);
    }

    public Vector2 GetScreenPosition(Vector2 worldPosition)
    {
        return (worldPosition - _cameraPosition) * PixelsPerTile;
    }

    public Color GetColor(Vector2 worldPosition)
    {
        return Color.Lerp(Color.white, Color.black, (worldPosition - _cameraPosition).sqrMagnitude / 64f);
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