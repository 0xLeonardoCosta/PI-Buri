using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frutacontrol : MonoBehaviour
{
    public Transform _grupoFrutas;

    public List<GameObject> _fruta1_Lista = new List<GameObject>();
    public List<GameObject> _frutas_Listas = new List<GameObject>();

    public List<Transform> _pos1List = new List<Transform>();

    [SerializeField] float _time_Ini=3;
    float _contador;
    bool _timeAtivo;

    // Start is called before the first frame update
    void Start()
    {
       
            
            _contador = _time_Ini;
        _timeAtivo = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (_timeAtivo)
        {
            _contador -= Time.deltaTime;
            if (_contador < 0)
            {
                //_timeAtivo = false;
                _contador = _time_Ini;
                fruta1_On ();
            }
        }
    }

    void fruta1_On () 
    {
        GameObject bullet = frutatipo1.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            int number = Random.Range(0, _pos1List.Count);
            bullet.transform.position = _pos1List[number].transform.position;
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.transform.SetParent(_grupoFrutas.transform);
            bullet.SetActive(true);
            bullet.GetComponent<frutacoletar>().Restart2();
        }
    }
}
