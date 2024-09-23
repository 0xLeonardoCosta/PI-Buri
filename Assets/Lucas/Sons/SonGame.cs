using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonGame : MonoBehaviour
{
    [SerializeField] ControleSom _controleSom;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] bool _somMenu;
    [SerializeField] bool _somMusic;
    [SerializeField] bool _somGame;

    void Start()
    {
        _controleSom = Camera.main.GetComponent<ControleSom>();
        _audioSource = GetComponent<AudioSource>();

        if (_somMenu)
        {
            _controleSom._sonsMenu.Add(_audioSource);
        }
        else if (_somMusic)
        {
            _controleSom._sonsMusic.Add(_audioSource);
        }
        else if (_somGame)
        {
            _controleSom._sonsGame.Add(_audioSource);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
