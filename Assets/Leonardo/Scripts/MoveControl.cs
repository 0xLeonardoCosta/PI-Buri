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
    [SerializeField] public bool _checkMover; //Verificador se o player vai poder se mexer ou não
    public bool _recebeuDano;


    private float _gravityValue = -9.81f;
    private float _gravityMultiplier;
    [SerializeField] float _speed;
    [SerializeField] float _speedMin = 3;
    [SerializeField] float _speedMax = 9;
    [SerializeField] float _speedRotation = 15;
    [SerializeField] float _jump = 5;
    [SerializeField] float _amplitudeAnalogico;
    [SerializeField] float _inputAnalogicoCam;
    [SerializeField] float _timer; // Contador para input de pulo, útil se tiver problema de pulo duplo
    private float _timerValue;

    //---------------------Camera-----------------------
    [SerializeField] GameObject _camera;
    [SerializeField] Transform _pivotCamera;
    [SerializeField] Vector3 _cameraOffset = new (0f,9f,-9f);

    //------------------Teste---------------------
    public float testando;

    void Start()
    {
        _timer = _timerValue;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        AndarN();
        _camera = Camera.main.gameObject;
        _checkMover = true;
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
        if (_checkMover)
        {
            _movement = new Vector3(_input.x, _controller.velocity.y, _input.y).normalized * _speed * Time.deltaTime;
        }
        else
        {
            _movement = Vector3.zero;
        }
        _controller.Move(_movement);
        // Linhas abaixo feitas para animação do personagem
        float _andar = Mathf.Abs(_input.x) + Mathf.Abs(_input.y);
        _anim.SetFloat("Andar", _andar);
        _anim.SetFloat("VelocidadeY", _controller.velocity.y);
        _anim.SetBool("groundCheck", _checkGround);
    }
    void LookAtMovementDirection() //Script para virar a frente do personagem voltada a orientação do movimento
    {
        if (_input != Vector2.zero && _checkMover)
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
        if (_recebeuDano == true && _checkMover)
        {
            _checkMover = false;
            _anim.SetBool("hit", _recebeuDano);
            Invoke("DanoTime", 3f);
            Debug.Log("RecebeuDano");
        }
    }
    void DanoTime()
    {
        _recebeuDano = false;
        _anim.SetBool("hit", _recebeuDano);//
        _checkMover= true;
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
        _camera.transform.localPosition =
        Vector3.Lerp(_camera.transform.position, _pivotCamera.transform.position + _cameraOffset, 5f * Time.deltaTime);
        //_camera.transform.localRotation = Quaternion.Lerp(_camera.transform.rotation, _pivotCamera.transform.rotation, _inputAnalogicoCam).normalized;
        float maxRotationCameraAngle = 45f;
        float normalizedInput = Mathf.Clamp(_inputAnalogicoCam, -1f, 1f);
        float targetRotationY = normalizedInput * maxRotationCameraAngle;
        Quaternion targetRotation = Quaternion.Euler(36f, targetRotationY, 0f);
        _camera.transform.localRotation = Quaternion.Lerp(_camera.transform.localRotation, targetRotation, Mathf.Abs(normalizedInput)).normalized;
        if (_inputAnalogicoCam == 0)
        {
            _camera.transform.localRotation = Quaternion.Lerp(_camera.transform.localRotation, Quaternion.Euler(36f, 0f, 0f), 0.3f); //Quaternion.Euler(36f, 0f, 0f);
        }
    }
    public void SetMove(InputAction.CallbackContext value) //Input direcional X e Z (Input System)
    {
        _input = value.ReadValue<Vector2>();
        _amplitudeAnalogico = _input.magnitude;
        _speed = Mathf.Lerp(_speedMin, _speedMax, _amplitudeAnalogico);

    }
    public void SetPular(InputAction.CallbackContext value) //Pulo: true ou false
    {
        Pulo();
    }
    public void SetCameraAnalogico(InputAction.CallbackContext value) //Pulo: true ou false
    {
        _inputAnalogicoCam = value.ReadValue<float>();
        //if (_inputAnalogicoCam < 0)
        {
          //  _pivotCamera
        }
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
