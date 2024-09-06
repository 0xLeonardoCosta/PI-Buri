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
    [SerializeField] GameObject _baixoMeio;
    [SerializeField] GameObject _btInventario;

    [SerializeField] bool minimizado = true;
    [SerializeField] public int valor;
    [SerializeField] Transform _posMiniInventario;
    [SerializeField] Transform _posMiniInventarioOrigin;
    [SerializeField] Transform _posBtMenuInventario;
    [SerializeField] Transform _posBtMenuInventarioOrigin;



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
        _baixoMeio.SetActive(false);
        _btInventario.SetActive(false);

    }
    public void TextTutoOFF()
    {
        _panelTutor.DOScale(0, .25f);
        _spriteExclamatIVO.SetActive(true);
        minimizado = true;
        _baixoMeio.SetActive(true);
        _btInventario.SetActive(true);

    }
    public void MinimizarTutorial()
    {
        if (minimizado == true)
        {
            _panelTutor.DOScale(1, .25f);
            _spriteExclamatIVO.SetActive(false);
            minimizado = false;
            _baixoMeio.SetActive(false);
            _btInventario.SetActive(false);
        }
        else
        {
            _panelTutor.DOScale(0, .25f);
            minimizado = true;
            _baixoMeio.SetActive(true);
            _btInventario.SetActive(true);

        }
        //_panelTutor.DOScale(0, .25f);
    }
}
