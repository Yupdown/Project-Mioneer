using UnityEngine;

public class MioneerTileMap
{
    private MioneerTile[,] _tiles;

    public MioneerTile this[Vector2Int coordinate]
    {
        get
        { return _tiles[coordinate.x, coordinate.y]; }
    }

    public MioneerTile this[int coordinateX, int coordinateY]
    {
        get
        { return _tiles[coordinateX, coordinateY]; }
    }

    public MioneerTileMap()
    {
        _tiles = new MioneerTile[10, 10];

        for (int i = 0; i < 100; i++)
        {
            int coordinateX = i / 10;
            int coordinateY = i % 10;

            _tiles[coordinateX, coordinateY] = new MioneerTile(coordinateX, coordinateY);
        }
    }
}