using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conta : MonoBehaviour
{
    public int _resultadoConta;
    MiniGameController miniGameController;

    void Start()
    {
        miniGameController = Camera.main.GetComponent<MiniGameController>();
        miniGameController._resultadoContaReal = _resultadoConta;
    }

    // Update is called once per frame
  
}
