using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class ItemDestaque : MonoBehaviour
{
    [SerializeField] float _speedRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _speedRotation * Time.deltaTime, 0);
    }
}
