using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    public Vector2 _input; //Input system, axis: X,Z. 
    [SerializeField] Vector3 _playerVelocity;
    [SerializeField] private Vector3 _movement;

    public CharacterController _controller;
    private Animator _anim;

    //[SerializeField] LayerMask _groundMask;
    //[SerializeField] private float _raycastLenght = 1.15f; //Raio para identificar Ground, saindo do centro do gameObject

    private bool _inputPulo; //Input de pulo

    [SerializeField] public GameObject _buriTriguer;

    //--------------------------Baladeira--------------------------------
    [SerializeField] GameObject _projetil;
    [SerializeField] Ball _projetilBala;
    //--------------------------TimerBala---------------------------------
    [SerializeField] float _timerBala; // Contador para input de bala
    //--------------------------TimerBala---------------------------------
    [SerializeField] private float _timerValueBala;

    private float _gravityValue = -9.81f;
    public float _gravityMultiplier;
    [SerializeField] float _speed;
    [SerializeField] float _speedMin = 3;
    [SerializeField] float _speedMax = 9;
    [SerializeField] float _speedRotation = 15;
    [SerializeField] float _variacaoVelocidadeCanoa;
    [SerializeField] float _jump = 5;
    [SerializeField] float _amplitudeAnalogico;
    [SerializeField] float _inputAnalogicoCam;
    [SerializeField] float _timer; // Contador para input de pulo, útil se tiver problema de pulo duplo
    private float _timerValue;

    //===================SistemaDeVida===================
    //VidaControler _vidaControler;
    [SerializeField] GaaameController _gaaameController;
    [SerializeField] HudGames _hudGames;
    [SerializeField] int _vidaAtual;
    [SerializeField] bool _gameOver;
    //---------------------Camera-----------------------
    [SerializeField] GameObject _camera;
    [SerializeField] public Transform _pivotCamera;
    [SerializeField] public Vector3 _cameraOffset = new (0f,9f,-9f);
    [SerializeField] Playpontos _playerPontos;

    //------------------Teste---------------------
    public float testando;

    public bool _hitFruta;

    public TargetLocation _targetLocation;
    public float speed = 1.0f;

    [SerializeField] GameObject _botaoCorrerAndar;

    //------------------Canoa---------------------
    
    [Header("Gatilhos da animação")]
    [SerializeField] public float _variacaoVelocidadeAndar;
    [SerializeField] public float _variacaoAltura;
    [SerializeField] public bool _checkGround; //Verificador se o player está encostando no chão
    [SerializeField] public bool _checkMover; //Verificador se o player vai poder se mexer ou não
    [SerializeField] public bool _recebeuDano;
    [SerializeField] public bool _inputBaladeira; //Input de baladeira
    [SerializeField] public bool _usandoCanoa;
    [SerializeField] public bool _estaCorrendo;
    [SerializeField] public bool _estaAndando;
    [SerializeField] public bool _estaNaAgua;
    [SerializeField] Vector3 magnitude;

    //------------------Canoa---------------------

    [Header("Objetos Carregados")]
    [SerializeField] GameObject _baladeira;
    [SerializeField] GameObject _varaPesca;
    [SerializeField] GameObject _remo;
    

    void Start()
    {
        _timer = _timerValue;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        AndarN();
        _camera = Camera.main.gameObject;
        _checkMover = true;
        _projetilBala = _projetil.GetComponent<Ball>();
        _timerBala = _timerValueBala;
        //_vidaControler = Camera.main.GetComponent<VidaControler>();
        _gaaameController = Camera.main.GetComponent<GaaameController>();
        _hudGames = _gaaameController._canvasHud.GetComponent<HudGames>();
        _playerPontos = Camera.main.GetComponent<Playpontos>();
        EstaCorrendo();


    }

    void Update()
    {
        if (!_usandoCanoa)
        {
            Move();
            LookAtMovementDirection();// pausar na mira
            RotIni();// so quando mirar
            Dano();
            Gravity();
            CheckPulo();// Checa se está encostando no chão e função de timer para normalizar pulo
            VidaCheck();
            ReativarBaladeira();
            BaladeiraCheck();
            CanoaCheck();
            EstaAndando();
            NaAguaCheck();
            _anim.SetLayerWeight(1, 1);
        }
        else
        {
            MoveCanoa();
        }
        CameraControl();
        _variacaoAltura = _controller.velocity.y;
    }
    void AndarN()// Sincronizar animações - Andar movimento de perna/Andar movimento de braço
    {
        _anim.SetLayerWeight(0, 1); //perna
        _anim.SetLayerWeight(1, 1); //braco
    }
    void VidaCheck()
    {
        _vidaAtual = _hudGames._vidaAtual;
        if (_vidaAtual <= 0)
        {
            _gameOver = true;
        }
    }
    void Morte()
    {
        //travar move/ trava jogp 
        //sair da aniamção
        //false
        //invoke()
    }
    //invoke , painel, gameover....
    void MoveCanoa()
    {
        _variacaoVelocidadeCanoa = Mathf.Abs(_input.x) + Mathf.Abs(_input.y);
        _anim.SetFloat("RemarCanoa", _variacaoVelocidadeCanoa);
        _anim.SetBool("UsandoCanoa", _usandoCanoa);
        _anim.SetFloat("Andar", 0);
        _anim.SetFloat("VelocidadeY", 0);
        _baladeira.SetActive(false);
        _varaPesca.SetActive(false);
        _remo.SetActive(true);
        _anim.SetLayerWeight(1, 0);
    }
    void CanoaCheck()
    {
        _anim.SetFloat("RemarCanoa", _variacaoVelocidadeCanoa);
        _anim.SetBool("UsandoCanoa", _usandoCanoa);
    }
    void ReativarBaladeira()
    {
        _baladeira.SetActive(true);
        _varaPesca.SetActive(false);
        _remo.SetActive(false);
    }
    void Move()
    {
        if (_checkMover)
        {
            magnitude = new Vector3(_input.x, _controller.velocity.y, _input.y).normalized; // PAREI AQUI
            
            _movement = new Vector3(_input.x, _controller.velocity.y, _input.y).normalized * _speed * Time.deltaTime;
        }
        else
        {
            _movement = Vector3.zero;
        }
        _controller.Move(_movement);
        // Linhas abaixo feitas para animação do personagem
        _variacaoVelocidadeAndar = Mathf.Abs(_input.x) + Mathf.Abs(_input.y);
        _variacaoAltura = _controller.velocity.y;
        
        if (_speed == 0) { _speed = 5; }
        _anim.SetFloat("Andar", _variacaoVelocidadeAndar);
        _anim.SetFloat("VelocidadeY", _variacaoAltura);
        _anim.SetBool("groundCheck", _checkGround);
        _anim.SetBool("Morte", _gameOver);
    }
    public void EstaCorrendo()
    {   
        if (_estaCorrendo == false)
        {
            _estaCorrendo = true;
            _speed = 9;
        }
        else if (_estaCorrendo == true)
        {
            _estaCorrendo = false;
            _speed = 5;
        }
        _anim.SetBool("EstaCorrendo", _estaCorrendo);
    }
    public void EstaAndando()
    {   
        if (_variacaoVelocidadeAndar < 0.5 || _estaCorrendo == false)
        {
            _estaAndando = true;
        }
        else if (_variacaoVelocidadeAndar > 0.5 || _estaCorrendo == true)
        {
            _estaAndando = false;
        }
        _anim.SetBool("EstaAndando", _estaAndando);
    }
    void NaAguaCheck()
    {   
        _anim.SetBool("EstaNaAgua", _estaNaAgua);
        if (_estaNaAgua == true)
        {
            _baladeira.SetActive(false);
            _botaoCorrerAndar.SetActive(false);
            _speed = 5;
        }
        else
        {
            _baladeira.SetActive(true);
            VerificarSpeed();
            _botaoCorrerAndar.SetActive(true);
        }
    }
    void VerificarSpeed()
    {
        if (_estaCorrendo == true)
        {
            _speed = 9;
        }
        else
        {
            _speed = 5;
        }
    }
    void LookAtMovementDirection() //Script para virar a frente do personagem voltada a orientação do movimento
    {
        if (_input != Vector2.zero && _checkMover && !_inputBaladeira)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedRotation * Time.deltaTime);
        }
    }

    void RotIni()
    {
        if (_targetLocation.inimigoMaisProximo != null && _inputBaladeira)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = _targetLocation.inimigoMaisProximo.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;


            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
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
           // _anim.SetFloat("VelocidadeYVelocidadeY", _controller.velocity.y);
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
            //_vidaControler.RecebeuDano();
            _hudGames.RecebeuDano();
            //Debug.Log("RecebeuDano");
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
        Vector3.Lerp(_camera.transform.position, _pivotCamera.position + _cameraOffset, 5f * Time.deltaTime);
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
    void BaladeiraCheck()
    {
        if (_inputBaladeira == true)
        {
            _timerBala -= Time.deltaTime;
            if (_timerBala < 0)
            {
                _inputBaladeira = false;
                _anim.SetBool("TiroBaladeira", _inputBaladeira);
                _timerBala = _timerValueBala;
            }
        }
    }
    public void AtirarBaladeira()
    {
        _inputBaladeira = true;
        _anim.SetBool("TiroBaladeira", true);
        Debug.Log(_inputBaladeira + " TiroBaladeira");
        //timer
    }

    public void Atirar()
    {
        _projetilBala.Lancar();
    } 

    public void SetMove(InputAction.CallbackContext value) //Input direcional X e Z (Input System)
    {
        _input = value.ReadValue<Vector2>();
        _amplitudeAnalogico = _input.magnitude;
        //_speed = Mathf.Lerp(_speedMin, _speedMax, _amplitudeAnalogico);

    }
    public void SetPular(InputAction.CallbackContext value) //Pulo: true ou false
    {
        Pulo();
    }
    public void SetBaladeira(InputAction.CallbackContext value)
    {
        AtirarBaladeira();
    }
    public void SetEstaCorrendo(InputAction.CallbackContext value)
    {
        EstaCorrendo();
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
        if (other.gameObject.CompareTag("Item") && !_hitFruta)
        {
            _hitFruta = true;
            int valorPontos = other.GetComponent<Item>().Valor;
            _playerPontos.SomarPontos(valorPontos);
            _hudGames.GanhouVida();
            other.GetComponent<Item>().DestroyItem();
            Invoke("HitFruta", 1);
         
        }

        if (other.gameObject.CompareTag("AtaqueIni"))
        {
            _recebeuDano = true;
        }

        if (other.gameObject.CompareTag("Agua"))
        {
            _estaNaAgua = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AtaqueIni"))
        {
            _recebeuDano = false;
        }

        if (other.gameObject.CompareTag("Agua"))
        {
                _estaNaAgua = false;
        }
    }

    private void HitFruta()
    {
        _hitFruta = false;
    }
}
