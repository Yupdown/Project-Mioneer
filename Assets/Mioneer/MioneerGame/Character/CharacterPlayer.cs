using UnityEngine;
using System.Collections.Generic;

public class CharacterPlayer : Character, IGraphics
{
    public FAtlasElement[] _elements;

    public override void Update(float deltaTime)
    {
        _worldPosition += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * 2f * deltaTime;

        base.Update(deltaTime);
    }

    public void InitializeSprites(FContainer container)
    {
        List<FAtlasElement> list = new List<FAtlasElement>();

        for (int index = 1; ; index++)
        {
            try
            { list.Add(Futile.atlasManager.GetElementWithName("tommy" + index)); }
            catch
            { break; }
        }

        _elements = list.ToArray();
        container.AddChild(new FSprite(_elements[0]));
    }

    public void GraphicUpdate(FContainer container, WorldCamera worldCamera)
    {
        container.SetPosition(worldCamera.GetScreenPosition(_worldPosition));
        container.sortZ = worldCamera.GetSortZ(_worldPosition);
        (container.GetChildAt(0) as FSprite).element = _elements[(int)Mathf.Repeat(Time.time * 10f, _elements.Length)];
    }
}