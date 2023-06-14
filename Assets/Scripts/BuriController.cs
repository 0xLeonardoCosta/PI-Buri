using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuriController : MonoBehaviour
{
    [SerializeField] string _nome;

    [SerializeField] float _velocidade;
    [SerializeField] Vector3 _posicao;

    [SerializeField] float _moveV;
    [SerializeField] float _moveH;

    void Start()
    {
             
    }

    void Update()
    {
        Andar();
        Pular();
        Atirar();
        Trepar();
    }

    void Andar()
    {
        _moveH = Input.GetAxisRaw("Horizontal");
        _moveV = Input.GetAxisRaw("Vertical");

        _posicao = new Vector3 (_moveH, 0,_moveV);

        transform.Translate(_posicao * _velocidade * Time.deltaTime);
    }

    void Pular()
    {

    }

    void Atirar()
    {

    }

    void Trepar()
    {

    }
}