using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudGames : MonoBehaviour
{
    [SerializeField] Image[] _iconVida;
    [SerializeField] Transform _telaGameOver;
    
    [SerializeField] GameObject _vidaGrupo;
    [SerializeField] GameObject _baixoGrupo;
    [SerializeField] GameObject _stamina;
    [SerializeField] GameObject _pos;
    [SerializeField] GameObject _pos1;
    [SerializeField] GameObject _pos2;
    public int vida;
    void Start()
    {
       // _iconVida[2].DOScale(0, 0.5f);
    }

    public void RecebeuDano()
    {
        vida--;
        Debug.Log("PerdeuVida");
        CheckIconVida(vida);
        //StartCoroutine(TimeHit());
    }

    public void CheckIconVida(int vida)
    {
        if (vida == 0)
        {
            _iconVida[0].DOFade(0, 0.5f);
            //Chamar tela GameOver
            _telaGameOver.DOScale(0.35f, 0.5f);
            _vidaGrupo.transform.DOMove(_pos.transform.position, 0.1f);
            _baixoGrupo.transform.DOMove(_pos1.transform.position, 0.25f);
            _stamina.transform.DOMove(_pos2.transform.position, 0.05f);
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
    /*IEnumerator TimeHit()
    {
        //yield return new WaitForSeconds(.25f);
        _corPanelHit.DOColor(_cor[0], 0.25f);
        yield return new WaitForSeconds(1f);
        _corPanelHit.DOColor(_cor[1], 0.25f);
        yield return new WaitForSeconds(.1f);
    }*/
}
