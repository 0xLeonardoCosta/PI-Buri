using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detritos : MonoBehaviour
{
    
    [SerializeField] GameObject _partSaida;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }



    public GameObject PartSaida
    {
        get { return _partSaida;}
        set { _partSaida = value;}
    }

    

}
