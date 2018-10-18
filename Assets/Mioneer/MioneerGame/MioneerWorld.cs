using UnityEngine;
using System.Collections;

public class MioneerWorld : IUpdatable
{
    private MioneerTileMap _tileMap;

    private WorldCamera _worldCamera;

    public WorldCamera worldCamera
    {
        get
        { return _worldCamera; }
    }

    public MioneerWorld()
    {
        _tileMap = new MioneerTileMap(this);

        _worldCamera = new WorldCamera();
        _tileMap.ShowUpByCamera(_worldCamera);
    }

    public void Update(float deltaTime)
    {
        _worldCamera.Update(deltaTime);
    }
}
