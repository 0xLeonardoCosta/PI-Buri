using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Ball : MonoBehaviour
{
    Rigidbody _rb;
    private CanoaMove CanoaMove;
    [SerializeField] GaaameController _controller;
    [SerializeField] private float _velocityProjetil;
    CanoaMove _canoaMove;
    void Start()
    {
        CanoaMove = Camera.main.GetComponent<GaaameController>()._canoa.GetComponent<CanoaMove>();
        _controller = Camera.main.GetComponent<GaaameController>();
        _rb = GetComponent<Rigidbody>();
    }


    public void Lancar()
    {
        if (CanoaMove.coletouBaladeira == true || _controller._player.GetComponent<MoveControl>()._coletouBaladeira == true) 
        {
            Debug.Log("Lançou");
            transform.position = _controller._playerArm.position;
            transform.eulerAngles = new Vector3(0, 0, 0);
            _rb.velocity = new Vector3(0, 0, 0);

            _rb.AddForce(_controller._player.transform.forward * _velocityProjetil, ForceMode.Impulse);
        }
    }
}
