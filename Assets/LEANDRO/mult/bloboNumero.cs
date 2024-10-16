using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bloboNumero : MonoBehaviour
{

    public TextMeshPro _textBloco;
    public int _numeroBloco;
    // Start is called before the first frame update
    void Start()
    {
        _textBloco.text = "" + _numeroBloco;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
