using UnityEngine;
using System.Collections;

public class MioneerWorld : IUpdatable
{
    private MioneerTileMap _tileMap;

    private WorldCamera _worldCamera;

    public MioneerWorld()
    {
        _tileMap = new MioneerTileMap();

        _worldCamera = new WorldCamera();
    }

    public void Update(float deltaTime)
    {
        _worldCamera.Update(deltaTime);
    }
}
