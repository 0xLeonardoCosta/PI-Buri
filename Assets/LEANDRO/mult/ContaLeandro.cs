using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContaLeandro : MonoBehaviour
{
    public int _numb1;
    public int _numb2;
    public int _resp;

    public string _conta;
    public TextMeshPro _textResp;
    public GameContaControlLenadro _contaControl;
    




    // Start is called before the first frame update
    void Start()
    {
        _resp = _numb1 + _numb2;
        ContaSetLeandro("?");
        

      // _contaControl = Camera.main.GetComponent<GameContaControlLenadro>();
       float r = Random.Range(0.2f, 0.5f);
       Invoke("NunbEnviar", r);
        
    }

    public void ContaSetLeandro(string conta)
    {
        _conta = _numb1 + " + " + _numb2 + " = " + conta;
        _textResp.text = _conta;
    }

    void NunbEnviar()
    {
        _contaControl._respList.Add(_resp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
