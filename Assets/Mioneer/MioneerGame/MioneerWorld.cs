using UnityEngine;
using System.Collections;

public class MioneerWorld : IUpdatable
{
    private MioneerTileMap _tileMap;

    private WorldCamera _worldCamera;

    private CharacterPlayer _player;

    public WorldCamera worldCamera
    {
        get
        { return _worldCamera; }
    }

    public MioneerWorld()
    {
        _tileMap = new MioneerTileMap(this);
        _player = new CharacterPlayer();

        _worldCamera = new WorldCamera();
        _worldCamera.SetCameraTarget(_player, false);

        _tileMap.ShowUpByCamera(_worldCamera);
        _worldCamera.AddGraphics(_player);
    }

    public void Update(float deltaTime)
    {
        _player.Update(deltaTime);

        _worldCamera.Update(deltaTime);
    }
}
