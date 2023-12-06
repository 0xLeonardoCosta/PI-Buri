using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Ball : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] GaaameController _controller;
    void Start()
    {
        _controller = Camera.main.GetComponent<GaaameController>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    public void Lancar()
    {
        transform.position = _controller._playerArm.position;
        transform.eulerAngles = new Vector3(0, 0, 0);
        _rb.velocity= new Vector3(0, 0, 0);

        _rb.AddForce(_controller._player.transform.forward * 24, ForceMode.Impulse);
    }
}
