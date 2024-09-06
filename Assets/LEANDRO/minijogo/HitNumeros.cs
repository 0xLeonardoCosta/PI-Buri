using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumeros : projetil
{

    public int _resultado;
    public ParticleSystem _particula;



   public MiniGameController _controller;

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _controller = Camera.main.GetComponent<MiniGameController>();
        if (collision.gameObject.CompareTag("bala2d"))
        {
           // StartCoroutine(DestruirTime());

            if(_resultado == _miniGameController._resultadoContaReal)
            {
                Debug.Log("Certo");
            
                StartCoroutine(DestruirTimeCerto());
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
//PartSaida.SetActive(true);
        PartSaida.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

    IEnumerator DestruirTimeCerto()
    {
        _miniGameController.ChamarQuest();
        Textura.enabled = false;
        PartSaida.GetComponent<ParticleSystem>().Play();
        _controller._scoreAcerto++;
        yield return new WaitForSeconds(3f);
     
        gameObject.SetActive(false);
    }

}
