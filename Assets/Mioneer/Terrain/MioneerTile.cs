using UnityEngine;
using System.Collections;

public class MioneerTile : ITilePathNode, ITilePhysics
{
    private int _coordinateX;
    private int _coordinateY;

    public MioneerTile(int coordinateX, int coordinateY)
    {
        _coordinateX = coordinateX;
        _coordinateY = coordinateY;

        FSprite sprite = new FSprite("tiledirt");
        sprite.SetPosition(new Vector2(_coordinateX - 4.5f, _coordinateY - 4.5f) * 16);
        sprite.color = Color.Lerp(Color.white, Color.black, sprite.GetPosition().sqrMagnitude / 6400f);
        Futile.stage.AddChild(sprite);
    }
}