using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro2ddd : MonoBehaviour
{
    public AudioClip _tiroSom;  // Arraste o arquivo de som aqui no Inspector
    private AudioSource _audioSource;

    void Start()
    {
        // Obt�m o componente AudioSource do objeto
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Se apertar o bot�o de tiro, por exemplo, o bot�o esquerdo do mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        // Coloque aqui a l�gica do tiro (instancia��o de bala, efeitos, etc.)

        // Reproduz o som do tiro
        _audioSource.PlayOneShot(_tiroSom);
    }
}
