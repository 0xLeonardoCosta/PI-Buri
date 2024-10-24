using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public TextMeshProUGUI _pontos;
    public int _score = 0;
    public int _resultadoContaReal;
    public int _numbProblemas;

    public List<Conta> _problemas;

    public int _numbQuant;
    public List<Transform> _posNumeros;
    public List<Transform> _numeros;

    public int _scoreAcerto;

    [SerializeField] Transform _parabens;
    [SerializeField] Transform _brasao;
    [SerializeField] public Transform _botaoVoltarPraXimba;
    [SerializeField] Transform _hudCarregamento;

    [SerializeField] private Slider _barraDeProgresso;

    [SerializeField] private TextMeshProUGUI _mensagemTexto;

    public bool _podeSair;

    public AudioClip _somMorte;  // Som da morte (vinculado no Inspector)
    private AudioSource _audioSource;

    public int playerN;
    public int player1pontos;
    public int player2Pontos;

    public TextMeshProUGUI[] _textMeshpontos;



    // Start is called before the first frame update
    void Start()
    {
        Shuffle(_problemas);
        Shuffle2(_numeros);
        ChamarQuest();
        Invoke("CaiNumero", 2);

       // Debug.Log(_numeros.Count);

        this._barraDeProgresso.gameObject.SetActive(false);
        this._hudCarregamento.gameObject.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
    }

    void CaiNumero()
    {
        _numeros[_numbQuant].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _numeros[_numbQuant].gameObject.SetActive(true);
        _numeros[_numbQuant].transform.position = _posNumeros[0].position;
        _numeros[_numbQuant].GetComponent<HitNumeros>()._particula.Stop();
        _numeros[_numbQuant].GetComponent<HitNumeros>().Textura.enabled = true;
        _numbQuant++;
        if(_numbQuant>= _numeros.Count)
        {
            _numbQuant = 0;
            Shuffle2(_numeros);
        }

        if (_scoreAcerto >= _problemas.Count)
        {
            // _numbQuant = 0;
            //  Shuffle2(_numeros);
            Debug.Log("Fim de game");
            CheckParabens();




        }
        else
        {
            Invoke("CaiNumero", 2);
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        // Debug.Log(col.gameObject.name);
        /*_score = Camera.main.GetComponent<MiniGameController>()._score;
        _pontos = Camera.main.GetComponent<MiniGameController>()._pontos;
        _pontos.text = Camera.main.GetComponent<MiniGameController>()._score + "Pontos";*/
        _score++;
        _pontos.text = "Pontos: " + _score;
        
        collision.GetComponent<projetil>().DestroyItem();
        
        //Destroy(col.gameObject);
    }

    public void ChamarQuest()
    {
       
            // _problemas[_numbProblemas].gameObject.SetActive(false);
            // Debug.Log("desativar "+ _problemas[_numbProblemas].gameObject.name);

            for (int i = 0; i < _problemas.Count; i++)
            {
                _problemas[i].gameObject.SetActive(false);
            }
            _problemas[_numbProblemas].gameObject.SetActive(true);
            _numbProblemas++;
            if (_numbProblemas >= _problemas.Count)
            {
                _numbProblemas = 0;
                Shuffle(_problemas);
            }
        

    }

    void Shuffle(List<Conta> lists)
    {
        for (int j = lists.Count - 1; j > 0; j--)
        {
            int rnd = UnityEngine.Random.Range(0, j + 1);
            Conta temp = lists[j];
            lists[j] = lists[rnd];
            lists[rnd] = temp;
        }
    }
    void Shuffle2(List<Transform> lists)
    {
        for (int j = lists.Count - 1; j > 0; j--)
        {
            int rnd = UnityEngine.Random.Range(0, j + 1);
            Transform temp = lists[j];
            lists[j] = lists[rnd];
            lists[rnd] = temp;
        }
    }
    public void CheckParabens()
    {
        
            _parabens.DOScale(20, 0.5f);
            _brasao.DOScale(5, 0.6f);
            _botaoVoltarPraXimba.DOScale(3, 0.7f);

            _podeSair = true;

    }

    public void VoltarXimba()
    {
        this._parabens.gameObject.SetActive(false);
        this._brasao.gameObject.SetActive(false);
        this._botaoVoltarPraXimba.gameObject.SetActive(false);
        this._hudCarregamento.gameObject.SetActive(true);
        this._barraDeProgresso.gameObject.SetActive(true);
        this._mensagemTexto.text = "Carregando...";
        
        StartCoroutine(CarregarCena());

    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asynOperation = SceneManager.LoadSceneAsync("BuriXimba");
        while (!asynOperation.isDone) 
        {
            this._barraDeProgresso.value = asynOperation.progress;
            yield return null;
        }

    }

}
