using UnityEngine;
using System.Collections;

public class TileMapPathfinder
{
    private readonly ITilePathNode[,] _pathNodes;

    public TileMapPathfinder(ITilePathNode[,] pathNodes)
    {
        _pathNodes = pathNodes;
    }
}
