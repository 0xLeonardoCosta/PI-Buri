using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    //public static ItemPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    ItensControl _itensControl;

    protected  virtual void Awake()
    {
       // SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        _itensControl = Camera.main.GetComponent<ItensControl>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
            //_itensControl._fruta1_Lista.Add(tmp);
            //_itensControl._frutas_Listas.Add(tmp);
        }
    }

    public virtual GameObject GetPooledObject()
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
