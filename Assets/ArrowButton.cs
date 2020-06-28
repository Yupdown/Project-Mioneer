using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Vector2 moveDirection;

    private bool isPointerEnter;

    [SerializeField]
    private MoveEvent OnButtonClicking;

    [SerializeField]
    private Image imageCache;

    private void Awake()
    {
        imageCache = GetComponent<Image>();
    }

    private void Update()
    {
        bool isClicking = isPointerEnter && Input.GetMouseButton(0);

        if (isClicking)
            OnButtonClicking.Invoke(moveDirection);
        imageCache.color = Color.Lerp(imageCache.color, isClicking ? Color.white : Color.white * 0.3f, Time.deltaTime * 8f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerEnter = false;
    }

    [System.Serializable]
    private class MoveEvent : UnityEvent<Vector2> { }
}
