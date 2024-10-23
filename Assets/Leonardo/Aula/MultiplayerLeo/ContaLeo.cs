using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContaLeo : MonoBehaviour
{
    public int _numb1, _numb2, _resp;
    public string _conta;
    public TextMeshPro _textResp;
    GameContaControlLeo _contaControl;
    void Start()
    {
        _resp = _numb1 + _numb2;
        ContaSet("?");
       

        _contaControl = Camera.main.GetComponent<GameContaControlLeo>();
        
        float r = Random.Range(0.2f, 0.5f);
        Invoke("NumbEnviar", r);
    }

    public void ContaSet(string conta)
    {
        _conta = _numb1 + " + " + _numb2 + " = " + conta;
        _textResp.text = _conta;
    }

    void NumbEnviar()
    {
        _contaControl._respList.Add(_resp);
    }
}
