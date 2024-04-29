using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBuri : MonoBehaviour
{
    [SerializeField] int _fase;
    [SerializeField] int _partfase;
    [SerializeField] int _life;

    [SerializeField] Transform _posPlayer;
    [SerializeField] Transform[] _pos;

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
}
