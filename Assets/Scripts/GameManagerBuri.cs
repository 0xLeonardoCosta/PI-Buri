using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBuri : MonoBehaviour
{
    [SerializeField] int _fase;
    [SerializeField] int _partfase;
    [SerializeField] int _life;

    [SerializeField] Transform _posPlayer;
    [SerializeField] Transform[] _pos;
    public GameObject _tutoral;
    public GameObject _tutoralSairCanoa;
    [SerializeField] List<string> _TextoTutoral;
    [SerializeField] Text textTutor;

    public GameObject _hudInfoMiniJ;

    void Start()
    {
        if (PlayerPrefs.GetInt("StartSave") == 0)
        {
            PlayerPrefs.SetInt("StartSave", 0);
        }
        Carregar();
        //_posPlayer.localPosition = _pos[_partfase].transform.position;
    }
    public void CheckPointSalvar(Vector3 pos)
    {
        PlayerPrefs.SetInt("StartSave", 1);
        PlayerPrefs.SetFloat("PosX", pos.x);
        PlayerPrefs.SetFloat("PosY", pos.y);
        PlayerPrefs.SetFloat("PosZ", pos.z);
    }
    public void AumentarFase()
    {
        _fase++;
    }
    public void Salvar()
    {
        PlayerPrefs.SetInt("fase", _fase);
        PlayerPrefs.SetInt("StartSave", 1);
    }
    public void Carregar()
    {
        _fase = PlayerPrefs.GetInt("fase");
        
    }

    public void Tutorial(int value, bool on)
    {
        _tutoral.SetActive(on);
        textTutor.text = _TextoTutoral[value];

    }

    public void FecharTutorial(int value)
    {
        _tutoral.SetActive(false);
        if (value == 0)// entrar na canoa
        {
            _tutoralSairCanoa.SetActive(true);
        }
       

    }

    public void TutoralSairCanoa(bool value)
    {
        _tutoralSairCanoa.SetActive(value);
    }
}
