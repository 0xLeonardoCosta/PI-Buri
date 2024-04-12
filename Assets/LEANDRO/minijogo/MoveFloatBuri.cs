using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveFloatBuri : MonoBehaviour
{
    public TextMeshProUGUI _pontos;

    public float _deslocamentoY;

    public int _score = 0;


    public GameObject _balaProjetil; // vai ser a nossa bala
    public Transform _arma; // posicao de onde vai sair nosso tiro
    private bool _tiro; // vai ser o imput do tiro da nossa arma
    public float _forcadoTiro; // vai ser a velocidade do nosso tiro
    private bool _flipX = false; //vai ser o nosso novo flip

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _deslocamentoY, 0); //hahaa
        _tiro = Input.GetButtonDown("Fire1");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("olhaomacacooooooo");
        _score++;
        _pontos.text = "Pontos: " + _score;
        Destroy(col.gameObject);
    }
}
