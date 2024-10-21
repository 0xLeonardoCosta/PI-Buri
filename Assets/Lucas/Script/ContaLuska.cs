using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContaLuska : MonoBehaviour
{
    public int _numb1;
    public int _numb2;
    public int _resp;

    public string _conta;
    public TextMeshPro _textResp;
    public GameContaControlLuska _contaControl;
    void Start()
    {
        _resp = _numb1 + _numb2;
        ContaSetLuska("?");

        //_contaControl= Camera.main.GetComponent<GameContaControlLuska>();

        float r = Random.Range(0.2f, 0.5f);
        Invoke("NumbEnviar", r);
    }
     public void ContaSetLuska(string conta)
    {
        _conta = _numb1 + " + " + _numb2 + " = " + conta;
        _textResp.text = _conta;
    }
  void NumbEnviar()
    {
        _contaControl._respList.Add(_resp);
    }
}
