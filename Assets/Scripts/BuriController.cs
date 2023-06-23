using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuriController : MonoBehaviour
{
    [SerializeField] CharacterController _controller;

    [SerializeField] Vector3 _posicao;

    [SerializeField] float _jumpForce;
    [SerializeField] float _forceGravity;
    [SerializeField] float _velocidade;
    [SerializeField] float _speedAnim;
    [SerializeField] float _speedY;
    [SerializeField] float _girarSpeed;
    [SerializeField] float _rot;

    [SerializeField] Animator _anim;
    [SerializeField] Vector3 _moveDirection;
    

    [SerializeField] bool _isGrounded;

    void Start()
    {
        _controller = GetComponent<CharacterController>( );
    }

    void Update()
    {
        //_posicao = transform.position;
        Mover();
        if (_controller.isGrounded)
        {
            Pular();
        }
        if (_controller.isGrounded == false)
        {
            Gravity();
        }
        //Atirar();
        //Trepar();
        girar();
    }

    void Mover()
    {
      //  float _moveH = Input.GetAxisRaw("Horizontal");
        float _moveV = Input.GetAxisRaw("Vertical");

      //  _controller.Move(Vector3.right * _moveH * _velocidade * Time.deltaTime);
        _controller.Move(transform.forward * _moveV * _velocidade * Time.deltaTime);

      //  float _horizontalmoveH = Input.GetAxisRaw("Horizontal");
        float _verticalalmoveZ = Input.GetAxisRaw("Vertical");
       // _moveDirection = new Vector3(_horizontalmoveH, 0);
        _moveDirection = new Vector3 (_moveDirection.x * _velocidade, _moveDirection.y);

        _speedY = _moveDirection.y;
        _speedAnim = Mathf.Abs(_moveV);
        _anim.SetFloat("Andar", _speedAnim);
       // _anim.SetFloat("VelocidadeY", _speedY);
       // _anim.SetBool("groundCheck", _isGrounded);

        
    }

    void Pular()
    {
        bool _space = Input.GetButton("Jump");
        if (_space == true) //&& _isGrounded)
        {
            _posicao.y += Mathf.Sqrt(_jumpForce * -3.0f *_forceGravity);
        }
        else if (_space == false) //&& _isGrounded)
        {
            Debug.Log("CanJump");
        }
    }
    void Gravity()
    {
        _posicao.y += _forceGravity * Time.deltaTime;
        _controller.Move(_posicao * Time.deltaTime);
    }

    void girar()
    {
        _rot -= Input.GetAxis("Horizontal") * _girarSpeed;
        transform.localEulerAngles = new Vector3(0, -_rot, 0);
    }

}