using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumeros : projetil
{

    public int _resultado;
   


    /*public override void DestroyItem()
    {
        StartCoroutine(DestruirTime());
    }*/



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala2d"))
        {
           // StartCoroutine(DestruirTime());

            if(_resultado == _miniGameController._resultadoContaReal)
            {
                Debug.Log("Certo");
                _miniGameController.ChamarQuest();
               // StartCoroutine(DestruirTimeCerto());
            }
            else
            {
                Debug.Log("Errado");
                StartCoroutine(DestruirTimeErrado());
            }
        }

        
    }

    IEnumerator DestruirTimeErrado()
    {
       
        Textura.enabled = false;
        PartSaida.SetActive(true);
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

    IEnumerator DestruirTimeCerto()
    {

        Textura.enabled = false;
        PartSaida.SetActive(true);
        _miniGameController.ChamarQuest();
        yield return new WaitForSeconds(3f);
     
        gameObject.SetActive(false);
    }

}
