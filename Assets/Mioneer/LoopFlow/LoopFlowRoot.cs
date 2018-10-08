using UnityEngine;

public class LoopFlowRoot : IUpdatable
{
    private LoopFlow _runningFlow;

    public void Update(float deltaTime)
    {
        _runningFlow.Update(deltaTime);
    }

    public void SwitchFlow(LoopFlow newFlow)
    {
        if (_runningFlow != null)
            _runningFlow.OnEnable();

        _runningFlow = newFlow;
        newFlow.OnEnable();
    }
}