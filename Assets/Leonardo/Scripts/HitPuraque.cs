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
        _transform.GetComponent<TargetLocation>()._targetList.Remove(transform);

        _collider.enabled = true;
       Camera.main.GetComponent<GaaameController>()._player.GetComponent<MoveControl>()._targetLocation._targetList.Remove(transform.parent);
        yield return new WaitForSeconds(1);
        _partShock.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);


    }

}
