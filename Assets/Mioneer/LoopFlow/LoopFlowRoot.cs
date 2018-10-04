using UnityEngine;

public class LoopFlowRoot
{
    private LoopFlow _runningFlow;

    public LoopFlowRoot()
    {

    }

    public void Update(float deltaTime)
    {
        _runningFlow.Update(deltaTime);
    }

    public void SwitchFlow(LoopFlow newFlow)
    {
        _runningFlow = newFlow;
    }
}