using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Janocamove : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _anim;

    public float speed;
    public float _gravity;
    public float _rotSpeed;

    private float _rot;
    private Vector3 _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (_controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _moveDirection = Vector3.forward * speed;
                _anim.SetInteger("Andando", 1);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _moveDirection = Vector3.zero;
                _anim.SetInteger("Andando", 0);
            }
        }


        _rot += Input.GetAxis("Horizontal") * _rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, _rot, 0);

        _moveDirection.y -= _gravity * Time.deltaTime;
        _moveDirection = transform.TransformDirection(_moveDirection);

        _controller.Move(_moveDirection);
    }
}
