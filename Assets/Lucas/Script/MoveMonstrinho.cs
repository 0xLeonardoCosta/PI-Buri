using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveMonstrinho : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent _agent;

    Rigidbody _rb;

    [SerializeField] float[] _distPos;
    [SerializeField] float _distPlayerLimit;
    [SerializeField] float _distPosLimit;
    [SerializeField] float[] _velocidades;
    [SerializeField] float _moveVelocidade;

    [SerializeField] bool _isplayer;
    [SerializeField] bool _stopPlayer;
    bool _isFacingRight;
    [SerializeField] bool _ataqueOn;

    Animator _animator;

    [SerializeField] Transform[] _pos;
    [SerializeField] Transform _player;
    [SerializeField] Transform _alvo;

    float _distancia;
    float _distanciaPlayer;
    [SerializeField] float _distanciaPatrulhar;
    [SerializeField] float _speedAnim;

    Vector3 _speedAgent;

    int _numberM;

    bool _seguirPlayer;



    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _speedAgent = _agent.velocity;
        Movimento();
       
        if (_ataqueOn == false)
        {
            Movimento();
            Patrulhar();
        }
        else
        {
            Ataque();
        }
        Animacao();
    }

    void Patrulhar()
    {
        if (_distancia < _distanciaPatrulhar && _numberM == 0)
        {
            _numberM = 1;
        }
        else if (_distancia < 5 && _numberM == 1)
        {
            _numberM = 0;
        }
        _alvo = _pos[_numberM];
    }

    void Animacao()
    {
        _speedAgent = _agent.velocity;
        _speedAnim = Mathf.Abs(_speedAgent.x + _speedAgent.z);

    }

    void Movimento()
    {
        _distancia = _agent.remainingDistance;
        _distanciaPlayer = Vector3.Distance(transform.position, _player.position);
        if (_distanciaPlayer < 8)
        {
            _seguirPlayer = true;
        }
        else
        {
            _seguirPlayer = false;
        }

        if (!_seguirPlayer)
        {
            Patrulhar();
            _agent.SetDestination(_alvo.position);
            _ataqueOn = false;
        }
        else
        {
            _agent.SetDestination(_player.position);

            if (_distanciaPlayer < 3)
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
        _rb.velocity = new Vector3(0, _rb.velocity.y);
    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _ataqueOn = true;
        }
    }

    private void OnTriggerExit(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _ataqueOn = false;
        }
    }
}
