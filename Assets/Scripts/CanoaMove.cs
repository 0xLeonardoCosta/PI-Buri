using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using DG.Tweening;

public class CanoaMove : MonoBehaviour
{
    public MoveControl _moveBuri;

    public GameObject _botaoCanoa;
    public GameObject _textoSubirCanoa;
    
    [SerializeField] GameObject _rio;

    [SerializeField] GameObject _tutoralSairCanoa1, _tutoralSairCanoa2;
    [SerializeField] GameObject _saindoMissao;

    [SerializeField] Transform _player;
    
    [SerializeField] Transform _buriPosCanoa;

    [SerializeField] Vector3 _buriPosSpawn;

    [SerializeField] Transform _pivot;

    [SerializeField] Vector2 _input;

    [SerializeField] Vector3 _movement;

    [SerializeField] public bool _utilizarCanoa;
    [SerializeField] bool _utilizandoCanoa;

    [SerializeField] Rigidbody _rb;
    [SerializeField] BoxCollider _col;

    [SerializeField] float _velocidadeCurva;
    [SerializeField] float _velocidade;
    GameManagerBuri _managerBuri;
    GaaameController _gaaameController;
    bool _dentroCanoa;

    [SerializeField] Transform _hudInforMini;

    TutorControl _tutorControl;

    void Start()
    {
        _gaaameController = Camera.main.GetComponent<GaaameController>();
        _player = Camera.main.GetComponent<GaaameController>()._player;
        _managerBuri =Camera.main.GetComponent<GameManagerBuri>();
        _rb = GetComponent<Rigidbody>();
        _tutorControl = Camera.main.GetComponent<GaaameController>()._canvasHud.GetComponent<TutorControl>();
        _col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (_moveBuri != null) // Se a variavel _moveBuri estiver atribuida, ou seja, não esteja vazia
        {
            _input = _moveBuri._input;
         //   CanoaMovement();
        }
    }

    private void FixedUpdate()
    {
        if (_moveBuri != null) // Se a variavel _moveBuri estiver atribuida, ou seja, não esteja vazia
        {
            _input = _moveBuri._input;
            CanoaMovement();
        }
    }
    public void PressionarBotao()
    {
        if (_utilizandoCanoa == false)
        {
            _utilizandoCanoa = true;
        }
        else if (_utilizandoCanoa == true)
        {
            _utilizandoCanoa = false;
        }
    }
    public void CanoaMovement()
    {
        if (_utilizandoCanoa)
        {
            _managerBuri._tutoral.SetActive(false);
            _managerBuri.TutoralSairCanoa(true);
            StartCoroutine("FecharFazendoFade", 4f);
            _rio.GetComponent<MeshCollider>().isTrigger = false;
            _moveBuri._usandoCanoa = true;
            _moveBuri._pivotCamera = transform;
            _moveBuri._variacaoVelocidadeAndar = 0;
            _moveBuri._variacaoAltura = 0;
            _moveBuri._checkGround = false;
            _moveBuri._checkMover = false;
            _moveBuri._buriTriguer.GetComponent<CapsuleCollider>().enabled = false;
            _col.isTrigger = false;
            _col.size = new Vector3(3.4f, 11.02f, 4.4f);

            //Botar o Buri Sentado na canoa
            _player.SetParent(_buriPosCanoa);
            _player.transform.localEulerAngles = new Vector3(0,0,0);
            _player.transform.localPosition = Vector3.zero;

            //transform.Translate(Vector3.up * _velocidade * _input.y);

            //utlizando o rigidbody
            Vector3 moveDirection = transform.up * _input.y * _velocidade;
            _rb.MovePosition(_rb.position + moveDirection * Time.fixedDeltaTime);

            //transform.RotateAround(_pivot.position, Vector3.up, _velocidadeCurva * _input.x * Time.deltaTime);

            if (_input.x < 0)
            {
                _pivot.localPosition = new Vector3(5f,0,0);
            }
            if (_input.x > 0)
            {
                _pivot.localPosition = new Vector3(-5f,0,0);
            }
            // Rotação em torno do eixo Y mantendo o pivô constante
            Quaternion deltaRotation = Quaternion.Euler(Vector3.back * -_input.x * _velocidadeCurva * Time.fixedDeltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
        else
        {
            _managerBuri.TutoralSairCanoa(false);
            //Quando Buri sair da canoa
            _rio.GetComponent<MeshCollider>().isTrigger = true;
            _moveBuri._usandoCanoa = false;
            _moveBuri._pivotCamera = _moveBuri.transform;
            _moveBuri._variacaoVelocidadeAndar = Mathf.Abs(_moveBuri._input.x) + Mathf.Abs(_moveBuri._input.y);
            _moveBuri._variacaoAltura = _moveBuri._controller.velocity.y;
            _moveBuri._checkGround = _moveBuri._controller.isGrounded;
            _moveBuri._checkMover = true;
            _moveBuri._buriTriguer.GetComponent<CapsuleCollider>().enabled = true;
            _moveBuri._remo.SetActive(false);
            _col.isTrigger = true;
            _col.size = new Vector3(11,15,5);
            _player.SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LimiteMapa"))
        {
            //Debug.Log("SaindoDaMissao");
            //_saindoMissao.SetActive(true);
            StartCoroutine("DialogoSaindoDaMissao", 0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("LimiteMapa"))
        {
            //Debug.Log("VoltandoPraMissao");
            StartCoroutine("DialogoVoltandoMissao", 0f);
        }
    }
    IEnumerator DialogoSaindoDaMissao()
    {
        yield return new WaitForSeconds(0f);
        _saindoMissao.GetComponent<Image>().DOFade(1, .25f);
        _saindoMissao.GetComponentInChildren<Text>().DOFade(1, .25f);
    }
    IEnumerator DialogoVoltandoMissao()
    {
        yield return new WaitForSeconds(2f);
        _saindoMissao.GetComponent<Image>().DOFade(0, .25f);
        _saindoMissao.GetComponentInChildren<Text>().DOFade(0, .25f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // _moveBuri = other.GetComponent<MoveControl>();
           // _botaoCanoa.SetActive(true);
            
        }
        if (other.gameObject.CompareTag("MiniGame"))
        {
            _gaaameController._btMiniGame.SetActive(true);
            this._hudInforMini.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Missao"))
        {
           // _tutorControl.TextTutorOM(2);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  //&& !_utilizandoCanoa)
        {
            if (other.GetComponent<MoveControl>()._usandoCanoa)
            {
              //  _botaoCanoa.SetActive(false);
             //   _moveBuri = null;
             //   Debug.Log("Saiu canoa");
            }
            if (other.gameObject.CompareTag("MiniGame"))
            {
                _gaaameController._btMiniGame.SetActive(false);
                
            }

        }
    }

    IEnumerator FecharFazendoFade()
    {
        yield return new WaitForSeconds(5f);
        //Debug.Log("Sumir");
        _tutoralSairCanoa1.GetComponent<Image>().DOFade(0, 4f);
        _tutoralSairCanoa1.GetComponentInChildren<Text>().gameObject.SetActive(false);
        _tutoralSairCanoa2.GetComponent<Image>().DOFade(0, 4f);
        _tutoralSairCanoa2.GetComponentInChildren<Text>().gameObject.SetActive(false);
    }
}
