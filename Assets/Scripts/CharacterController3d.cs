using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController3d : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _moveH;
    [SerializeField] float _moveZ;
    [SerializeField] float _jumpforce;
    [SerializeField] float _forceGravity = -9.81f;
    [SerializeField] float _velocidade;
    [SerializeField] float _girarSpeed;
    [SerializeField] float _rot;
    [SerializeField] bool _isGrounded;

    Vector3 _playerVelocity;


    // Start is called before the first frame update
    void andar()
    {
        //_characterController.Move(new Vector3(0, 0, 0) * Time.deltaTime);
        _characterController.Move(transform.forward * _velocidade *_moveZ * Time.deltaTime);
        //_characterController.Move(Vector3.right * _velocidade * _moveH * Time.deltaTime);



        _moveH = Input.GetAxisRaw("Horizontal");
        _moveZ = Input.GetAxisRaw("Vertical");
    }
    void GravityMode()
    {
        _playerVelocity.y = _playerVelocity.y + _forceGravity * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    void jump()
    {
        _playerVelocity.y += Mathf.Sqrt(_jumpforce * -3.0f * _forceGravity);
    }

    void RotationPlayer() // girar com cinemachine // _girarSpeed tem que estar 1
    {
        _rot = _rot - Input.GetAxis("Horizontal") * _girarSpeed;
        transform.localEulerAngles = new Vector3(0.0f, -_rot, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        andar();

        if (_characterController.isGrounded == false)
        {
            GravityMode();
        }
        if (Input.GetAxisRaw("Jump")>0 &&_characterController.isGrounded)
        {
            jump();
        }

        RotationPlayer();
    }
}
