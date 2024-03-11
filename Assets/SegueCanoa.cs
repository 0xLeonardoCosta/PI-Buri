using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SegueCanoa : MonoBehaviour
{
    [SerializeField] Transform _canoa;
    [SerializeField] float _alturaCanoa;
    
    void Update()
    {
        transform.position = new Vector3(_canoa.position.x, _canoa.position.y - _alturaCanoa, _canoa.position.z);
        transform.localRotation = new Quaternion(_canoa.rotation.x, _canoa.rotation.z, _canoa.rotation.y, _canoa.rotation.w);
    }
}