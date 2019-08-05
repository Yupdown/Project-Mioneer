using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTarget;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        SetTarget(_cameraTarget, true);
    }

    private void Update()
    {
        _transform.localPosition = Vector3.Lerp(_transform.localPosition, GetCameraTargetPosition(_cameraTarget.position), Time.deltaTime * 5f);
    }

    public void SetTarget(Transform target, bool fix = false)
    {
        _cameraTarget = target;

        if (fix)
            _transform.localPosition = GetCameraTargetPosition(_cameraTarget.position);
    }

    private Vector3 GetCameraTargetPosition(Vector3 targetPosition)
    {
        targetPosition.z = _transform.localPosition.z;

        return targetPosition;
    }
}