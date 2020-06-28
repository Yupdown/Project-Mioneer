using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScaler : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;

    [SerializeField]
    private float cameraSizeMin;
    [SerializeField]
    private float cameraSizeMax;

    [SerializeField]
    private int levelSteps;

    private int currentLevel;

    [SerializeField]
    private Slider levelSlider;

    private void Start()
    {
        SetLevel(0);
    }

    public void ZoomIn()
    {
        if (currentLevel > 0)
            SetLevel(currentLevel - 1);
    }

    public void ZoomOut()
    {
        if (currentLevel < levelSteps)
            SetLevel(currentLevel + 1);
    }

    public void SetLevel(int level)
    {
        float factor = (float)level / (levelSteps - 1);

        SetFactor(factor);
        levelSlider.value = factor;
    }

    public void SetFactor(float factor)
    {
        currentLevel = (int)(factor * (levelSteps - 1));
        targetCamera.orthographicSize = Mathf.Lerp(cameraSizeMin, cameraSizeMax, factor);
    }
}
