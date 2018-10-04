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

        FSprite sprite = new FSprite("Tile");
        sprite.SetPosition(new Vector2(_coordinateX - 5, _coordinateY - 5) * 16);
        sprite.color = Color.Lerp(Color.white, Color.black, sprite.GetPosition().sqrMagnitude / 6400f);
        Futile.stage.AddChild(sprite);
    }
}