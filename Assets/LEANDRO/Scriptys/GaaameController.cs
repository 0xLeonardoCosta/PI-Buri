using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaaameController : MonoBehaviour
{
    public Transform _player;
    public Transform _miniCam;
    public Transform _playerArm;
    public Transform _posBuriCanoa;
    public Canvas _canvasHud;

    public List<AudioSource> _listaAudioHUD, _listaAudioGames, _listaAudioMusica;
    [SerializeField] bool _muteHUD, _muteGame, _muteMusica;

    void Update()
    {
        for (int i = 0; i < _listaAudioHUD.Count; i++)
        {
            _listaAudioHUD[i].mute = _muteHUD;
        }
        for (int i = 0; i < _listaAudioGames.Count; i++)
        {
            _listaAudioGames[i].mute = _muteGame;
        }
        for (int i = 0; i < _listaAudioMusica.Count; i++)
        {
            _listaAudioMusica[i].mute = _muteMusica;
        }
    }
}