using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    MoveControl _buriScript;
    Slider _slider;

    public float timerTotal = 15;
    public int isRunning;
    bool isTime;


    void Start()
    {
        _buriScript = Camera.main.GetComponent<GaaameController>()._player.GetComponent<MoveControl>();    
        _slider = GetComponent<Slider>();
        _buriScript._estaminaValue = timerTotal;
        _slider.maxValue = timerTotal;
        isTime=true;
        _buriScript._correndoAtivo = true;
    }

    
    void Update()
    {
        if (isTime)
        {
            if (_buriScript._estaCorrendo)
            {
                isRunning = 1;
            }
            else if (!_buriScript._estaCorrendo && _buriScript._estaminaValue <= timerTotal)
            {
                isRunning = 2;
            }
        }
        if (isRunning==1) // ativar contagem regressiva
        {
            _buriScript._estaminaValue -= Time.deltaTime * 3;
            _slider.value = _slider.value = _buriScript._estaminaValue;

            if (_buriScript._estaminaValue < 0) // Estamina vazia
            {
                isRunning = 2;
                isTime =false;
                _buriScript._estaCorrendo = false;
                _buriScript._checkCorrendo=false;
                _buriScript.speed = 0;
                _buriScript._correndoAtivo =false;
                _buriScript._checkCorrendoBT = false;
                StartCoroutine(TimeEstamina());
            }
        }

        else if (isRunning == 2)
        {
            _buriScript._estaminaValue += Time.deltaTime * 7;
            _slider.value = _buriScript._estaminaValue;
            if (_slider.value >= _slider.maxValue) // Estamina cheia
            {
                isRunning = 0;
            }
        }
    }

    IEnumerator TimeEstamina()
    {
        yield return new WaitForSeconds(3);
        isTime = true;
        _buriScript._correndoAtivo = true;
        _buriScript._checkCorrendo = false;
    }
}
