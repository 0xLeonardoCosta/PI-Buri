using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirPlayer33 : MonoBehaviour
{
    NavMeshAgent _agent;
    public Transform _player;

    public float _speedNew;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.speed = _speedNew;
        _agent.SetDestination(_player.position);
    }
}
