using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumeros : projetil
{
   public override void DestroyItem()
    {

    }

    IEnumerable DestruirTime()
    {
        Textura.enabled = false;
        PartSaida.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

}
