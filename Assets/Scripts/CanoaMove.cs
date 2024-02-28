using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoaMove : MonoBehaviour
{
    [SerializeField] MoveControl _moveBuri;

    [SerializeField] Transform _player;
    
    [SerializeField] Transform _buriPosCanoa;

    [SerializeField] Transform _pivot;

    [SerializeField] Vector2 _input;

    [SerializeField] Vector3 _movement;

    [SerializeField] Rigidbody _rb;
    [SerializeField] CharacterController _controller;

    [SerializeField] public bool _utilizarCanoa;
    [SerializeField] bool _utilizandoCanoa;

    [SerializeField] float _velocidadeCurva;
    [SerializeField] float _velocidade;

    void Start()
    {
        _player = Camera.main.GetComponent<GaaameController>()._player;
        //_rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_moveBuri != null)
        {
            _input = _moveBuri._input;
            _utilizandoCanoa = true;
            CanoaMovement();
        }
    }

    public void CanoaMovement()
    {
        if (_utilizandoCanoa)
        {
            _moveBuri._usandoCanoa = true;
            _moveBuri._pivotCamera = transform;
            //Travas de movimento e pulo
            _moveBuri._variacaoVelocidadeAndar = 0;
            _moveBuri._variacaoAltura = 0;
            //_moveBuri._gravityMultiplier = 0;
             _moveBuri._checkGround = false;
             _moveBuri._checkMover = false;
            //_moveBuri.enabled = false;
            //Controle da câmera
            

            //Botar o Buri Sentado na canoa
            //_player.position = transform.position;
            _player.SetParent(_buriPosCanoa);
            _player.transform.localEulerAngles = new Vector3(0,0,0);
            _player.transform.localPosition = Vector3.zero;

            //transform.RotateAround(_pivot.position, Vector3.up, _velocidadeCurva * _input.x * Time.deltaTime);

            transform.Translate(Vector3.up * _velocidade * _input.y);
            //_rb.MovePosition(transform.position + Vector3.right * _velocidade * _input.y);
            if (_input.x < 0)
            {
                _pivot.localPosition = new Vector3(5f,0,0);
            }
            if (_input.x > 0)
            {
                _pivot.localPosition = new Vector3(-5f,0,0);
            }
            transform.RotateAround(_pivot.position, Vector3.up, _velocidadeCurva * _input.x * Time.deltaTime);
            //_rb.MoveRotation(_pivot.position, Vector3.up, _velocidadeCurva * _input.x * Time.deltaTime);

            //_movement = new Vector3(_input.x, _controller.velocity.y, _input.y) * _velocidade * Time.deltaTime;
            //_controller.Move(_movement);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _moveBuri = other.GetComponent<MoveControl>(); 
        }
    }
}
