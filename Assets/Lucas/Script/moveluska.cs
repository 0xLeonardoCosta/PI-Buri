using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class moveluska : MonoBehaviour
{
    public Vector3 _move;
    Rigidbody2D _rigidboody2;
    public TextMeshPro _textPlayer;
    public bloboNumeroLuska _blocoNumero;
    public ContaLuska _contaLuska;

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
            _blocoNumero = collision.gameObject.GetComponent<bloboNumeroLuska>();
            _textPlayer.text = "" + _blocoNumero._numeroBloco;
        }
        if (collision.gameObject.CompareTag("contaLuska"))
        {
            _contaLuska = collision.gameObject.gameObject.GetComponent<ContaLuska>();
            if(_contaLuska._resp== _blocoNumero._numeroBloco)
            {
                _contaLuska.ContaSetLuska("" + _blocoNumero._numeroBloco);
                Debug.Log("Acertou");
            }
            else
            {
                Debug.Log("errou");
            }
            
        }
    }
}
