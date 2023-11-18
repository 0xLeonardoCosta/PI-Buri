using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCaipora : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField] Transform _player;
    Animator _animator;

    GaaameController _gameControler;

    [SerializeField] bool _estaSeguindo;
    [SerializeField] bool _estaSeguindoCorrendo;

    [SerializeField] float _distancia;
    [SerializeField] float _distanciaSeguir;
    [SerializeField] float _distanciaPlayer;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _gameControler = Camera.main.GetComponent<GaaameController>();
        _player = _gameControler._player;
    }

    // Update is called once per frame
    void Update()
    {
        Patrulha();
        Animacao();
    }

    void Patrulha()
    {
        _distancia = _agent.remainingDistance;
        _distanciaPlayer = Vector3.Distance(transform.position, _player.position);


        if (_distanciaPlayer < _distanciaSeguir)
        {
            _estaSeguindo = true;
        }
        else
        {
            _estaSeguindo = false;
        }

        if (_distancia > 7 && _estaSeguindo)
        {
            _estaSeguindoCorrendo = true;
            _agent.speed = 10.5f;
        }
        else if (_distancia < 7 && _estaSeguindo)
        {
            _estaSeguindoCorrendo = false;
            _agent.speed = 3.5f;
        }

        if (_estaSeguindo)
        {
            _agent.SetDestination(_player.position);
        }
        else
        {
            _agent.SetDestination(transform.position);
        }
    }

    void Animacao()
    {
        //_speedAnim = MathF.Abs(_speedAgent.x + _speedAgent.z);
        if (_animator != null)
        {
            //_animator.SetFloat("Speed", _speedAnim);
            _animator.SetBool("Andando", _estaSeguindo);
            _animator.SetBool("Correndo", _estaSeguindoCorrendo);
        }
        // _animator.SetBool ("Morte", _hitCheck);
    }
}
