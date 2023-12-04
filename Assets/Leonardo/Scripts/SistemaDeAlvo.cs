using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EncontrarInimigoMaisProximo : MonoBehaviour
{
    [SerializeField] Transform[] listaDeTransforms;
    [SerializeField] GameObject seuGameObject;
    [SerializeField] float velocidadeMovimento = 5f;

    ControladorInimigos _control;

    //---------Timer------------
    [SerializeField] float _timer;
    float _timerValue;

    void Start()
    {
        _control = Camera.main.GetComponent<ControladorInimigos>();

        _timer = _timerValue;
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Debug.Log("TransformListaComplete");
            _timer = _timerValue;
        }

        for (int i = 0; i < _control._inimigosTrans.Count; i++)
        {
            listaDeTransforms[i] = _control._inimigosTrans[i];
        }    
    }

    void Update()
    {
        if (listaDeTransforms.Length == 0)
        {
            Debug.LogWarning("A lista de transforms está vazia!");
            return;
        }

        Transform transformMaisProximo = EncontrarTransformMaisProximo();

        if (transformMaisProximo != null)
        {
            MovimentarParaTransform(transformMaisProximo);
        }
    }

    Transform EncontrarTransformMaisProximo()
    {
        Transform transformMaisProximo = null;
        float menorDistancia = Mathf.Infinity;
        Vector3 posicaoJogador = seuGameObject.transform.position;

        foreach (Transform transformAtual in listaDeTransforms)
        {
            float distancia = Vector3.Distance(posicaoJogador, transformAtual.position);
            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                transformMaisProximo = transformAtual;
            }
        }

        return transformMaisProximo;
    }

    void MovimentarParaTransform(Transform alvo)
    {
        float step = velocidadeMovimento * Time.deltaTime;
        seuGameObject.transform.position = Vector3.Lerp(seuGameObject.transform.position, alvo.position, step);
    }
}