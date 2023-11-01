using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte33 : MonoBehaviour
{

    InimigoControl33 _control;


    // Start is called before the first frame update
    void Start()
    {
        _control = Camera.main.GetComponent<InimigoControl33>();
    }

    // Update is called once per frame
    void Update()
    {

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
