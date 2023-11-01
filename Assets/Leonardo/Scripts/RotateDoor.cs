using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public float _rotZ, _speed;
    public bool _girarZ, _isOpen;

    void Update()
    {
        if (_girarZ && !_isOpen)
        {
            AbrirPorta();
            _rotZ = Mathf.Clamp(_rotZ, 0, 110);
            transform.localRotation = Quaternion.Euler(0, 0, _rotZ);
        }
        else if (_girarZ && _isOpen)
        {
            FecharPorta();
            _rotZ = Mathf.Clamp(_rotZ, 0, 110);
            transform.localRotation = Quaternion.Euler(0, 0, _rotZ);
        }
        
    }
    void AbrirPorta()
    {
            _rotZ += Time.deltaTime * _speed * 100;
            
            if (_rotZ >= 110)
            {
                _girarZ = false;
                _isOpen = true;
            }
    }
    void FecharPorta()
    {
        _rotZ -= Time.deltaTime * _speed * 100;

        if (_rotZ <= 0)
        {
            _girarZ = false;
            _isOpen = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                _girarZ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _girarZ = false;
        }
    }
}