using UnityEngine;
using System.Collections;

public class MioneerTile : ITilePathNode, ITilePhysics, IGraphics
{
    private int _coordinateX;
    private int _coordinateY;

    public MioneerTile(int coordinateX, int coordinateY)
    {
        _coordinateX = coordinateX;
        _coordinateY = coordinateY;
    }

    public void InitializeSprites(FContainer container)
    {
        FSprite sprite = new FSprite("tiledirt");
        
        container.AddChild(sprite);
    }

    public void GraphicUpdate(FContainer container, WorldCamera worldCamera)
    {
        Vector2 position = new Vector2(_coordinateX, _coordinateY);
        FSprite sprite = container.GetChildAt(0) as FSprite;

        container.SetPosition(worldCamera.GetScreenPosition(position) + sprite.element.sourcePixelSize * 0.5f);
        sprite.color = worldCamera.GetColor(position);
    }
}