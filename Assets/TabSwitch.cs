using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSwitch : MonoBehaviour
{
    private Transform transformCache;

    [SerializeField]
    private Transform targetTabTransform;
    [SerializeField]
    private Transform cameraTransform;

    private void Awake()
    {
        transformCache = GetComponent<Transform>();
    }

    private void Update()
    {
        transformCache.localPosition = Vector3.Lerp(transformCache.localPosition, -targetTabTransform.localPosition, Time.deltaTime * 8f);

        cameraTransform.localPosition = -transformCache.localPosition * 0.005f;
    }

    public void SwitchTab(Transform tabTransform)
    {
        targetTabTransform = tabTransform;
    }
}
