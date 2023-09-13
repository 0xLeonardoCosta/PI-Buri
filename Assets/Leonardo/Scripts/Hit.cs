using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    Animator _anim;

    public GameObject _pai;

    public bool _ihHit = false;
    bool _exitingCollider = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "AtackCol")
        {
            print("TocouNoCollider");
            _exitingCollider = false;
            _ihHit = true;
            //Morte();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "AtackCol")
        {
            Invoke("SetHitToFalse", 5f);
            _exitingCollider = true;            
        }
    }
    private void SetHitToFalse()
    {
        // Esta fun��o ser� chamada ap�s 5 segundos, apenas se o jogador n�o sair do colisor antes disso
        if (!_exitingCollider)
        {
            _ihHit = false;
        }
    }

    void Morte()
    {
        _pai.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
