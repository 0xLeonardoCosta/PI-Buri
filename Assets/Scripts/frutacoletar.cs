using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class frutacoletar : MonoBehaviour
{
    public GameObject _partColetar;
    public MeshRenderer _meshRenderer;
    public Collider _collider;


    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("frutacoletar"))
        {
            StartCoroutine(Coletar());
        }
    }

    IEnumerator Coletar ()
    {
        _partColetar.SetActive(true);
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        
    }

    void Restart ()
    {

    }
}
