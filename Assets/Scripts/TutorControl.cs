using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorControl : MonoBehaviour
{

    [SerializeField] string[] _textTutor;
    [SerializeField]TextMeshProUGUI _textPro;
    [SerializeField] Transform _panelTutor;

    [SerializeField] public int valor;

    // Start is called before the first frame update
    void Start()
    {
        //TextTutorOM(valor);
    }

    // Update is called once per frame
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
       
    }
}
