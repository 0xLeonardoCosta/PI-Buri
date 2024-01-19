using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitInimigos : MonoBehaviour
{
    MoveLixo _moveLixo;
    public GameObject _partMorte;
    public GameObject _partRestart;
    public GameObject _meshRenderer;
    public GameObject _porreteMesh;

    public Collider _collider;
    Transform _transform;



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
           
        }
        if (other.gameObject.CompareTag("BuriTriguuer"))
        {
            other.GetComponent<TargetLocation>()._targetList.Add(transform);
            _transform = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BuriTriguuer"))
        {
            other.GetComponent<TargetLocation>()._targetList.Remove(transform);
            _transform = other.transform;

        }
    }




    IEnumerator Morte()
    {
        _transform.GetComponent<TargetLocation>()._targetList.Remove(transform);
        _moveLixo._checkMove = false;
        _partRestart.SetActive(true);
        _meshRenderer.gameObject.SetActive(false);
        _collider.enabled = false;
        Camera.main.GetComponent<GaaameController>()._player.GetComponent<MoveControl>()._targetLocation._targetList.Remove(transform.parent);
        _moveLixo._checkMorte = true;
        yield return new WaitForSeconds(1);
        _porreteMesh.SetActive(false);
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
