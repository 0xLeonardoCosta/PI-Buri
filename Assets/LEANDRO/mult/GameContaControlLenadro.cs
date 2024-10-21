using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContaControlLenadro : MonoBehaviour
{
    public List<int> _respList;
    public List<bloboNumero> _bloboNumeroList;
    // Start is called before the first frame update

    private void Start()
    {
        Invoke("SetblocoNumber", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
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
