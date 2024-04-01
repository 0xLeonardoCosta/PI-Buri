using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSom : MonoBehaviour
{
    //Colocar esse script em todos os componentes que tiverem AudioSource como componente
    public bool _somHud, _somMusic, _somGame;
    public GaaameController _gameControler;
    public AudioSource _audioSource;

    private void Start()
    {
        _gameControler = Camera.main.GetComponent<GaaameController>();
        _audioSource = GetComponent<AudioSource>();

        if (_somHud)
        {
            _gameControler._listaAudioHUD.Add(_audioSource);
        }
        else if (_somMusic)
        {
            _gameControler._listaAudioGames.Add(_audioSource);
        }
        else if (_somGame)
        {
            _gameControler._listaAudioMusica.Add(_audioSource);
        }
    }
}
