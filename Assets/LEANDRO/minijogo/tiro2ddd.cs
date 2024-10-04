using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro2ddd : MonoBehaviour
{
    public AudioClip _tiroSom;  // Arraste o arquivo de som aqui no Inspector
    private AudioSource _audioSource;

    void Start()
    {
        // Obtém o componente AudioSource do objeto
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Se apertar o botão de tiro, por exemplo, o botão esquerdo do mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        // Coloque aqui a lógica do tiro (instanciação de bala, efeitos, etc.)

        // Reproduz o som do tiro
        _audioSource.PlayOneShot(_tiroSom);
    }
}
