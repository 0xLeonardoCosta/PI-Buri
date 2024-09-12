using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudControlusca : MonoBehaviour
{
    //[SerializeField] Transform _buriMenu;
    //[SerializeField] Transform _janainaMenu;
    //[SerializeField] Transform _caiporaMenu;
    [SerializeField] Transform _personagensMenu;
    [SerializeField] Transform _logoKidMenu;
    [SerializeField] Transform _logoBuriMenu;
    [SerializeField] Transform _canoaMenu;
    [SerializeField] Transform _gpMenu;
    [SerializeField] Transform _hudCarregamentoMenu;
    [SerializeField] Transform _aqueleTextoMenu;

    [SerializeField] private Slider _barraDeProgressoInicio;

    [SerializeField] List<MenuControlusca> _menuControls;

    


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _menuControls.Count; i++)
        {
            _menuControls[i].transform.localScale = Vector3.zero;
            _menuControls[i].gameObject.SetActive(false);
        }
        _menuControls[0].gameObject.SetActive(true);
        _menuControls[0].MenuOFF();
        _menuControls[0].transform.DOScale(1,0.25f);
        _menuControls[0].ChamarMenu();
    }

    public void ChamarMenuControl(int value)
    {
        for (int i = 0; i < _menuControls.Count; i++)
        {
            _menuControls[i].transform.localScale = Vector3.zero;
            _menuControls[i].MenuOFF();
            _menuControls[i].MenuOFF();
            _menuControls[i] .gameObject.SetActive(false);
        }
        _menuControls[value].gameObject.SetActive(true);
        _menuControls[value].transform.DOScale(1, .25f);
        _menuControls[value].ChamarMenu();
    }

    public void NovoJogo()
    {
        this._personagensMenu.gameObject.SetActive(false);
        this._logoBuriMenu.gameObject.SetActive(false);
        this._logoKidMenu.gameObject.SetActive(false);
        this._canoaMenu.gameObject.SetActive(false);
        this._gpMenu.gameObject.SetActive(false);
        this._aqueleTextoMenu.gameObject.SetActive(false);

        this._hudCarregamentoMenu.gameObject.SetActive(true);
        this._barraDeProgressoInicio.gameObject.SetActive(true);
        

        StartCoroutine(CarregarCenaInicio());
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    private IEnumerator CarregarCenaInicio()
    {
        AsyncOperation asynOperation = SceneManager.LoadSceneAsync("BuriXimba");
        while (!asynOperation.isDone)
        {
            this._barraDeProgressoInicio.value = asynOperation.progress;
            yield return null;
        }

    }
}
