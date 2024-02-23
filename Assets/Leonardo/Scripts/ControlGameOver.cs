using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _contador;
    [SerializeField] float timer;
    [SerializeField] float timerTeste;
    private void Start()
    {
        timer = 9;
        timerTeste = 100;
    }
    /*private void Update()
    {
        //float speed = 4;
        //timerTeste = 0.001f *-0.1f - Time.time;

        if (transform.lossyScale != Vector3.zero)
        {
            //timer = timer - Time.time;// me ajuda ivo
            timer =+ timerTeste;
            //_contador = "" + timer;
            timerTeste = 0.001f * -0.1f - Time.time;
            Debug.Log(timer);
            if (timer < 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }*/
    public void GameReiniciar()
    {
        SceneManager.LoadScene("BuriXimba");
    }
    public void VoltarMenuPrincipaaaau()
    {
        SceneManager.LoadScene("Menu");
    }
}
