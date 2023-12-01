using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class MoveLixo : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _alvo;
    [SerializeField] Transform[] _pos;
    [SerializeField] Transform _player;

    int _numberM;

    float _distancia;
    float _distanciaPlayer;
    float _checktime;
    [SerializeField] float _distancePatrulhar;
    [SerializeField] float _speedAnim;
    [SerializeField] float _timeLimit;

    Vector3 _speedAgent;

    [SerializeField] Animator _animator;

    [SerializeField] Hits _hit;

    bool _seguirPlayer;
    public bool _hitCheck;
    public bool _checkMove;
 

    [SerializeField] bool _isPlayer;
    [SerializeField] bool _ataqueOn;
    [SerializeField] bool _hitAtaque;
    [SerializeField] bool _stopPlayer;
    [SerializeField] GaaameController _gameControler;
    public bool _checkMorte;

    public Transform _posInicial;
    MoveControl _buriControl;
    ControladorInimigos _controladorInimigos;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator = GetComponentInChildren<Animator>();
        _hit = GetComponent<Hits>();
        _checktime = _timeLimit;
        _gameControler = Camera.main.GetComponent<GaaameController>();
        _controladorInimigos = Camera.main.GetComponent<ControladorInimigos>();
        _player = _gameControler._player;
        _buriControl = _player.GetComponent<MoveControl>();
        //_posInicial = transform.position;
        _checkMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        _controladorInimigos._seguirPlayer = _buriControl._checkMover;
        if (_controladorInimigos._seguirPlayer)
        {
            _agent.SetDestination(_player.position);
           // Debug.Log("SeguirPlayer");
        }
        else
        {
           _agent.SetDestination(_posInicial.position);
           // Debug.Log("Voltar para:" + _posInicial);
        }

        Ataque();
        if (!_checkMorte)
        {
            Movimento();
        }
        else
        {
            Hit(true);
        }
        if (_agent != null)
        {
            _speedAgent = _agent.velocity;
        }
        //_ataqueOn = _controller;

        Animacao();

        if (_hitCheck)
        {
            _checktime -= Time.deltaTime;
            if (_checktime < 0) 
            {
                Hit(false);
                _hitCheck = false;
                _checktime = _timeLimit;
            }
        }
    }

    void Patrulhar()
    {
        if (_distancia < _distancePatrulhar && _numberM == 0) // se a distancia for menor que 5 e numberM for igual a 0
        {
            _numberM = 1;
            _stopPlayer = true;
        }
        else if (_distancia < _distancePatrulhar && _numberM == 1) // se a distancia for menor que 5 e numberM for igual a 1
        {
            _numberM = 0;
            _stopPlayer = true;
        }
        _alvo = _pos[_numberM];
    }

    void Animacao()
    {
        _speedAnim = MathF.Abs(_speedAgent.x + _speedAgent.z);
        if (_animator != null)
        {
            _animator.SetFloat("Speed", _speedAnim);
            _animator.SetBool("isPlayer", _isPlayer);
            _animator.SetBool("Ataque", _ataqueOn);
            _animator.SetBool("hit", _hitAtaque);
            _animator.SetBool("hitmorte", _hitCheck);
        }
       // _animator.SetBool ("Morte", _hitCheck);
    }

    void Movimento()
    {
        //_agent.destination = _alvo.position;
        if (_agent != null)
        {
            _distancia = _agent.remainingDistance;
            _distanciaPlayer = Vector3.Distance(transform.position, _player.position);


            if (_distanciaPlayer < 8) // se a distancia player for menor que 8
            {
                _seguirPlayer = true;
                _agent.speed = 6;
            }
            else
            {
                _seguirPlayer = false;
            }

            if (!_seguirPlayer) // ! falsa
            {
                Patrulhar();
                if (_controladorInimigos._seguirPlayer)
                {
                    _agent.SetDestination(_alvo.position); // setar destino / enviar destino
                }
                   // _agent.SetDestination(_alvo.position); // setar destino / enviar destino
                _ataqueOn = false;
            }
            else
            {

              
                if (_controladorInimigos._seguirPlayer)
                {
                    _agent.SetDestination(_player.position);
                }

                //_agent.SetDestination(_player.position);
                if (_distanciaPlayer < 5) // se a distancia player for menor que 8
                {
                    _ataqueOn = true;
                }
                else
                {
                    _ataqueOn = false;
                }

            }
        }
    }

    void Ataque()
    {
        //_controller.velocity = new Vector2(0, _controller.velocity.y);
    }
   
    void Hit(bool on) // bool on = função que tem valor de retorno
    {
        if (on) // quando tiver on ta sofrendo hit
        { 
        _agent.velocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<CapsuleCollider>().enabled = false; // desativando gameobject capsule collider
        GetComponent<Rigidbody>().isKinematic = true; // acessando o rigidbody sem variavel e ativando o iskinematic
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaqueMili"))
        {
            _hitCheck = true;
        }
       
    }
}
