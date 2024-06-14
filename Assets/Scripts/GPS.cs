using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public Transform _miniMapaCam;
    public float _minimapSize;
    public Vector3 _tempV3;
    public GaaameController _controller;

    void Start()
    {
        _controller = Camera.main.GetComponent<GaaameController>();
        _miniMapaCam = _controller._miniCam;
    }

    void Update()
    {

        _tempV3 = transform.parent.transform.position;
        _tempV3.y = transform.position.y;
        transform.position = _tempV3;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, _miniMapaCam.position.x - _minimapSize, _minimapSize + _miniMapaCam.position.x), transform.position.y,
        Mathf.Clamp(transform.position.z, _miniMapaCam.position.z - _minimapSize, _minimapSize + _miniMapaCam.position.z));
    }
}
