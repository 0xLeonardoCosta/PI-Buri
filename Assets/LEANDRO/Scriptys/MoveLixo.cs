using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class MoveLixo : MonoBehaviour
{
    [SerializeField] CharacterController _controller;

    NavMeshAgent _agent;
    [SerializeField] Transform _alvo;
    [SerializeField] Transform[] _pos;
    [SerializeField] Transform _player;

    int _numberM;

    float _distancia;
    float _distanciaPlayer;
    [SerializeField] float _distancePatrulhar;
    [SerializeField] float _speedAnim;

    Vector3 _speedAgent;

    Animator _animator;

    [SerializeField] Hits _hit;

    bool _seguirPlayer;
    [SerializeField] bool _isPlayer;
    [SerializeField] bool _ataqueOn;
    [SerializeField] bool _stopPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _hit = GetComponent<Hits>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Animacao();
        Ataque();
        _speedAgent = _agent.velocity;
        _ataqueOn = _controller;

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
        _animator.SetFloat("Speed", _speedAnim);
        _animator.SetBool("isPlayer", _isPlayer);
        _animator.SetBool("Ataque", _ataqueOn);
        _animator.SetBool("hit", _hit._isHit);
    }

    void Movimento()
    {

        //_agent.destination = _alvo.position;
        _distancia = _agent.remainingDistance;
        _distanciaPlayer = Vector3.Distance(transform.position, _player.position);

        if (_distanciaPlayer < 8) // se a distancia player for menor que 8
        {
            _seguirPlayer = true;
        }
        else
        {
            _seguirPlayer = false;
        }

        if (!_seguirPlayer) // ! falsa
        {
            Patrulhar();
            _agent.SetDestination(_alvo.position); // setar destino / enviar destino
            _ataqueOn = false;
        }
        else
        {

            _agent.SetDestination(_player.position);
            if (_distanciaPlayer < 3) // se a distancia player for menor que 8
            {
                _ataqueOn = true;
            }
            else
            {
                _ataqueOn = false;
            }

        }
    }

    void Ataque()
    {
        //_controller.velocity = new Vector2(0, _controller.velocity.y);
    }
    void Morte()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
        }
    }

}
