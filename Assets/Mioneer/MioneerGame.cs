using UnityEngine;
using System.Collections;

public class MioneerGame : LoopFlow, IUpdatable
{
    private MioneerWorld _world;

    public MioneerGame()
    {
        _world = new MioneerWorld();
    }

    public override void Update(float deltaTime)
    {
        _world.Update(deltaTime);

        base.Update(deltaTime);
    }
}
