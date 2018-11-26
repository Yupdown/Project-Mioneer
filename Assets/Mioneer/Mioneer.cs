using UnityEngine;
using UnityEngine.U2D;

public class Mioneer : SingleMono <Mioneer>
{
    private LoopFlowRoot _flowRoot;

    private AudioEngine _audioEngine;

	protected override void Awake()
    {
        base.Awake();

        Vector2 screenSize = new Vector2(135f / Screen.height * Screen.width, 135f);

        FutileParams futileParams = new FutileParams(true, true, false, false);
        futileParams.AddResolutionLevel(screenSize.x, 1f, 1f, string.Empty);

        Futile.instance.Init(futileParams);

        LoadAtlases();
        InitializeCamera(Camera.main, screenSize);

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

    private void InitializeCamera(Camera camera, Vector2 screenSize)
    {
        PixelPerfectCamera pixelPerfect = camera.gameObject.AddComponent<PixelPerfectCamera>();

        pixelPerfect.refResolutionX = (int)screenSize.x;
        pixelPerfect.refResolutionY = (int)screenSize.y;
        pixelPerfect.assetsPPU = 1;
        pixelPerfect.upscaleRT = true;
    }
}