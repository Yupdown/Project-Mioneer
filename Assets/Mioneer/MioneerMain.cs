using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MioneerMain : SingleMono <MioneerMain>
{
    private LoopFlowRoot _flowRoot;

    private AudioEngine _audioEngine;

	protected override void Awake()
    {
        base.Awake();

        FutileParams futileParams = new FutileParams(true, true, false, false);
        futileParams.AddResolutionLevel(135f / Screen.height * Screen.width, 1f, 1f, string.Empty);

        Futile.instance.Init(futileParams);

        LoadAtlases();

        _audioEngine = new AudioEngine();

        _flowRoot = new LoopFlowRoot();
        _flowRoot.SwitchFlow(new MioneerGame());
    }

    private void Update()
    {
        _flowRoot.Update(Time.deltaTime);
    }

    private void LoadAtlases()
    {
        const string atlasPath = "Atlases/mioneer";
        Futile.atlasManager.LoadAtlas(atlasPath);
    }
}