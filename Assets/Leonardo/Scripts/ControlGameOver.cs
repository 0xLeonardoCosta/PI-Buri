using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _contador;
    [SerializeField] float timer;
    [SerializeField] float tempoInicial = 0f;
    [SerializeField] bool contagemIniciada = false;

    private void Update()
    {
        if (transform.localScale != Vector3.zero && !contagemIniciada)
        {
            contagemIniciada = true;
            tempoInicial = Time.time;
        }

        if (contagemIniciada)
        {
            float tempoDecorrido = Time.time - tempoInicial; // Calcula o tempo decorrido desde o início da contagem
            int numeroInt = (int)Mathf.Ceil(9 - tempoDecorrido); // Calcula o tempo restante e arredonda para cima
            _contador.text = numeroInt.ToString(); // Atualiza o texto do contador
            //Debug.Log("Tempo decorrido: " + tempoDecorrido);
            if (tempoDecorrido >= 10)
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
