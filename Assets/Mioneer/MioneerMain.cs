using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MioneerMain : MonoBehaviour {

    private LoopFlowRoot _flowRoot;

	void Start () {
        FutileParams futileParams = new FutileParams(true, true, false, false);
        futileParams.AddResolutionLevel(135f / Screen.height * Screen.width, 1f, 1f, string.Empty);

        Futile.instance.Init(futileParams);

        const string atlasPath = "Atlases/mioneer";
        Futile.atlasManager.LoadAtlas(atlasPath);

        _flowRoot = new LoopFlowRoot();
        _flowRoot.SwitchFlow(new MioneerGame());
    }

    private void Update()
    {
        _flowRoot.Update(Time.deltaTime);
    }
}