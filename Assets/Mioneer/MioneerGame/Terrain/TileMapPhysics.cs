using UnityEngine;
using System.Collections;

public class TileMapPhysics
{
    private readonly ITilePhysics[,] _tiles;

    public TileMapPhysics(ITilePhysics[,] tiles)
    {
        _tiles = tiles;
    }
}
