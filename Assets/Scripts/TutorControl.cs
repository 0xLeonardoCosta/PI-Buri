using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorControl : MonoBehaviour
{

    [SerializeField] string[] _textTutor;
    [SerializeField]TextMeshProUGUI _textPro;
    [SerializeField] Transform _panelTutor;
    [SerializeField] public GameObject _spriteExclamatIVO;
    
    [SerializeField] bool minimizado = true;
    [SerializeField] public int valor;

    void Start()
    {
        //TextTutorOM(valor);
    }

    void Update()
    {

    }
    
    public void TextTutorOM(int value)
    {
        _panelTutor.localScale = Vector3.zero;
        _panelTutor.DOScale(1, .25f);
        _textPro.text = "" + _textTutor[value];
    }
    public void TextTutoOFF()
    {
        _panelTutor.DOScale(0, .25f);
        _spriteExclamatIVO.SetActive(true);
        minimizado = true;
    }
    public void MinimizarTutorial()
    {
        if (minimizado == true)
        {
            _panelTutor.DOScale(1, .25f);
            _spriteExclamatIVO.SetActive(false);
            minimizado = false;
        }
        else
        {
            _panelTutor.DOScale(0, .25f);
            minimizado = true;
        }
        //_panelTutor.DOScale(0, .25f);
    }
}
