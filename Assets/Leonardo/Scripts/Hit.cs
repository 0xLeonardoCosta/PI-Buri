using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hit : MonoBehaviour
{
    Animator _anim;
    public bool _foiHit = false;
    public GameObject _parent;

    Transform _player;

    [SerializeField] GaaameController _gameControler;

    void Start()
    {
        _anim = GetComponent<Animator>();

        _gameControler = Camera.main.GetComponent<GaaameController>();
        _player = _gameControler._player;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "BuriTrigger") // se
        {

            _foiHit = true;
            Morre();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "BuriTrigger") // se
        {

            _foiHit = false;
            //Invoke("Revive", 5f);
        }
    }
    void Morre()
    {
        
        //_player.gameObject.SetActive(false); // desativar pai
        //transform.parent.gameObject.SetActive(false); // desativar pai
    }

    void Revive()
    { 
        _player.gameObject.SetActive(true);
    }
}