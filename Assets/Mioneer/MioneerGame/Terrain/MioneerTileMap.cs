using UnityEngine;

public class MioneerTileMap
{
    public int MapWidth = 64;

    private MioneerTile[,] _tiles;

    private TileMapPhysics _tilePhysics;
    private TileMapPathfinder _tilePathfinder;

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

    public MioneerTileMap(MioneerWorld world)
    {
        _tiles = new MioneerTile[MapWidth, 8];

        for (int i = 0; i < 512; i++)
        {
            int coordinateX = i % MapWidth;
            int coordinateY = i / MapWidth;
            
            if (Mathf.PerlinNoise(coordinateX * 0.2f, coordinateY * 0.2f) > 0.5f)
                continue;

            MioneerTile tile = new MioneerTile(coordinateX, coordinateY);

            _tiles[coordinateX, coordinateY] = tile;
        }

        _tilePhysics = new TileMapPhysics(_tiles);
        _tilePathfinder = new TileMapPathfinder(_tiles);
    }

    public void ShowUpByCamera(WorldCamera worldCamera)
    {
        foreach (MioneerTile tile in _tiles)
        {
            if (tile != null)
                worldCamera.AddGraphics(tile);
        }
    }
}