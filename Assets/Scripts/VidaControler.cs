using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaControler : MonoBehaviour
{
    [SerializeField] List<GameObject> _slotVida;
    [SerializeField] Transform[] _imagemVida;
    public bool _checkHit;
    float _tamV;
    //0 = 1 vida, 1 = 2 vidas e etc...

    public int _vidaMaxima;
    public int _vidaAtual;
    public int _valorAnterior;
    public Color[] _cor;
    public Image _corPanel;


    void Start()
    {
        
        
        _tamV = _imagemVida[0].localScale.x;
    }

    
    void Update()
    {
        
    }

    void VidaCheck(int Vida)
    {
        if (Vida == 0)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }

        if (Vida == 1)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }

        else if (Vida == 2)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }

        else if (Vida == 3)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }

        else if (Vida == 4)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }

        else if (Vida == 5)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }

        else if (Vida == 6)
        {
            _imagemVida[0].DOScale(0, 0.5f);
            _imagemVida[1].DOScale(0, 0.5f);
            _imagemVida[2].DOScale(0, 0.5f);
            _imagemVida[3].DOScale(0, 0.5f);
            _imagemVida[4].DOScale(0, 0.5f);
            _imagemVida[5].DOScale(0, 0.5f);
            _imagemVida[6].DOScale(0, 0.5f);
        }
        
        
        
        
        
        
    }

    public void RecebeuDano()
    {
        if (!_checkHit)
        {

            _checkHit = true;
            _vidaAtual--;
            VidaCheck(_vidaAtual);
            //Invoke("TimeHit", 1);
        }
    }

    public void GanhouVida()
    {
        _vidaAtual ++;
        VidaCheck(_vidaAtual);
    }

    IEnumerator TimeHit()
    {
        //yield return new WaitForSeconds(.25f);
        _corPanel.DOColor(_cor[0], 0.25f);
        yield return new WaitForSeconds(1f);
        _corPanel.DOColor(_cor[1], 0.25f);
        yield return new WaitForSeconds(.1f);
    }
    /*IEnumerator TimeHit()
    {
        yield return new WaitForSeconds(.25f);
        _corPanel.DOColor(_cor[0], 0.25f);
        yield return new WaitForSeconds(.25f);
        _corPanel.DOColor(_cor[1], 0.25f);
        yield return new WaitForSeconds(.1f);
    }*/
}
