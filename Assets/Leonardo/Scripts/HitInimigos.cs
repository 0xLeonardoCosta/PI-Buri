using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitInimigos : MonoBehaviour
{
    MoveLixo _moveLixo;
    public GameObject _partMorte;
    public GameObject _partRestart;
    public GameObject _meshRenderer;
    public Collider _collider;



    private void Start()
    {

        _moveLixo = GetComponent<MoveLixo>();
       //_meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaquePlayer"))
        {
            StartCoroutine(Morte());
            Debug.Log("aaaaaa");
        }
    }

   

    IEnumerator Morte()
    {
        _moveLixo._checkMove = false;
        _partRestart.SetActive(true);
        _meshRenderer.gameObject.SetActive(false);
        _collider.enabled = false;
        _moveLixo._checkMorte = true;
        yield return new WaitForSeconds(1);
        _partMorte.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    IEnumerator RestartTime()
    {
        _partRestart.SetActive(true);   
        yield return new WaitForSeconds(1);
        _meshRenderer.gameObject.SetActive(true);
        _collider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _moveLixo._checkMove = true;
        _moveLixo._checkMorte = true;

    }

    public void Restart ()
    {
        StartCoroutine(RestartTime());
    }
}
