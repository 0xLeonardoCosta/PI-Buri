using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudGames : MonoBehaviour
{
    public Transform[] _iconVida;
    [SerializeField] RectTransform[] _iconUmCoracao;

    [Header("Teste")]
    // Define a duração, força e intervalo do shake
    [SerializeField] float duration = 1f;
    [SerializeField] float randomness;
    [SerializeField] Vector2 strength; // A força do shake
    [SerializeField] int vibrato = 10; // Quantas vezes ele vibra por segundo
    [SerializeField] bool snapping;
    [SerializeField] bool fadeOut;

    [SerializeField] Transform _telaGameOver;

    [SerializeField] GameObject _vidaGrupo;
    [SerializeField] GameObject _btGameOverGrupo;
    [SerializeField] GameObject _baixoGrupo;
    [SerializeField] GameObject _stamina;
    [SerializeField] GameObject _pos; //Coracoes
    [SerializeField] GameObject _pos1; //Botoes(sai da tela)
    [SerializeField] GameObject _pos2; //Stamina(sai da tela)
    //[SerializeField] GameObject _pos3; //Continue
    [SerializeField] Button _Reiniciar;
    public int _vidaAtual;
    public int _vidaMaxima;

    public bool _checkHit;

    float _tamV;

   

    [SerializeField] Color[] _cor;
    [SerializeField] Image _corPanelHit;

    void Start()
    {
        // _iconVida[2].DOScale(0, 0.5f);
        _tamV = _iconVida[0].localScale.x;
    }
    void Update()
    {
        // if (_vidaAtual == 2 || _vidaAtual == 1)
        {
           // StartCoroutine(Resta1Coracao());
        }    
    }

    public void RecebeuDano()
    {
            _vidaAtual--;
            //Debug.Log("Perdeyvida");
            CheckIconVida(_vidaAtual);
            Invoke("TimeHit", 1f);
            StartCoroutine(TimeHit());
    }
    IEnumerator TimeHit()
    {
        //yield return new WaitForSeconds(.25f);
        _corPanelHit.DOColor(_cor[0], 0.25f);
        yield return new WaitForSeconds(1f);
        _corPanelHit.DOColor(_cor[1], 0.25f);
        yield return new WaitForSeconds(.1f);
    }

    public void GanhouVida()
    {
        //_vidaAtual++;
        if (_vidaAtual < 6)
        {
            _vidaAtual++;
        }
        //Debug.Log("Ganhouvida");
        CheckIconVida(_vidaAtual);
        //StartCoroutine(TimeHit());
    }

    IEnumerator Resta1Coracao()
    {
        // Chama o método DOShakeAnchorPos para iniciar o shake
        //_iconUmCoracao[0].DOShakeAnchorPos(duration, strength, vibrato, 45, snapping, fadeOut);
        //_iconUmCoracao[1].DOShakeAnchorPos(duration, strength, vibrato, 45, snapping, fadeOut);

        //_iconUmCoracao[0].DORotate(strength, vibrato);
        //_iconUmCoracao[1].DORotate(strength, vibrato);

        //_iconUmCoracao[0].DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
        //_iconUmCoracao[1].DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);


        Debug.Log("passouaqui");
        yield return new WaitForSeconds(1f);
    }

    public void CheckIconVida(int vida)
    {
        if (vida <= 0)
        {
            _iconVida[0].DOScale(0, 0.5f);
            _iconVida[1].DOScale(0, 0.5f);
            _iconVida[2].DOScale(0, 0.5f);
            _iconVida[3].DOScale(0, 0.5f);
            _iconVida[4].DOScale(0, 0.5f);
            _iconVida[5].DOScale(0, 0.5f);

            //Chamar tela GameOver
            _telaGameOver.DOScale(1f, 0.5f);
            _vidaGrupo.transform.DOMove(_pos.transform.position, 1.5f);
            //_btGameOverGrupo.transform.DOMove(_pos3.transform.position, 0.15f);
            _btGameOverGrupo.transform.DOScale(1, 0.25f);
            _baixoGrupo.transform.DOMove(_pos1.transform.position, 0.25f);
            _stamina.transform.DOMove(_pos2.transform.position, 0.05f);
            _Reiniciar.Select();
            
            
        }
        else if (vida == 1)
        {
            _iconVida[0].DOScale(_tamV, 0.5f);
            _iconVida[1].DOScale(0, 0.5f);
            _iconVida[2].DOScale(0, 0.5f);
            _iconVida[3].DOScale(0, 0.5f);
            _iconVida[4].DOScale(0, 0.5f);
            _iconVida[5].DOScale(0, 0.5f);
            
        }
        else if (vida == 2)
        {
            _iconVida[0].DOScale(_tamV, 0.5f);
            _iconVida[1].DOScale(_tamV, 0.5f);
            _iconVida[2].DOScale(0, 0.5f);
            _iconVida[3].DOScale(0, 0.5f);
            _iconVida[4].DOScale(0, 0.5f);
            _iconVida[5].DOScale(0, 0.5f);
            
        }
        else if (vida == 3)
        {
            _iconVida[0].DOScale(_tamV, 0.5f);
            _iconVida[1].DOScale(_tamV, 0.5f);
            _iconVida[2].DOScale(_tamV, 0.5f);
            _iconVida[3].DOScale(0, 0.5f);
            _iconVida[4].DOScale(0, 0.5f);
            _iconVida[5].DOScale(0, 0.5f);
            
        }
        else if (vida == 4)
        {
            _iconVida[0].DOScale(_tamV, 0.5f);
            _iconVida[1].DOScale(_tamV, 0.5f);
            _iconVida[2].DOScale(_tamV, 0.5f);
            _iconVida[3].DOScale(_tamV, 0.5f);
            _iconVida[4].DOScale(0, 0.5f);
            _iconVida[5].DOScale(0, 0.5f);
            
        }
        else if (vida == 5)
        {
            _iconVida[0].DOScale(_tamV, 0.5f);
            _iconVida[1].DOScale(_tamV, 0.5f);
            _iconVida[2].DOScale(_tamV, 0.5f);
            _iconVida[3].DOScale(_tamV, 0.5f);
            _iconVida[4].DOScale(_tamV, 0.5f);
            _iconVida[5].DOScale(0, 0.5f);
            
        }

        else if (vida > 5)
        {
            _iconVida[0].DOScale(_tamV, 0.5f);
            _iconVida[1].DOScale(_tamV, 0.5f);
            _iconVida[2].DOScale(_tamV, 0.5f);
            _iconVida[3].DOScale(_tamV, 0.5f);
            _iconVida[4].DOScale(_tamV, 0.5f);
            _iconVida[5].DOScale(_tamV, 0.5f);
            
        }

    }
}
