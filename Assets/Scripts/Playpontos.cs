using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playpontos : MonoBehaviour
{
    [SerializeField] int _pontos;
    VidaControler _vidaControler;

    void Start()
    {
        _vidaControler = Camera.main.GetComponent<VidaControler>();
    }

    public void SomarPontos(int value)
    {
        _pontos += value; // é a mesma coisa que isso _pontos = _pontos + value 
        _vidaControler._vidaAtual += value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // caramelo perde vida
        {

            collision.gameObject.GetComponent<VidaControler>().GanhouVida();



        }
    }
}