using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CanoaMove : MonoBehaviour
{
    [SerializeField] MoveControl _moveBuri;

    [SerializeField] GameObject _botaoCanoa;
    
    [SerializeField] GameObject _rio;

    [SerializeField] Transform _player;
    
    [SerializeField] Transform _buriPosCanoa;

    [SerializeField] Vector3 _buriPosSpawn;

    [SerializeField] Transform _pivot;

    [SerializeField] Vector2 _input;

    [SerializeField] Vector3 _movement;

    [SerializeField] public bool _utilizarCanoa;
    [SerializeField] bool _utilizandoCanoa;

    [SerializeField] Rigidbody _rb;

    [SerializeField] float _velocidadeCurva;
    [SerializeField] float _velocidade;
    bool _dentroCanoa;

    void Start()
    {
        _player = Camera.main.GetComponent<GaaameController>()._player;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_moveBuri != null) // Se a variavel _moveBuri estiver atribuida, ou seja, não esteja vazia
        {
            _input = _moveBuri._input;
            CanoaMovement();
        }
    }
    public void PressionarBotao()
    {
        if (_utilizandoCanoa == false)
        {
            _utilizandoCanoa = true;
        }
        else if (_utilizandoCanoa == true)
        {
            _utilizandoCanoa = false;
        }
    }
    public void CanoaMovement()
    {
        if (_utilizandoCanoa)
        {
            _rio.GetComponent<MeshCollider>().isTrigger = false;
            _moveBuri._usandoCanoa = true;
            _moveBuri._pivotCamera = transform;
            _moveBuri._variacaoVelocidadeAndar = 0;
            _moveBuri._variacaoAltura = 0;
            _moveBuri._checkGround = false;
            _moveBuri._checkMover = false;
            _moveBuri._buriTriguer.GetComponent<CapsuleCollider>().enabled = false;

            //Botar o Buri Sentado na canoa
            _player.SetParent(_buriPosCanoa);
            _player.transform.localEulerAngles = new Vector3(0,0,0);
            _player.transform.localPosition = Vector3.zero;

            //transform.Translate(Vector3.up * _velocidade * _input.y);

            //utlizando o rigidbody
            Vector3 moveDirection = transform.up * _input.y * _velocidade;
            _rb.MovePosition(_rb.position + moveDirection * Time.fixedDeltaTime);

            if (_input.x < 0)
            {
                _pivot.localPosition = new Vector3(5f,0,0);
            }
            if (_input.x > 0)
            {
                _pivot.localPosition = new Vector3(-5f,0,0);
            }
            //transform.RotateAround(_pivot.position, Vector3.up, _velocidadeCurva * _input.x * Time.deltaTime);

            // Rotação em torno do eixo Y mantendo o pivô constante
            Quaternion deltaRotation = Quaternion.Euler(Vector3.back * _input.x * _velocidadeCurva * Time.fixedDeltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
        else
        {
            //Quando Buri sair da canoa
            _rio.GetComponent<MeshCollider>().isTrigger = true;
            _moveBuri._usandoCanoa = false;
            _moveBuri._pivotCamera = _moveBuri.transform;
            _moveBuri._variacaoVelocidadeAndar = Mathf.Abs(_moveBuri._input.x) + Mathf.Abs(_moveBuri._input.y);
            _moveBuri._variacaoAltura = _moveBuri._controller.velocity.y;
            _moveBuri._checkGround = _moveBuri._controller.isGrounded;
            _moveBuri._checkMover = true;
            _moveBuri._buriTriguer.GetComponent<CapsuleCollider>().enabled = true;
            _player.SetParent(null);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _moveBuri = other.GetComponent<MoveControl>();
            _botaoCanoa.SetActive(true);
            
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  //&& !_utilizandoCanoa)
        {
            _botaoCanoa.SetActive(false);
            //_moveBuri = null;
            Debug.Log("Saiu canoa");
            
        }
    }
}
