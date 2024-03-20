using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _opcoesMenu;

    [SerializeField] List<GameObject> _BtMenu;
    [SerializeField] GameObject _BtPause;

    [SerializeField] GameObject _botoesBaixo;
    [SerializeField] GameObject _staminaVidas;

    [SerializeField] Transform _posBaixo, _posCima;
    [SerializeField] Transform _posOriginBaixo, _posOriginCima;

    void Start()
    {
        _pauseMenu.transform.localScale = Vector3.zero;    
        _opcoesMenu.transform.localScale = Vector3.zero;    
    }
    public void Pause()
    {
        StartCoroutine(AbrirMenuPause());
    }
    public void Opcoes()
    {
        StartCoroutine(AbrirMenuOpcoes());
    }
    public void Voltar()
    {
        StartCoroutine(VoltarAoMenuPause());
    }
    public void FecharMenu()
    {
        StartCoroutine(FecharMenuPause());
    }
    public void VoltarMenuPrincipaaaau() // Voltar ao menu
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MenuBuriLusca");
    }

    IEnumerator AbrirMenuPause() // Dar pause no game
    {
        _BtPause.transform.DOScale(0f, 0.3f);
        _pauseMenu.transform.DOScale(1.3f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        _pauseMenu.transform.DOScale(1f, 0.2f);

        _botoesBaixo.transform.DOMove(_posBaixo.position, 1f);
        _staminaVidas.transform.DOMove(_posCima.position, 1f);

        for (int i = 0; i < _BtMenu.Count; i++)
        {
            _BtMenu[i].transform.DOScale(1.5f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            _BtMenu[i].transform.DOScale(2.9f, 0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        //Time.timeScale = 0.01f;
    }

    IEnumerator FecharMenuPause() // Voltar ao game
    {
        Time.timeScale = 1f;

        for (int i = 0; i < _BtMenu.Count; i++)
        {
            _BtMenu[i].transform.DOScale(1.5f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            _BtMenu[i].transform.DOScale(0f, 0.2f);
        }
        yield return new WaitForSeconds(0.5f);

        _botoesBaixo.transform.DOMove(_posOriginBaixo.position, 0.5f);
        _staminaVidas.transform.DOMove(_posOriginCima.position, 0.5f);

        _pauseMenu.transform.DOScale(0f, 0.2f);
        _BtPause.transform.DOScale(1f, 0.3f);
        //_BtPause.SetActive(false);
    }
    IEnumerator AbrirMenuOpcoes() // Abrir opcoes do game
    {
        _pauseMenu.SetActive(false);
        _opcoesMenu.transform.DOScale(1.3f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        _opcoesMenu.transform.DOScale(1f, 0.2f);
    }
    IEnumerator VoltarAoMenuPause() // Voltar ao menu a partir do opcoes
    {
        _BtPause.transform.DOScale(0f, 0.3f);
        _pauseMenu.transform.DOScale(1.3f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        _pauseMenu.transform.DOScale(1f, 0.2f);

        for (int i = 0; i < _BtMenu.Count; i++)
        {
            _BtMenu[i].transform.DOScale(1.5f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            _BtMenu[i].transform.DOScale(2.9f, 0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        //Time.timeScale = 0.01f;
    }
}
