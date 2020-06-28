using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private CanvasGroup joystickGroup;

    [SerializeField]
    private RectTransform joystickTransform;

    [SerializeField]
    private RectTransform joystickHeadTransform;

    private Vector2 beginPosition;

    [SerializeField]
    private JoystickEvent eventJoystickDrag;

    private float endDragTime;

    private Vector2? joystickValue;

    private Canvas canvasCache;

    private void Awake()
    {
        canvasCache = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        joystickValue = null;

        joystickGroup.alpha = 0f;
    }

    private void Update()
    {
        if (joystickValue.HasValue)
            eventJoystickDrag.Invoke(joystickValue.Value);
        else
        {
            float t = Mathf.Clamp01((Time.time - endDragTime) * 4f);
            joystickGroup.alpha = 1f - t;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystickGroup.alpha = 1f;

        beginPosition = eventData.position / canvasCache.scaleFactor;
        joystickValue = Vector2.zero;

        joystickTransform.anchoredPosition = beginPosition;
        joystickHeadTransform.anchoredPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 deltaVector = eventData.position / canvasCache.scaleFactor - beginPosition;
        deltaVector = deltaVector.normalized * Mathf.Min(Mathf.Pow(deltaVector.magnitude, 0.75f), 100f);

        joystickValue = deltaVector * 0.01f;

        joystickHeadTransform.anchoredPosition = deltaVector;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystickValue = null;

        endDragTime = Time.time;
    }

    [System.Serializable]
    public class JoystickEvent : UnityEvent<Vector2> { }
}