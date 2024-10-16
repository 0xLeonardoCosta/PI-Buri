using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlocoNumero : MonoBehaviour
{
    public TextMeshPro _textBloco;
    public int _numeroBloco;
    void Start()
    {
        _textBloco.text = "" + _numeroBloco;
    }

    void Update()
    {
        
    }
}
