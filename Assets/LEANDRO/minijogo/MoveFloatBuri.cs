using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoveFloatBuri : MonoBehaviour
{
    //public TextMeshProUGUI _pontos;

    public float _deslocamentoY;
    [SerializeField] bool _atirar;

    //public int _score = 0;


    public GameObject _balaProjetil; // vai ser a nossa bala
    public Transform _arma; // posicao de onde vai sair nosso tiro
    private bool _tiro; // vai ser o imput do tiro da nossa arma
    public float _forcadoTiro; // vai ser a velocidade do nosso tiro
    private bool _flipX = false; //vai ser o nosso novo flip
    [SerializeField] float _timer, _timerValue;

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _timerValue;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _deslocamentoY, 0); //hahaa
        _tiro = Input.GetButtonDown("Fire1");

        Atirar();
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
        if(_tiro == true)
        {
            _atirar = true;
            GameObject _temp = Instantiate(_balaProjetil);
            _temp.transform.position = _arma.position;
            _temp.GetComponent<Rigidbody2D>().velocity = new Vector2(_forcadoTiro, 0);
            Destroy(_temp.gameObject, 3f);
        }
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

    
}


