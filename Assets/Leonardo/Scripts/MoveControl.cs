using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    private Vector2 _input; //Input system, axis: X,Z. 
    [SerializeField] Vector3 _playerVelocity;
    private Vector3 _movement;

    private CharacterController _controller;
    private Animator _anim;

    //[SerializeField] LayerMask _groundMask;
    //[SerializeField] private float _raycastLenght = 1.15f; //Raio para identificar Ground, saindo do centro do gameObject

    private bool _inputPulo; //Input de pulo
    [SerializeField] bool _checkGround; //Verificador se o player está encostando no chão
    public bool _recebeuDano;


    private float _gravityValue = -9.81f;
    private float _gravityMultiplier;
    [SerializeField] float _speed = 5;
    [SerializeField] float _speedRotation = 15;
    [SerializeField] float _jump = 5;
    [SerializeField] float _timer; // Contador para input de pulo, útil se tiver problema de pulo duplo
    private float _timerValue;

    //---------------------Camera-----------------------
    [SerializeField] GameObject _Camera;
    [SerializeField] Transform _pivotCamera;
    [SerializeField] Vector3 _offset;

    void Start()
    {
        _timer = _timerValue;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        AndarN();
        _Camera = Camera.main.gameObject;        
    }

    void Update()
    {
        Move();
        LookAtMovementDirection();
        Dano();
        Gravity();
        CheckPulo(); // Checa se está encostando no chão e função de timer para normalizar pulo
        CameraControl();
        {
            //Debugando   
            //Debug.Log("Estou no chão? " + _checkGround);
        }
    }
    void AndarN()// Sincronizar animações - Andar movimento de perna/Andar movimento de braço
    {
        _anim.SetLayerWeight(0, 1); //perna
        _anim.SetLayerWeight(1, 1); //braco
    }
    void Move()
    {
        _movement = new Vector3(_input.x, _controller.velocity.y, _input.y).normalized * _speed * Time.deltaTime;
        _controller.Move(_movement);
        // Linhas abaixo feitas para animação do personagem
        float _andar = Mathf.Abs(_input.x) + Mathf.Abs(_input.y);
        _anim.SetFloat("Andar", _andar);
        _anim.SetFloat("VelocidadeY", _controller.velocity.y);
        _anim.SetBool("groundCheck", _checkGround);
    }
    void LookAtMovementDirection() //Script para virar a frente do personagem voltada a orientação do movimento
    {
        if (_input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedRotation * Time.deltaTime);
        }
    }
    public void Pulo()
    {
        if (_checkGround)
        {
            _inputPulo = false;
            _playerVelocity.y = Mathf.Sqrt(0);
            _playerVelocity.y = Mathf.Sqrt(_jump * -3.0f * _gravityValue);
            _playerVelocity.x = Mathf.Sqrt(_jump);
            if (_checkGround)
            {
                _playerVelocity.x = 0;
            }   
            _anim.SetFloat("VelocidadeY", _controller.velocity.y);
        }
    }
    void CheckPulo() // Timer para negativar inputPulo corretamente
    {
        // ^^Raycast para idendificar terreno do tipo Ground
        //_checkGround = Physics.Raycast(transform.position, Vector3.down, _raycastLenght, _groundMask);
        _checkGround = _controller.isGrounded;
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
    void Dano()
    {
        if (_recebeuDano == true)
        {
            _anim.SetBool("hit", _recebeuDano);
            Invoke("DanoTime", 3f);
            Debug.Log("RecebeuDano");
        }
    }
    void DanoTime()
    {
        _recebeuDano = false;
        _anim.SetBool("hit", _recebeuDano);
    }
    void Gravity() // Se estiver encostando no chão zerar o vector.Down que no caso é o gravity multiplier
    {
        if (_checkGround == true)
        {
            _gravityMultiplier = 0;
        }
        else if (_checkGround == false)
        {
            _gravityMultiplier = 2;
        }
        _playerVelocity.y += _gravityValue * _gravityMultiplier * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
    void CameraControl()
    {
        //_Camera.transform.localPosition = _pivotCamera.transform.position + _offset;
        _Camera.transform.localPosition = Vector3.Lerp(_Camera.transform.position, _pivotCamera.transform.position + _offset, 5f * Time.deltaTime);
    }
    public void SetMove(InputAction.CallbackContext value) //Input direcional X e Z (Input System)
    {
        _input = value.ReadValue<Vector2>();
    }
    public void SetPular(InputAction.CallbackContext value) //Pulo: true ou false
    {
        Pulo();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaqueIni"))
        {
            _recebeuDano = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AtaqueIni"))
        {
            _recebeuDano = false;
        }
    }
}
