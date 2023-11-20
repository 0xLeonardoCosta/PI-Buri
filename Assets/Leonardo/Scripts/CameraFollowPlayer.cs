using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Vector2 _inputCamera;
    [SerializeField] float smoothing = 5f;
    [SerializeField] float _rotY;
    [SerializeField] float _speed;

    void Start()
    {

    }

    void Update()
    {
        CameraControl();
    }
    void CameraControl()
    {
        _rotY += Time.deltaTime * _speed * 100;
        _rotY -= Time.deltaTime * _speed * 100;
        _rotY = Mathf.Clamp(_rotY, 0, 45);
        transform.localRotation = Quaternion.Euler(0, 0, _rotY);
    }
    public void SetCameraControl(InputAction.CallbackContext value) //Input direcional X e Z (Input System)
    {
        _inputCamera = value.ReadValue<Vector2>();
    }
}
