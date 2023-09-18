using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooontrol_inimigos : MonoBehaviour
{
    public bool _chamarInimigos;
    float _checktime;
    [SerializeField] float _timeLimit;

    public Transform[] _posIni;
    public int _numerPos;

    // Start is called before the first frame update
    void Start()
    {
        _checktime = _timeLimit;


    }

    // Update is called once per frame
    void Update()
    {
        
       _checktime -= Time.deltaTime;
        if (_checktime < 0)
        {
            InimigoOn_1();
            _checktime = _timeLimit;
        }

    }

    void InimigoOn_1()
    {
        GameObject bullet = InimigoooPool_1.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            _numerPos = Random.Range(0, 3);
            //_numerPos = Random.Range(0, _posIni.Length);
            bullet.transform.localPosition = _posIni[_numerPos].transform.position;
            //bullet.transform.SetParent(_posIni[0]);
            //bullet.transform.position = new Vector3(0,0,0);
            bullet.SetActive(true);
        }
    }

    public void ZerarTime()
    {
        _checktime = _timeLimit;
    }
}
