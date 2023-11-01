using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte : MonoBehaviour
{
    InimigoControl _control;

    private void Start()
    {
        _control = Camera.main.GetComponent<InimigoControl>();
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Player"))
        {
            _control._ini_MortoL.Add(gameObject);
            _control._ini_VivoL.Remove(gameObject);
            gameObject.SetActive(false);
        }
    }
}
