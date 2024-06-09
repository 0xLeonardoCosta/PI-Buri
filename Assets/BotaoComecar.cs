using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoComecar : MonoBehaviour
{
    [SerializeField] GameObject _telaPainelCor, _letreiro;
    [SerializeField] Transform _pos;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Clicou()
    {
        StartCoroutine("Animacao", 0f);
    }
    IEnumerator Animacao()
    {
        _telaPainelCor.GetComponent<Image>().DOFade(0, 1f);
        _letreiro.GetComponent<Transform>().DOMove(_pos.position, 0.5f);
        yield return null;
    }
}
