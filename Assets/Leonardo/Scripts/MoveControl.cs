using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    private Vector2 _input; //Input system, axis: X,Z. 
    private Vector3 _playerVelocity;
    private Vector3 _movement;

    private CharacterController _controller;
    private Animator _anim;

    private bool _inputPulo; //Input de pulo
    [SerializeField] bool _checkGround; //Verificador se o player está encostando no chão

    [SerializeField] float _gravityValue = -9.81f;
    [SerializeField] float _speed = 5;
    [SerializeField] float _jump = 5;
    [SerializeField] float _timer;
    private float _timerValue;

    void Start()
    {
        _timer = _timerValue;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        AndarN();
    }

    void Update()
    {
        _checkGround = _controller.isGrounded; // VERIFICAR NECESSIDADE DESSA LINHA
        Debug.Log(_checkGround);
        Move();
        LookAtMovementDirection();
        Pulo();
        Gravity();
        CheckPulo();
    }
    void AndarN()// Sincronizar animações - Andar movimento de perna/Andar movimento de braço
    {
        //_anim.SetLayerWeight(0, 1); //perna
        //_anim.SetLayerWeight(1, 1); //braco
    }
    void Move()
    {
        _movement = new Vector3(_input.x, 0f, _input.y) * _speed * Time.deltaTime;
        _controller.Move(_movement);
        // Linhas abaixo feitas para animação do personagem
        //_speedY = _moveDirection.y;
        //_speedAnim = _moveV;
        //_anim.SetFloat("Andar", _speedAnim);
        //_anim.SetFloat("VelocidadeY", _controller.velocity.y);
        //_anim.SetBool("groundCheck", _checkGround);
    }
    void LookAtMovementDirection() //Script para virar a frente do personagem voltada a orientação do movimento
    {
        if (_input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = targetRotation;
        }
    }
    void CheckPulo()
    {
        if (_inputPulo==true)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _inputPulo = false;
                _timer = _timerValue;
            }
        }
    }
    void Pulo()
    {
        if (_inputPulo == true && _checkGround == true)
        {
            _inputPulo = false;
            _playerVelocity.y = Mathf.Sqrt(0);
            _playerVelocity.y = Mathf.Sqrt(_jump * -3.0f * _gravityValue);
            //Debug.Log("Pular " + _playerVelocity.y);
            //_anim.SetFloat("VelocidadeY", _movement.velocity.y);
        }
    }
    void Gravity()
    {
        _playerVelocity.y += _gravityValue * 2 * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    
        /*if (_checkGround == true)
        {
            _checkGround = true;
        }
        else if (_checkGround == false)
        {
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }*/
    }
    public void SetMove(InputAction.CallbackContext value) //Input direcional X e Z (Input System)
    {
        _input = value.ReadValue<Vector2>();
    }
    public void SetPular(InputAction.CallbackContext value) //Pulo: true ou false
    {
        _inputPulo = true;
    }
    /*private void OnCollisionEnter(Collision coll) // Se estiver encostando em um gameobject com a tag "Ground" marcará true
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
        }
    }
    private void OnCollisionExit(Collision coll) // Se não estiver encostando em um gameobject com a tag "Ground" marcará falso
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
    }*/
}
