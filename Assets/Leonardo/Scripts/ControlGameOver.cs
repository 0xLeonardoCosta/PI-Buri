using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _contador;
    [SerializeField] int timer;
    private void Start()
    {
        timer = 9;
    }
    private void Update()
    {
        if (transform.localScale != Vector3.zero)
        {
            _contador.text = ""+timer;
            timer =- Time.frameCount;// me ajuda ivo
            if (timer < 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public void GameReiniciar()
    {
        SceneManager.LoadScene("BuriXimba");
    }
    public void VoltarMenuPrincipaaaau()
    {
        SceneManager.LoadScene("Menu");
    }
}
