using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Maresia : MonoBehaviour
{
    private Transform _player;

    private void Start()
    {
        _player = Camera.main.GetComponent<GaaameController>()._player;
        transform.position = new Vector3 (_player.position.x, _player.position.y -0.50f, _player.position.z);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y - 0.5f, _player.position.z);  
    }
}

