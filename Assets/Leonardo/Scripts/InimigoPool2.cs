using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPool2 : MonoBehaviour
{
    public static InimigoPool2 _SharedInstance;
    public List<GameObject> _pooledObjects;
    public GameObject _objectsToPool;
    public int _amountToPool;

    void Awake()
    {
        _SharedInstance = this;
    }
    void Start()
    {
        _pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectsToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
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
