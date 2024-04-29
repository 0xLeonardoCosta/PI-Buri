using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public string _tagCheckPoint;
    GameManagerBuri _gameManager;
    public Vector3 _posSave;

    void Start()
    {
        _gameManager = Camera.main.GetComponent<GameManagerBuri>();
        Debug.Log(PlayerPrefs.GetInt("StartSave"));
        if (PlayerPrefs.GetInt("StartSave") != 0)
        {
           
            _posSave.x = PlayerPrefs.GetFloat("PosX");
            _posSave.y = PlayerPrefs.GetFloat("PosY");
            _posSave.z = PlayerPrefs.GetFloat("PosZ");
            transform.position = _posSave;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tagCheckPoint))
        {
        
            Debug.Log("Posição CheckPoint" + other.transform.position);
            _gameManager.Salvar();
            _gameManager.CheckPointSalvar(other.transform.position);
        }
    }
}
