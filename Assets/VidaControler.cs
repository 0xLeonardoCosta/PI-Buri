using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaControler : MonoBehaviour
{
    [SerializeField] List<GameObject> _slotVida;
    //0 = 1 vida, 1 = 2 vidas e etc...

    public int _vidaMaxima;
    public int _vidaAtual;
    public int _valorAnterior;


    void Start()
    {
        _vidaMaxima = 6;
        _vidaAtual = _vidaMaxima;
        _valorAnterior = _vidaAtual;
    }

    
    void Update()
    {
        if (_vidaAtual != _valorAnterior)
        {
            VidaCheck();
            _valorAnterior = _vidaAtual;
        }
    }

    void VidaCheck()
    {
        if (_vidaAtual == 6)
        {
            _slotVida[0].SetActive(false);
            _slotVida[1].SetActive(false);
            _slotVida[2].SetActive(false);
            _slotVida[3].SetActive(false);
            _slotVida[4].SetActive(false);
            _slotVida[5].SetActive(true);
            _slotVida[6].SetActive(false);
        }
        if (_vidaAtual == 5)
        {
            _slotVida[0].SetActive(false);
            _slotVida[1].SetActive(false);
            _slotVida[2].SetActive(false);
            _slotVida[3].SetActive(false);
            _slotVida[4].SetActive(true);
            _slotVida[5].SetActive(false);
            _slotVida[6].SetActive(false);
        }
        if (_vidaAtual == 4)
        {
            _slotVida[0].SetActive(false);
            _slotVida[1].SetActive(false);
            _slotVida[2].SetActive(false);
            _slotVida[3].SetActive(true);
            _slotVida[4].SetActive(false);
            _slotVida[5].SetActive(false);
            _slotVida[6].SetActive(false);
        }
        if (_vidaAtual == 3)
        {
            _slotVida[0].SetActive(false);
            _slotVida[1].SetActive(false);
            _slotVida[2].SetActive(true);
            _slotVida[3].SetActive(false);
            _slotVida[4].SetActive(false);
            _slotVida[5].SetActive(false);
            _slotVida[6].SetActive(false);
        }
        if (_vidaAtual == 2)
        {
            _slotVida[0].SetActive(false);
            _slotVida[1].SetActive(true);
            _slotVida[2].SetActive(false);
            _slotVida[3].SetActive(false);
            _slotVida[4].SetActive(false);
            _slotVida[5].SetActive(false);
            _slotVida[6].SetActive(false);
        }
        if (_vidaAtual == 1)
        {
            _slotVida[0].SetActive(true);
            _slotVida[1].SetActive(false);
            _slotVida[2].SetActive(false);
            _slotVida[3].SetActive(false);
            _slotVida[4].SetActive(false);
            _slotVida[5].SetActive(false);
            _slotVida[6].SetActive(false);
        }
        if (_vidaAtual == 0)
        {
            _slotVida[0].SetActive(false);
            _slotVida[1].SetActive(false);
            _slotVida[2].SetActive(false);
            _slotVida[3].SetActive(false);
            _slotVida[4].SetActive(false);
            _slotVida[5].SetActive(false);
            _slotVida[6].SetActive(true);
        }
    }

    public void RecebeuDano()
    {
        _vidaAtual -= 1;
        Debug.Log("PerdeuVida");

        if (_vidaAtual <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void GanhouVida()
    {
        _vidaAtual += 1;

        if (_vidaMaxima >= 6)
        {
            _vidaAtual = 6;
            Debug.Log("VidaMaxima");
        }

        Debug.Log("VidaAtual: "+_vidaAtual);
    }
}