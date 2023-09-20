using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Peixinho : MonoBehaviour
{
    [SerializeField] public Transform _alvo;
    [SerializeField] public Transform[] _pos;
    private int _numberM;
    
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        float _distancia = _agent.remainingDistance;
        float _distanciaRest = 0.1f;
        if (_distancia < _distanciaRest && _numberM == 0)
        {
            _numberM = 1;
        }
        else if (_distancia < _distanciaRest && _numberM == 1)
        {
            _numberM = 0;
        }
        _alvo = _pos[_numberM];
        _agent.SetDestination(_alvo.position);
    }


}
