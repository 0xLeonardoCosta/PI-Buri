using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    public Transform _buriLogo;
    public GameObject _LogoBuri, _LogoKidney;
    public List<Transform> menu1 = new List<Transform>();

    [SerializeField] GameObject _menuPrincipal, _menuJogar, _menuOpicoes;
    //public List<Transform> menu2 = new List<Transform>();

    
    void Start()
    {
        _buriLogo.localScale = new Vector2(0,0);

        for (int i = 0; i < menu1.Count; i++)
        {
            menu1[i].localScale = new Vector2(0, 0);
        }
        /*for (int i = 0; i < menu2.Count; i++)
        {
            menu2[i].localScale = new Vector2(0, 0);
        }*/

        StartCoroutine(TimeONMenu());
    }


    IEnumerator TimeONMenu()
    {
        _buriLogo.DOScale(1.3f, 0.20f);
        yield return new WaitForSeconds(.5f);
        _buriLogo.DOScale(1f, .2f);

        //_buriLogo.DOShakeRotation(1f, 10, 70f, 20f, true, ShakeRandomnessMode.Full);

        for (int i = 0; i < menu1.Count; i++)
        {
            menu1[i].DOScale(1.5f, 0.20f);
            yield return new WaitForSeconds(.2f);
            menu1[i].DOScale(1f, .2f);
        }        
    }

    public void AbrirMenuJogar()
    {
        _menuJogar.SetActive(true);
        _menuOpicoes.SetActive(false);
        _menuPrincipal.SetActive(false);
    }
    public void AbrirMenuOpcoes()
    {
        _menuJogar.SetActive(false);
        _menuOpicoes.SetActive(true);
        _menuPrincipal.SetActive(false);
        _LogoBuri.SetActive(false);
        _LogoKidney.SetActive(false);
    }
    public void AbrirMenuPrincipal()
    {
        _menuJogar.SetActive(false);
        _menuOpicoes.SetActive(false);
        _menuPrincipal.SetActive(true);
        _LogoBuri.SetActive(true);
        _LogoKidney.SetActive(true);
    }
}
