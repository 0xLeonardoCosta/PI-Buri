using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuriController : MonoBehaviour
{
    [SerializeField] CharacterController _controller;

    [SerializeField] Vector3 _posicao;

    [SerializeField] float _jumpForce;
    [SerializeField] float _forceGravity;
    [SerializeField] float _velocidade;

    [SerializeField] bool _isGrounded;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
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
    }

    void Mover()
    {
        float _moveH = Input.GetAxisRaw("Horizontal");
        float _moveV = Input.GetAxisRaw("Vertical");

        _controller.Move(Vector3.right * _moveH * _velocidade * Time.deltaTime);
        _controller.Move(Vector3.forward * _moveV * _velocidade * Time.deltaTime);
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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            Debug.Log(collision.gameObject.tag);
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}