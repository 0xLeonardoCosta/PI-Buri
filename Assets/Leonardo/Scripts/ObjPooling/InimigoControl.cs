using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControl : MonoBehaviour
{   
    
    // ------------ Timer ------------
    [SerializeField] float timer = 15;
    float oldTimer;
    bool isRunning = true;
    // -------------------------------

    void Update()
    {
        if (isRunning)
        {
            oldTimer -= Time.deltaTime;
            if (oldTimer < 0)
            {
                InimigoStart01();
                //InimigoStart02();
                Debug.Log("Aparecer Inimigo");
                oldTimer = timer;
            }
        }
    }
    void InimigoStart01()
    {
        GameObject bullet = Lixinho_Tipo1.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            //bullet.transform.position = turret.transform.position;
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
