using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesligarTelhado : MonoBehaviour
{
    public GameObject _telhado;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _telhado.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _telhado.SetActive(true);
        }
    }
}
