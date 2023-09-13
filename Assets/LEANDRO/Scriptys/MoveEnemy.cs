using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform[] _pos;
    [SerializeField] int _numberPos;
    [SerializeField] bool _checkPos;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // seta direto no inspetor
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _pos[_numberPos].transform.position;

        //remainingDistance para medir a distancia entre o inimigo e o alvo
        //boleana que usamos para entrar somente uma vez no if
        //Invoke � a fun��o nativa para delay da fun��o
        //_numberPos numero da posi��o que tem q seguir
    }
}
