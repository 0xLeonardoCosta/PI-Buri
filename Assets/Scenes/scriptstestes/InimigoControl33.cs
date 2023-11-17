using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControl33 : MonoBehaviour
{
    [SerializeField] GameControl33 _gameControl;
    public List<GameObject> _ini_VivoL;
    public List<GameObject> _ini_MortoL;
    public Transform _posIni;


    public float timer = 15;

    float oldTimer;
    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        _gameControl = Camera.main.GetComponent<GameControl33>();



        oldTimer = timer;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            oldTimer -= Time.deltaTime;
            // GetComponent<Text>().text = "Tempo: " + Mathf.RoundToInt(timer).ToString() + " s";

            if (oldTimer < 0)
            {
                //inimigoStart1();
                inimigoStart2();
                // isRunning = false;
                Debug.Log("Aparecer Inimigo");
                oldTimer = timer;
            }
        }
    }

   /* public void inimigoStart1()
    {
        GameObject bullet = InimigoTipo_1.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            //bullet.transform.position = turret.transform.position;
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.GetComponent<SeguirPlayer33>()._player = _gameControl._player;
            bullet.transform.SetParent(_gameControl._inimigosPai);
            _ini_VivoL.Add(bullet);
            _ini_MortoL.Remove(bullet);
            bullet.SetActive(true);
            bullet.transform.position = _posIni.position;
        }
    }
   */

    public void inimigoStart2()
    {
        GameObject bullet = Lixo_tipo2.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            //bullet.transform.position = turret.transform.position;
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.GetComponent<SeguirPlayer33>()._player = _gameControl._player;
            _ini_VivoL.Add(bullet);
            _ini_MortoL.Remove(bullet);
            bullet.SetActive(true);
            bullet.transform.position = _posIni.position;
            bullet.GetComponent<HitInimigos>().Restart();
        }
    }
}
