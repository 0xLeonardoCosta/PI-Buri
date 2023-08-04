using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Testttttt : MonoBehaviour
{
    [SerializeField] CharacterController _controller;

    [SerializeField] float _jumpForce;
    [SerializeField] float _forceGravity = -9.81f;
    [SerializeField] float _velocidade;
    [SerializeField] float _andarAnim;
    [SerializeField] float _speedY;
    [SerializeField] float _girarSpeed;
    [SerializeField] float _rot;
    [SerializeField] float _jumpHeight;
    [SerializeField] float _multiplicadorGravidade;

    private bool _rotacao;

    [SerializeField] Animator _anim;
    [SerializeField] Vector3 _moveDirection;
    [SerializeField] Vector3 _posicao;
    [SerializeField] Rigidbody _rb;

    [SerializeField] bool _isGrounded;


    void Start()
    {
        AndarN();
    }

    void Update()
    {
        _isGrounded = _controller.isGrounded;
        
        Mover();
        Gravity();
        jump();
        girar();
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        Vector3 m = value.ReadValue<Vector3>();
        _moveDirection.x = m.x;
        _moveDirection.z = m.y;
    }

    void AndarN()//andando normal
    {
        _anim.SetLayerWeight(0, 1); //perna
        _anim.SetLayerWeight(1, 1); //braco
    }

    void Mover()
    {
        //float _moveV = Input.GetAxisRaw("Vertical");
        //float _moveH = Input.GetAxisRaw("Horizontal");

        _controller.Move(new Vector3(_moveDirection.x * _velocidade, _controller.velocity.y, _moveDirection.z * _velocidade) * Time.deltaTime);
        //_controller.Move((transform.right * _moveH) * _velocidade * Time.deltaTime);
        //_controller.Move((transform.forward * _moveV) * _velocidade * Time.deltaTime);

        _speedY = _moveDirection.y;
        _andarAnim = Mathf.Abs (_moveDirection.x) + Mathf.Abs(_moveDirection.z);
        _anim.SetFloat("Andar", _andarAnim);
        _anim.SetFloat("VelocidadeY", _controller.velocity.y);

        _anim.SetBool("groundCheck", _isGrounded);

        if (Mathf.Abs(_moveDirection.x) > 0 && _rotacao)
        {
            Flip();
        }
        else if (Mathf.Abs(_moveDirection.z) > 0 && _rotacao)
        {
            Flip();
        }
    }

    void jump()
    {

        if (Input.GetAxisRaw("Jump") > 0 && _isGrounded == true)
        {
            Debug.Log(_moveDirection.y);
            _moveDirection.y += Mathf.Sqrt(_jumpHeight * -3.0f * _forceGravity);
        }

        _anim.SetFloat("VelocidadeY", _rb.velocity.y);
    }

    void Gravity()
    {
        _moveDirection.y = _moveDirection.y + _forceGravity * Time.deltaTime * _multiplicadorGravidade;
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    void girar()
    {
        _rot -= Input.GetAxis("Horizontal") * _girarSpeed;
        transform.localEulerAngles = new Vector3(0, -_rot, 0);
    }

    void Flip()
    {
        _rotacao = !_rotacao;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
        
}
