using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControl : MonoBehaviour
{
    public GameControll _gameControl;
    //public List<GameObject> _ini_VivoL, _ini_MortoL;
    public List<GameObject> _listaInimigos1L, _listaInimigos2L;
    public List<Transform> _iniPos;

    public Transform _spawn;

    // ------------ Timer ------------
    [SerializeField] float timer = 15;
    float oldTimer;
    bool isRunning = true;
    // -------------------------------

    void Start()
    {
        _gameControl = Camera.main.GetComponent<GameControll>();
        //Invoke("InimigoStart1", 0.5f);
        //Invoke("InimigoStart2", 0.5f);

        oldTimer = timer;
    }
    void Update()
    {
        if (isRunning)
        {
            oldTimer -= Time.deltaTime;
            if (oldTimer < 0)
            {
                InimigoStart01();
                InimigoStart02();
                Debug.Log("Aparecer Inimigo");
                timer = Random.Range(3, 6);
                oldTimer = timer;
            }
        }
    }
    void InimigoStart01()
    {
        GameObject bullet = Lixinho_Tipo1.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            int number = Random.Range(0, _iniPos.Count);
            bullet.transform.position = _iniPos[number].position;
            bullet.GetComponent<SeguirPlayer33>()._player = _gameControl._player;
            bullet.GetComponent<SeguirPlayer33>()._speedNew = 5;
            bullet.transform.SetParent(_gameControl._inimigos);
            //_ini_VivoL.Add(bullet);
            //_ini_MortoL.Remove(bullet);
            bullet.SetActive(true);
            
        }
    }
    void InimigoStart02()
    {
        
        GameObject bullet = Lixo_tipo2.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            int number = Random.Range(0, _iniPos.Count);
            bullet.transform.position = _iniPos[number].position;
            bullet.GetComponent<SeguirPlayer33>()._player = _gameControl._player;
            bullet.GetComponent<SeguirPlayer33>()._speedNew = 5;
            bullet.transform.SetParent(_gameControl._inimigos);
            //_ini_VivoL.Add(bullet);
            //_ini_MortoL.Remove(bullet);
            bullet.SetActive(true);
           
        }
    }
}
