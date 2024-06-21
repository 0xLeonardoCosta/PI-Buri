using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanocaMove2 : MonoBehaviour
{
    private Animator animator;
    private Vector2 entradasJogador;

    private int inputXHash;
    private int inputYHash;

    private CharacterController character;
    public float velocidade = 1.5f;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();

        inputXHash = Animator.StringToHash("inputX");
        inputYHash = Animator.StringToHash("inputY");
    }

    // Update is called once per frame
    void Update()
    {
        entradasJogador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));



        animator.SetFloat("InputX", entradasJogador.x);
        animator.SetFloat("InputY", entradasJogador.y);

        character.Move(new Vector3(entradasJogador.x, -9.81f, entradasJogador.y) * velocidade * Time.deltaTime);
    }
}

