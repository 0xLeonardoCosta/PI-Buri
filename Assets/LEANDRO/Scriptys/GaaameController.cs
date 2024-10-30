using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaaameController : MonoBehaviour
{
    public Transform _player;
    public Transform _miniCam;
    public Transform _playerArm;
    public Transform _posBuriCanoa;
    public GameObject _btMiniGame;
    public Canvas _canvasHud;
    public GameObject _canoa;
    public GameObject _checkpoint2;

    public List<AudioSource> _listaAudioHUD, _listaAudioGames, _listaAudioMusica;
    [SerializeField] bool _muteHUD, _muteGame, _muteMusica;
    public bool _pauseGame;

    MoveControl _moveControl;

    [Header("Gatilhos de status")]
    public bool _estaNadando;

    [Header("Gatilhos para HUD")]
    public bool _HUDnaTela;

    private void Start()
    {
        _pauseGame=true;
        _moveControl = _player.GetComponent<MoveControl>();
    }

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

    public void CheckStatus(int value)
    {
        if (value == 1)
        {
            //_player.GetComponent<>
        }
    }

    public void CheckPause(bool value)
    {
        _pauseGame = value;
    }
}