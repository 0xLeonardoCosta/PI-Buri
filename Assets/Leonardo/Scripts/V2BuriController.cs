using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class V2BuriController : MonoBehaviour
{

    [SerializeField] CharacterController _controller;

    [SerializeField] float _jumpForce;
    [SerializeField] float _forceGravity = -9.81f;
    [SerializeField] float _velocidade;
    [SerializeField] float _speedAnim;
    [SerializeField] float _speedY;
    [SerializeField] float _girarSpeed;
    [SerializeField] float _rot;
    [SerializeField] float _jumpHeight;

    [SerializeField] Animator _anim;
    [SerializeField] Vector3 _moveDirection;
    [SerializeField] Vector3 _posicao;
    [SerializeField] Rigidbody _rb;


    [SerializeField] bool _isGrounded;
    

    void Start()
    {
        _controller = GetComponent<CharacterController>( );
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _isGrounded = _controller.isGrounded;
        Mover();
        Gravity();
        jump();
        //girar();

        if (Input.GetKey(KeyCode.Alpha1))
        {
            _velocidade = 10f;
            _anim.SetLayerWeight(0, 0); //correndo
            _anim.SetLayerWeight(1, 1); //andando
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _velocidade = 5f;
            _anim.SetLayerWeight(0, 0); //correndo
            _anim.SetLayerWeight(1, 0); //andando
        }


    }

    void Mover()
    {
        //  float _moveH = Input.GetAxisRaw("Horizontal");
        // float _moveV = Input.GetAxisRaw("Vertical");

        //  _controller.Move(Vector3.right * _moveH * _velocidade * Time.deltaTime);
        // _controller.Move(transform.forward * _moveV * _velocidade * Time.deltaTime);

        //  float _horizontalmoveH = Input.GetAxisRaw("Horizontal");
        //float _verticalalmoveZ = Input.GetAxisRaw("Vertical");
        // _moveDirection = new Vector3(_horizontalmoveH, 0);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * _velocidade);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        _moveDirection = new Vector3 (_moveDirection.x * _velocidade, _moveDirection.y);

        float movimento = transform.forward.x;
        Debug.Log(movimento);

        _speedY = _moveDirection.y;
        _speedAnim = movimento;
        //_speedAnim = move;
        _anim.SetFloat("Andar", _speedAnim);
        _anim.SetFloat("VelocidadeY", _speedY);
        _anim.SetBool("groundCheck", _isGrounded);


    }

    void jump()
    {
       
        if (Input.GetAxisRaw("Jump") > 0 && _isGrounded == true)
        {
            Debug.Log(_moveDirection.y);
            _moveDirection.y += Mathf.Sqrt(_jumpHeight * -3.0f * _forceGravity);
        }
       
        _anim.SetFloat("Pular", _rb.velocity.y);

    }

    void Gravity()
    {
        _moveDirection.y = _moveDirection.y + _forceGravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    void girar()
    {
        _rot -= Input.GetAxis("Horizontal") * _girarSpeed;
        transform.localEulerAngles = new Vector3(0, -_rot, 0);
    }

}