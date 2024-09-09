using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PaineisIntroducao : MonoBehaviour
{
    [SerializeField] GameObject _telaPainelCor, _painelLiso1, _letreiroPainel;

    [SerializeField] GameObject _telaControle, _painelLiso2, _letreiroControle;

    [SerializeField] GameObject _telaMapa, _painelLiso3, _letreiroMapa;

    [SerializeField] Transform _pos;

    [SerializeField] Button[] _bts;

    void Start()
    {

    }


    void Update()
    {

    }
    public void Clicou1()
    {
        StartCoroutine("Animacao1", 0f);
        _telaControle.SetActive(true);
        _painelLiso1.SetActive(false);
        _bts[1].Select();
    }
    public void Clicou2()
    {
        StartCoroutine("Animacao2", 0f);
        _telaMapa.SetActive(true);
        _painelLiso2.SetActive(false);
        _bts[2].Select();
    }
    public void Clicou3()
    {
        StartCoroutine("Animacao3", 0f);
        _painelLiso3.SetActive(false);
    }
    IEnumerator Animacao1()
    {
        _telaPainelCor.GetComponent<Image>().DOFade(0, 1f);
        _letreiroPainel.GetComponent<Transform>().DOMove(_pos.position, 0.5f);
        yield return null;
    }
    IEnumerator Animacao2()
    {
        _telaControle.GetComponent<Image>().DOFade(0, 1f);
        _letreiroControle.GetComponent<Transform>().DOMove(_pos.position, 0.5f);
        yield return null;
    }
    IEnumerator Animacao3()
    {
        _telaMapa.GetComponent<Image>().DOFade(0, 1f);
        _letreiroMapa.GetComponent<Transform>().DOMove(_pos.position, 0.5f);
        yield return null;
    }
}
