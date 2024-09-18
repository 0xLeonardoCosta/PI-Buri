using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class MoveFloatBuri : MonoBehaviour
{
    //public TextMeshProUGUI _pontos;

    public float _deslocamentoY;
    [SerializeField] bool _atirar;
    public Vector3 _input;
    //public int _score = 0;


    public GameObject _balaProjetil; // vai ser a nossa bala
    public Transform _arma; // posicao de onde vai sair nosso tiro
    private bool _tiro; // vai ser o imput do tiro da nossa arma
    public float _forcadoTiro; // vai ser a velocidade do nosso tiro
    private bool _flipX = false; //vai ser o nosso novo flip
    [SerializeField] float _timer, _timerValue, _speed;

    [SerializeField] UnityEngine.UI.Button _botaoVoltarPraXimba;


    Animator _anim;

    bool _isBala;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _timerValue;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula a posição alvo para onde o objeto deve se deslocar
        Vector3 targetPosition = new Vector3(transform.position.x +_input.x * _speed * Time.deltaTime, transform.position.y, transform.position.z);

        // Interpola gradualmente entre a posição atual e a posição alvo
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        //new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _deslocamentoY, transform.position.z); //position
        //_tiro = Input.GetButtonDown("Fire1");//espaço


        if (_atirar == true)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _atirar = false;
                _timer = _timerValue;
            }
        }

        _anim.SetBool("Atirar", _atirar);
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("olhaomacacooooooo");
        _score++;
        _pontos.text = "Pontos: " + _score;
        Destroy(col.gameObject);
    }
    */

    private void Atirar()
    {
        _atirar = true;
        GameObject _temp = Instantiate(_balaProjetil);
        _temp.transform.position = _arma.position;
        _temp.GetComponent<Rigidbody2D>().velocity = new Vector2(_forcadoTiro, 0);
        Destroy(_temp.gameObject, 3f);
        
        
    }

    public void SetMove(InputAction.CallbackContext value) //Input direcional X e Z (Input System)
    {
        _input = value.ReadValue<Vector3>();
        //_amplitudeAnalogico = _input.magnitude;
        //_speed = Mathf.Lerp(_speedMin, _speedMax, _amplitudeAnalogico);

    }
    public void SetPular(InputAction.CallbackContext value) //Pulo: true ou false
    {
        if (!_isBala)
        {
            _isBala = true;
            Invoke("TimeTiro", 0.5f);
            Atirar();
        }
       

    }

    public void SetInteragir(InputAction.CallbackContext value) //Abrir Minigame
    {
        if (Camera.main.GetComponent<MiniGameController>()._podeSair == true)
        {
            _botaoVoltarPraXimba.onClick.Invoke();
        }
    }

    void TimeTiro()
    {
        _isBala = false;
    }
}


