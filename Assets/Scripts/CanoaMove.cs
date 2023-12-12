using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoaMove : MonoBehaviour
{
    MoveControl _moveBuri;
    GaaameController _controller;

    Transform _player;


    void Start()
    {
        _moveBuri = GetComponent<MoveControl>();
        _player = _controller._player;
    }

    
    void Update()
    {
        
    }
}
