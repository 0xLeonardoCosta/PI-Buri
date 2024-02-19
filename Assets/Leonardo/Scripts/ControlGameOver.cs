using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGameOver : MonoBehaviour
{
    public void GameReiniciar()
    {
        SceneManager.LoadScene("BuriXimba");
    }
    public void VoltarMenuPrincipaaaau()
    {
        SceneManager.LoadScene("Menu");
    }
}
