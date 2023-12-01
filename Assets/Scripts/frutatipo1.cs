using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frutatipo1 : MonoBehaviour
{
    public static frutatipo1 SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    frutacontrol _frutacontrol;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        _frutacontrol = Camera.main.GetComponent<frutacontrol>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
            _frutacontrol._fruta1_Lista.Add(tmp);
            _frutacontrol._frutas_Listas.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
