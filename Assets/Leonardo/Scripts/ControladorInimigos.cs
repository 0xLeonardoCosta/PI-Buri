using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigos : MonoBehaviour
{
    float _checkTime;
    public float _timeLimit;
    //------------------------
    public int _numberPos;

    public Transform[] _posIni;
    public Transform _grupo;


    void Start()
    {
        
    }

    
    void Update()
    {
        _checkTime -= Time.deltaTime; // Contador
        if (_checkTime < 0 ) // Setar um valor ao _checkTime servir� de conometro
        {
            //Preencher aqui o que se deve executar ap�s contagem
            InimigoOn1();
            InimigoOn2();
            _checkTime = _timeLimit;
        }
    }

    void InimigoOn1()
    {
        GameObject bullet = InimigoPool1._SharedInstance.GetPooledObject();
        if (bullet != null )
        {
            _numberPos = Random.Range(0, 3);

            bullet.transform.localPosition = _posIni[_numberPos].transform.position;

            bullet.transform.SetParent(_grupo);
            bullet.SetActive(true);
        }
    }
    void InimigoOn2()
    {
        GameObject bullet = InimigoPool2._SharedInstance.GetPooledObject();
        if (bullet != null )
        {
            _numberPos = Random.Range(0, 3);

            bullet.transform.localPosition = _posIni[_numberPos].transform.position;

            bullet.transform.SetParent(_grupo);
            bullet.SetActive(true);
        }
    }
}