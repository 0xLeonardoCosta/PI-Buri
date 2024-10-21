using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContaControlLuska : MonoBehaviour
{
    public List<int> _respList;
    public List<bloboNumeroLuska> _bloboNumeroList;
    void Start()
    {
        Invoke("SetblocoNumber", 1);
    }

    public void SetblocoNumber()
    {
        for(int i = 0; i < _bloboNumeroList.Count; i++)
        {
            _bloboNumeroList[i]._numeroBloco = _respList[i];
            _bloboNumeroList[i]._textBloco.text = "" + _respList[i];
        }
    }
}
