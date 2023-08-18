using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class LucasMoveControl : MonoBehaviour
{
    private Vector2 _input; //Input system, axis: X,Z. 
    private Vector3 _playerVelocity;
    private Vector3 _movement;

    private CharacterController _controller;
    private Animator _anim;

    [SerializeField] bool _checkGround; //Verificador se o player está encostando no chão

    private float _gravityValue = -9.81f;
    private float _gravityMultiplier;
    [SerializeField] float _speed = 5;
    [SerializeField] float _speedRotation = 15;
    private float _timerValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AndarN()// Sincronizar animações - Andar movimento de perna/Andar movimento de braço
    {
        _anim.SetLayerWeight(0, 1); //perna
        _anim.SetLayerWeight(1, 1); //braco
    }
    void Move()
    {
        _movement = new Vector3(_input.x, _controller.velocity.y, _input.y).normalized * _speed * Time.deltaTime;
        _controller.Move(_movement);
        // Linhas abaixo feitas para animação do personagem
        float _andar = Mathf.Abs(_input.x) + Mathf.Abs(_input.y);

        _anim.SetFloat("Andar", _andar);
        _anim.SetFloat("VelocidadeY", _controller.velocity.y);
        _anim.SetBool("groundCheck", _checkGround);
    }
    void LookAtMovementDirection() //Script para virar a frente do personagem voltada a orientação do movimento
    {
        if (_input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedRotation * Time.deltaTime);
        }
    }
