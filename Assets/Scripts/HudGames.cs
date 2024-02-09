using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudGames : MonoBehaviour
{
    [SerializeField] Image[] _iconVida;
    int vida;
    void Start()
    {
       // _iconVida[2].DOScale(0, 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {

        vida--;
        CheckIconVida(vida);
    }

    public void CheckIconVida(int vida)
    {
        if (vida == 0)
        {
            _iconVida[0].DOFade(0, 0.5f);
            //Chamar tela GameOver
        }
        else if (vida == 1)
        {
           _iconVida[1].DOFade(0, 0.5f);
        }
        else if (vida == 2)
        {
            _iconVida[2].DOFade(0, 0.5f);
        }
        else if (vida == 3)
        {
            _iconVida[3].DOFade(0, 0.5f);
        }
        else if (vida == 4)
        {
           _iconVida[4].DOFade(0, 0.5f);
        }
        else if (vida == 5)
        {
           _iconVida[5].DOFade(0, 0.5f);
        }

    }
}
