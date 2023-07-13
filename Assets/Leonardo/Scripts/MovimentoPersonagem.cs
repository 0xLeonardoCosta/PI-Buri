using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimentoPersonagem : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _playerVelocity;
    private Vector3 _moveDirection;

    [SerializeField] Animator _anim;
    [SerializeField] Rigidbody _rb;
    [SerializeField] CharacterController _controller;

    [SerializeField] float _gravityValue = -9.81f;
    [SerializeField] float _speed = 5;
    [SerializeField] float _jump = 5;

    [SerializeField] bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
        AndarN();
    }
    void Update()
    {
        GatherInput();
        Move();
        LookAtMovementDirection();
        Gravity();
        jump();
    }
    private void GatherInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        _input.Normalize();
    }
    void AndarN()//andando normal
    {
        _anim.SetLayerWeight(0, 1); //perna
        _anim.SetLayerWeight(1, 1); //braco
    }
    void Move()
    {
        Vector3 movement = new Vector3(_input.x, 0f, _input.y).normalized * _speed * Time.deltaTime;
        _controller.Move(movement);

        //_speedY = _moveDirection.y;
        //_speedAnim = _moveV;
        //_anim.SetFloat("Andar", _speedAnim);
        //_anim.SetFloat("VelocidadeY", _controller.velocity.y);
        //_anim.SetBool("groundCheck", _isGrounded);
    }
    void LookAtMovementDirection()
    {
        if (_input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = targetRotation;
        }
    }
    void jump()
    {
        _isGrounded = _controller.isGrounded;
        if (Input.GetAxisRaw("Jump") > 0 && _isGrounded == true)
        {
            Debug.Log(_moveDirection.y);
            _moveDirection.y += Mathf.Sqrt(_jump * -3.0f * _gravityValue);
        }
        //_anim.SetFloat("VelocidadeY", _rb.velocity.y);
    }
    void Gravity()
    {
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}
