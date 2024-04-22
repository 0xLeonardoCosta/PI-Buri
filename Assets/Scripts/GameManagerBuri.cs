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

    // Start is called before the first frame update
    void Start()
    {
        Carregar();
        _posPlayer.localPosition = _pos[_partfase].transform.position;
    }

    public void AumentarFase()
    {
        _fase++;
    }
    public void Salvar()
    {
        PlayerPrefs.SetInt("fase", _fase);
    }
    public void Carregar()
    {
        _fase = PlayerPrefs.GetInt("fase");
        
    }
}
