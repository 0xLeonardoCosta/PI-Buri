using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BTCorrer : MonoBehaviour
{
    [SerializeField] Sprite _btPressionado, _btNaoPressionado;
    [SerializeField] Image _btCorrer;

    [SerializeField] Text _texto;

    [SerializeField] RectTransform _pos1, _pos2;

    [SerializeField] MoveControl _moveControl;
    [SerializeField] GameObject _player;
    void Start()
    {
        _moveControl = _player.GetComponent<MoveControl>();
        _texto.text = "CORRER";
    }

    void Update()
    {
        if (_moveControl._checkCorrendoBT == true)
        {
            _btCorrer.sprite = _btPressionado;
            _texto.transform.position = _pos1.position;
           // _texto.text = "CORRER";
        }
        else
        {
            _btCorrer.sprite = _btNaoPressionado;
            _texto.transform.position = _pos2.position;
           // _texto.text = "CORRER";
        }
    }

    public void clickButton()
    {
        _moveControl._checkCorrendoBT = !_moveControl._checkCorrendoBT;
    }
    public void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

}
