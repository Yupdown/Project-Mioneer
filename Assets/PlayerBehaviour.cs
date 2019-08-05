using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform _transform;

    private Animator _animator;

    public void Awake()
    {
        _transform = GetComponent<Transform>();

        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        Vector2 inputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 velocity = inputAxis * 3f;
        
        _transform.Translate(velocity * Time.deltaTime);

        if (!Mathf.Approximately(inputAxis.x, 0f))
            _transform.localScale = new Vector3(inputAxis.x > 0f ? -1f : 1f, 1f, 1f);

        _animator.SetFloat("Velocity X", Mathf.Abs(velocity.x));
    }

    public void Update(float deltaTime)
    {
        
    }
}
