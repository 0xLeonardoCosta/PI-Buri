using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TesteMovimentoPersonagem : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _playerVelocity;
    private Vector3 _movement;

    [SerializeField] Animator _anim;
    [SerializeField] Rigidbody _rb;
    [SerializeField] CharacterController _controller;

    [SerializeField] float _gravityValue = -9.81f;
    [SerializeField] float _speed = 5;
    [SerializeField] float _jump = 5;


    [SerializeField] bool _isGrounded;
    bool _checkPulo;

    float timer;
    public float timerValue;
    public float _var;


    private void Awake()
    {
        timer = timerValue;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
        AndarN();
    }
    void Update()
    {
        _isGrounded = _controller.isGrounded;
        Move();
        LookAtMovementDirection();
        Pulo();
        Gravity();
        CheckPulo();
    }
    void AndarN()//andando normal
    {
        //_anim.SetLayerWeight(0, 1); //perna
        //_anim.SetLayerWeight(1, 1); //braco
    }
    void Move()
    {
        _movement = new Vector3(_input.x, 0f, _input.y) * _speed * Time.deltaTime;
        _controller.Move(_movement);

        //_speedY = _moveDirection.y;
        //_speedAnim = _moveV;
        //_anim.SetFloat("Andar", _speedAnim);
        //_anim.SetFloat("VelocidadeY", _controller.velocity.y);
        //_anim.SetBool("groundCheck", _isGrounded);
    }
    public void SetMove(InputAction.CallbackContext value)
    {
        _input = value.ReadValue<Vector2>();
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
    void Pulo()
    {
        if (_checkPulo && _isGrounded)
        {
            _checkPulo = false;
            _playerVelocity.y = Mathf.Sqrt(0);
            _playerVelocity.y = Mathf.Sqrt(_jump * -3.0f * _gravityValue);
            Debug.Log("Pular " + _playerVelocity.y);

            //_anim.SetFloat("VelocidadeY", _rb.velocity.y);
        }
    }
    public void SetPular(InputAction.CallbackContext value)
    {       
        _checkPulo = true;
    }
    void CheckPulo()
    {
        if (_checkPulo)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                _checkPulo = false;
                timer = timerValue;
            }
        }
    }
    void Gravity()
    {
        if (_isGrounded == false)
        {
            _playerVelocity.y += _var + _gravityValue + Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }
    }
}
