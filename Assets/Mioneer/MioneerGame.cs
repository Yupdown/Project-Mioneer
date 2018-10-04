using UnityEngine;
using System.Collections;

public class MioneerGame : LoopFlow
{
    private MioneerTileMap _tileMap;

    public MioneerGame()
    {
        _tileMap = new MioneerTileMap();
    }

    public override void Update(float deltaTime)
    {
        // TODO

        base.Update(deltaTime);
    }
}
