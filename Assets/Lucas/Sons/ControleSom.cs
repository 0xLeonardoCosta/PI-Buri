using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControleSom : MonoBehaviour
{
    public List<AudioSource> _sonsMenu = new List<AudioSource>();
    [SerializeField] bool _somMenuMute;
    [SerializeField] TextMeshProUGUI _textSomMenu;

    public List<AudioSource> _sonsMusic = new List<AudioSource>();

    [SerializeField] bool _somMusicMute;
    [SerializeField] TextMeshProUGUI _textSomMusic;

    public List<AudioSource> _sonsGame = new List<AudioSource>();
    [SerializeField] bool _somGameMute;
    [SerializeField] TextMeshProUGUI _textSomGame;

    void Start()
    {

    }

    public void SomMenuMute()
    {
        _somMenuMute = !_somMenuMute;
        if (_somMenuMute)
        {
            _textSomMenu.text = "Som Menu";

        }
        else
        {
            _textSomMenu.text = "Mute Menu";
        }

        for (int i = 0; i < _sonsMenu.Count; i++)
        {
            _sonsMenu[i].mute = _somMenuMute;
        }
    }


    public void SomMusicMute()
    {
        _somMusicMute = !_somMusicMute;
        if (_somMusicMute)
        {
            _textSomMusic.text = "Som Music";
            for (int i = 0; i < _sonsMusic.Count; i++)
            {
                _sonsMusic[i].Stop();
            }

        }
        else
        {
            _textSomMusic.text = "Mute Music";
            for (int i = 0; i < _sonsMusic.Count; i++)
            {
                _sonsMusic[i].Play();
            }
        }


    }

    public void SomGameMute()
    {
        _somGameMute = !_somGameMute;
        if (_somGameMute)
        {
            _textSomGame.text = "Som Game";
        }
        else
        {
            _textSomGame.text = "Mute Game";

        }

        for (int i = 0; i < _sonsGame.Count; i++)
        {
            _sonsGame[i].mute = _somGameMute;
        }

    }
}
