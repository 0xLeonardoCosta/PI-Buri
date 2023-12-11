using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playpontos : MonoBehaviour
{
    [SerializeField] int _pontos;

    // Start is called before the first frame update

    public void SomarPontos(int value)
    {
        _pontos += value; // é a mesma coisa que isso _pontos = _pontos + value 
    }
}
