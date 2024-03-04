using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CanoaMove : MonoBehaviour
{
    [SerializeField] MoveControl _moveBuri;

    [SerializeField] AtracaCanoa _atracaCanoa;

    [SerializeField] Transform _player;
    
    [SerializeField] Transform _buriPosCanoa;

    [SerializeField] Transform _buriPosSpawn;

    [SerializeField] Transform _pivot;

    [SerializeField] Vector2 _input;

    [SerializeField] Vector3 _movement;

    [SerializeField] public bool _utilizarCanoa;
    [SerializeField] bool _utilizandoCanoa;
    [SerializeField] bool _atracouCanoa;

    [SerializeField] float _velocidadeCurva;
    [SerializeField] float _velocidade;

    void Start()
    {
        _player = Camera.main.GetComponent<GaaameController>()._player;
    }

    void Update()
    {
        if (_moveBuri != null) // Se a variavel _moveBuri estiver atribuida, ou seja, não esteja vazia
        {
            _input = _moveBuri._input;
            if (_atracouCanoa == true) 
            {
                _utilizandoCanoa = false;
            }
            else
            {
                _utilizandoCanoa = true;
            }
            CanoaMovement();
        }
    }

    public void CanoaMovement()
    {
        if (_utilizandoCanoa)
        {
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

            transform.Translate(Vector3.up * _velocidade * _input.y);
            if (_input.x < 0)
            {
                _pivot.localPosition = new Vector3(5f,0,0);
            }
            if (_input.x > 0)
            {
                _pivot.localPosition = new Vector3(-5f,0,0);
            }
            transform.RotateAround(_pivot.position, Vector3.up, _velocidadeCurva * _input.x * Time.deltaTime);
        }
        else
        {
            _player.transform.localEulerAngles = new Vector3(0, 0, 0);
            _player.transform.position = _buriPosSpawn.position;

            _moveBuri._usandoCanoa = false;
            _moveBuri._pivotCamera = _moveBuri.transform;
            _moveBuri._variacaoVelocidadeAndar = Mathf.Abs(_moveBuri._input.x) + Mathf.Abs(_moveBuri._input.y);
            _moveBuri._variacaoAltura = _moveBuri._controller.velocity.y;
            _moveBuri._checkGround = _moveBuri._controller.isGrounded;
            _moveBuri._checkMover = true;
            _moveBuri._buriTriguer.GetComponent<CapsuleCollider>().enabled = true;
            _player.SetParent(null);
            _player.transform.localEulerAngles = new Vector3(0, 0, 0);
            _player.transform.position = _buriPosSpawn.position;
            //_moveBuri = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _moveBuri = other.GetComponent<MoveControl>(); 
        }
        if (other.gameObject.CompareTag("AtracaCanoa"))
        {
            Debug.Log("Atracou");
            _utilizandoCanoa = false; 
            _atracouCanoa = true;
            _atracaCanoa = other.GetComponent<AtracaCanoa>();
            _buriPosSpawn = _atracaCanoa._buriDePeAqui;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _moveBuri = null;
            _atracaCanoa = null;
        }
    }
}
