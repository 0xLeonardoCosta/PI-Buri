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

    MoveControl _buriControl;

    public bool _seguirPlayer;

    void Start()
    {
        _buriControl = GetComponent<MoveControl>();
    }

    
    void Update()
    {
        _checkTime -= Time.deltaTime; // Contador
        if (_checkTime < 0 ) // Setar um valor ao _checkTime servirá de conometro
        {
            //Preencher aqui o que se deve executar após contagem
            InimigoOn1();
            InimigoOn2();
            InimigoOn3();
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

            bullet.GetComponent<InimigoPai>()._moveLixo._posInicial = _posIni[_numberPos];

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
    void InimigoOn3()
    {
        GameObject bullet = InimigoPool3._SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            _numberPos = Random.Range(0, 3);

            bullet.transform.localPosition = _posIni[_numberPos].transform.position;
            bullet.GetComponent<MoveLixo>()._posInicial = _posIni[_numberPos];
            bullet.transform.SetParent(_grupo);
            bullet.SetActive(true);
        }
    }
}
