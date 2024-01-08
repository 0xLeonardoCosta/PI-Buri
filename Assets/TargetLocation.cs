using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocation : MonoBehaviour
{
    public List<Transform> _targetList;
    public Transform inimigoMaisProximo;
    [SerializeField] float distanciaMinima;


    void Start()
    {
        
    }


    void Update()
    {
        inimigoMaisProximo = EncontrarInimigoMaisProximo();

        // Agora 'inimigoMaisProximo' contém o Transform do inimigo mais próximo,
        // você pode fazer o que quiser com essa informação.
    }

    private Transform EncontrarInimigoMaisProximo()
    {
        inimigoMaisProximo = null;
        distanciaMinima = float.MaxValue;

        for (int i = 0; i < _targetList.Count; i++)
        {
            float distancia = Vector3.Distance(_targetList[i].position, transform.position);

            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                inimigoMaisProximo = _targetList[i];
            }
        }

        return inimigoMaisProximo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            _targetList.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            _targetList.Remove(other.transform);
        }
    }
}
