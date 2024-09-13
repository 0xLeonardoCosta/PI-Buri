using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IniciarMiniGame : MonoBehaviour
{
    [SerializeField] Slider _barraDeProgressoMinijogo1;
    [SerializeField] Transform _buriproMini;
    [SerializeField] Transform _canoaproMini;
    [SerializeField] Transform _detritosproMini;
    [SerializeField] Transform _cenarioProMini;
    [SerializeField] Transform _hudCarregamentoMinijogo1;
    [SerializeField] Transform _hudCimaMini;
    [SerializeField] Transform _hudBaixoMini;
    [SerializeField] Transform _hud1AvisoSairdaCanoamini;
    [SerializeField] Transform _hud2AvisoSairdaCanoamini;
    [SerializeField] Transform _hudtexto1AvisoSairdaCanoamini;
    [SerializeField] Transform _hudtexto2AvisoSairdaCanoamini;
    [SerializeField] Transform _textoVoados;
    [SerializeField] Transform _btMiniTexto;
    [SerializeField] Transform _imagemBt;
    
    public void IniciarMiniGome()
    {
        
        this._imagemBt.GetComponent<Image>().enabled = false;
        this._hud1AvisoSairdaCanoamini.GetComponent<Image>().enabled = false;
        this._hud2AvisoSairdaCanoamini.GetComponent<Image>().enabled = false;
        this._buriproMini.gameObject.SetActive(false);
        this._canoaproMini.gameObject.SetActive(false);
        this._detritosproMini.gameObject.SetActive(false);
        this._cenarioProMini.gameObject.SetActive(false);
        this._hudtexto1AvisoSairdaCanoamini.gameObject.SetActive(false);
        this._hudtexto2AvisoSairdaCanoamini.gameObject.SetActive(false);
        this._textoVoados.gameObject.SetActive(false);
        this._btMiniTexto.gameObject.SetActive(false);
        this._hudCimaMini.gameObject.SetActive(false);
        this._hudBaixoMini.gameObject.SetActive(false);
        this._hudCarregamentoMinijogo1.gameObject.SetActive(true);
        this._barraDeProgressoMinijogo1.gameObject.SetActive(true);

        StartCoroutine(CarregarCenaMiniJogo1());
    }

    private IEnumerator CarregarCenaMiniJogo1()
    {
       

        AsyncOperation asynOperation = SceneManager.LoadSceneAsync("minijogoleandro");


        while (!asynOperation.isDone)
        {
            this._barraDeProgressoMinijogo1.value = asynOperation.progress;
            yield return null;
        }

    }
}
