using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPTmovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _input;

    private Animator _animator;
    private Rigidbody _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GatherInput();
        Move();
        LookAtMovementDirection();
    }

    private void GatherInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        _input.Normalize();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_input.x, 0f, _input.y) * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + movement);
    }

    private void LookAtMovementDirection()
    {
        if (_input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = targetRotation;
        }
    }
}
