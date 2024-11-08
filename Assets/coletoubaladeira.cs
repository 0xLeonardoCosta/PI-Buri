using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletoubaladeira : MonoBehaviour
{
    private CanoaMove CanoaMove;
    [SerializeField] GaaameController _controller;
    // Start is called before the first frame update
    void Start()
    {
        CanoaMove = Camera.main.GetComponent<GaaameController>()._canoa.GetComponent<CanoaMove>();
        _controller = Camera.main.GetComponent<GaaameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //CanoaMove.coletouBaladeira = true;
            _controller._player.GetComponent<MoveControl>()._coletouBaladeira = true;
            _controller._player.GetComponent<MoveControl>().ReativarBaladeira();
            gameObject.SetActive(false);
        }
    }
}
