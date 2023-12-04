using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPool3 : MonoBehaviour
{
    public static InimigoPool3 _SharedInstance;
    public List<GameObject> _pooledObjects;
    public GameObject _objectsToPool;
    public int _amountToPool;

    ControladorInimigos _control;

    void Awake()
    {
        _SharedInstance = this;
    }
    void Start()
    {
        _control = Camera.main.GetComponent<ControladorInimigos>();

        _pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectsToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
            _control._inimigosLista1.Add(tmp);
            _control._inimigosListaGeral.Add(tmp);
            _control._inimigosTrans.Add(tmp.transform);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
