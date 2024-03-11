using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPuraque : MonoBehaviour
{
    
    public GameObject _partShock;
    public GameObject _meshRenderer;
    

    public Collider _collider;
    Transform _transform;



    private void Start()
    {

        
        //_meshRenderer = GetComponent<GameObject>();
        //_collider = GetComponent<Collider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TaEmChockBuri());

        }
        
    }

    IEnumerator TaEmChockBuri()
    {
        
        yield return new WaitForSeconds(1);
        _partShock.SetActive(true);
    }
}
