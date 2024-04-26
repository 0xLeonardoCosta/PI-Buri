using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumeros : Item2D
{
    public override void DestroyItem()
    {
        StartCoroutine(DestruirTime());
    }

    IEnumerator DestruirTime()
    {
        Debug.Log("tomaaaaaa");
        Textura.enabled = false;
        PartSaida.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

}
