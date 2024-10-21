using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class moveleandro : MonoBehaviour
{
    public Vector3 _move;
    Rigidbody2D _rigidboody2;
    public TextMeshPro _textPlayer;
    public bloboNumero _blocoNumero;
    public ContaLeandro _contaLeandro;

    // Start is called before the first frame update
    void Start()
    {
        _rigidboody2= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidboody2.velocity = _move;
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>().normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bloco"))
        {
            _blocoNumero = collision.gameObject.GetComponent<bloboNumero>();
            _textPlayer.text = "" + _blocoNumero._numeroBloco;
        }

        if (collision.gameObject.CompareTag("contaleandro"))
        {
            _contaLeandro = collision.gameObject.GetComponent<ContaLeandro>();
            if(_contaLeandro._resp== _blocoNumero._numeroBloco)
            {
                Debug.Log("Tcholou"); // acertou
                _contaLeandro.ContaSetLeandro("" + _blocoNumero._numeroBloco);
            }
            else
            {
                Debug.Log("Destcholou"); // errou
            }
        }
    }
}
