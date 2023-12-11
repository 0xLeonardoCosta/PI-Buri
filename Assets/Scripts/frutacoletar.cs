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
        _partColetar.SetActive(false);
        gameObject.SetActive(false);
        
    }

    IEnumerator RestartTime2 ()
    {
        yield return new WaitForSeconds(1);
        _meshRenderer.enabled = true;
        _collider.enabled = true;
        yield return new WaitForSeconds(0.5f);


    }

    public void Restart2 ()
    {
        StartCoroutine (RestartTime2());
    }
}
