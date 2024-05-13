using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumeros : projetil
{




    /*public override void DestroyItem()
    {
        StartCoroutine(DestruirTime());
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala2d"))
        {
            StartCoroutine(DestruirTime());
        }
    }

    IEnumerator DestruirTime()
    {
        Debug.Log("tá beleza ENTÃO");
        Textura.enabled = false;
        PartSaida.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

}
