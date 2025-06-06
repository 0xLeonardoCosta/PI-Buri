using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _opcoesMenu;
    [SerializeField] GameObject _inventarioMenu;
    [SerializeField] GameObject _mapa; // Criado por Fernanda

    [SerializeField] Sprite[] _spriteBTVoltarAoJogo;

    [SerializeField] List<GameObject> _BtMenu;
    [SerializeField] GameObject _BtPause, _BtInventario;
    [SerializeField] GameObject _BtVoltarAoJogo;

    [SerializeField] GameObject _botoesBaixo;
    [SerializeField] GameObject _staminaVidas;


    [SerializeField] Transform _posForaPause, _posForaInventario;
    [SerializeField] Transform _posOriginPause, _posOriginInventario;
    [SerializeField] Transform _posMapa; // Refer�ncia para a posi��o do mapa (Criado por Fernanda)

    [SerializeField] Transform _posBaixo, _posCima;
    [SerializeField] Transform _posOriginBaixo, _posOriginCima;
    [SerializeField] Transform _posMapaOrigin;
    [SerializeField] GaaameController _gaaameController;

    void Start()
    {
        _pauseMenu.transform.localScale = Vector3.zero;    
        _opcoesMenu.transform.localScale = Vector3.zero;    
        _inventarioMenu.transform.localScale = Vector3.zero;    
         _gaaameController = Camera.main.GetComponent<GaaameController>();

    }
    public void Pause()
    {
        StartCoroutine(AbrirMenuPause());
    }
    public void Opcoes()
    {
        if (_gaaameController._pauseGame)
        {
            StartCoroutine(AbrirMenuOpcoes());
        }
    }
    public void Voltar()
    {
        if (_gaaameController._pauseGame)
        {
            StartCoroutine(VoltarAoMenuPause());
        }
    }
    public void FecharMenu()
    {
        StartCoroutine(FecharMenuPause());
    }
    public void VoltarAoJogo()
    {
        //StartCoroutine(VoltarAoJogoAgora());
    }
    public void AbrirInventario()
    {
        StartCoroutine(AbrirMenuInventario());
    }
    public void VoltarMenuPrincipaaaau() // Voltar ao menu
    {
        //Time.timeScale = 1f;
        if (_gaaameController._pauseGame)
        {
            SceneManager.LoadScene("MenuBuriLusca");
        }
    }

    IEnumerator AbrirMenuPause() // Dar pause no game
    {
        if (!_gaaameController._pauseGame) {
            _gaaameController._pauseGame = true;
        _pauseMenu.SetActive(true);

        _BtPause.transform.DOMove(_posForaPause.position, 0.3f);
        _BtInventario.transform.DOMove(_posForaInventario.position, 0.3f);

        _botoesBaixo.transform.DOMove(_posBaixo.position, 0.3f);
        _staminaVidas.transform.DOMove(_posCima.position, 0.3f);

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

    IEnumerator AbrirMenuOpcoes() // Abrir opcoes do game
    {
        _pauseMenu.SetActive(false);
        _mapa.SetActive(false);
        _opcoesMenu.SetActive(true);
        _BtVoltarAoJogo.SetActive(true);
        _BtVoltarAoJogo.transform.DOScale(1f, 0.2f);
        _opcoesMenu.transform.DOScale(1.3f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        _opcoesMenu.transform.DOScale(1f, 0.2f);
    }

    
    IEnumerator VoltarAoMenuPause() // Voltar ao menu a partir do opcoes
    {
        _pauseMenu.SetActive(true);
        _mapa.SetActive(false);
        //_BtPause.transform.DOScale(0f, 0.3f);
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

    IEnumerator FecharMenuPause() // Voltar ao game
    {
        Time.timeScale = 1f;

        for (int i = 0; i < _BtMenu.Count; i++)
        {
            _BtMenu[i].transform.DOScale(1.5f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            _BtMenu[i].transform.DOScale(0f, 0.2f);
        }

        _pauseMenu.transform.DOScale(0f, 0.15f);
        _opcoesMenu.transform.DOScale(0f, 0.15f);
        _inventarioMenu.transform.DOScale(0f, 0.15f);
        ///_mapa.transform.DOScale(0f, 0.15f);

        //_BtPause.transform.DOScale(1f, 0.3f);
        //yield return new WaitForSeconds(0.5f);

        _botoesBaixo.transform.DOMove(_posOriginBaixo.position, 0.2f);
        _staminaVidas.transform.DOMove(_posOriginCima.position, 0.2f);

        _BtPause.transform.DOMove(_posOriginPause.position, 0.15f);
        _BtInventario.transform.DOMove(_posOriginInventario.position, 0.15f);

        // Reativar o mapa ao fechar o menu
        _mapa.SetActive(true);

        yield return new WaitForSeconds(0f);

        //_BtPause.SetActive(false);
    }

    /*IEnumerator VoltarAoJogoAgora()
    {
        _BtVoltarAoJogo.gameObject.GetComponent<Image>().sprite = _spriteBTVoltarAoJogo[1];
        yield return new WaitForSeconds(1f);
        _BtVoltarAoJogo.gameObject.GetComponent<Image>().sprite = _spriteBTVoltarAoJogo[0];
        _botoesBaixo.transform.DOMove(_posOriginBaixo.position, 0.5f);
        _staminaVidas.transform.DOMove(_posOriginCima.position, 0.5f);
        _BtPause.SetActive(true);
        _pauseMenu.SetActive(true);
        _BtPause.transform.DOScale(0f, 0.3f);
        _pauseMenu.transform.DOScale(0f, 0.2f);
        _BtVoltarAoJogo.transform.DOScale(0f, 0.2f);
        yield return new WaitForSeconds(0f);
    }*/

    IEnumerator AbrirMenuInventario()
    {
        _BtPause.transform.DOMove(_posForaPause.position, 0.3f);
        _BtInventario.transform.DOMove(_posForaInventario.position, 0.3f);

        _botoesBaixo.transform.DOMove(_posBaixo.position, 0.3f);
        _staminaVidas.transform.DOMove(_posCima.position, 0.3f);

        _pauseMenu.SetActive(false);
        _opcoesMenu.SetActive(false);
        _mapa.SetActive(false); // Aqui desativamos o mapa

        _inventarioMenu.transform.DOScale(1.3f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        _inventarioMenu.transform.DOScale(1f, 0.2f);

        _mapa.transform.position = _posMapa.position; // Defina a posi��o do mapa

        yield return new WaitForSeconds(0f);
    }
}
