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
    public float gravity = -9.81f; // Valor da gravidade
    private Vector3 movimento;

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

        float andar = entradasJogador.magnitude;

        animator.SetFloat("InputX", entradasJogador.x);
        animator.SetFloat("InputY", entradasJogador.y);
        animator.SetFloat("Andar", andar);

        Vector3 move = new Vector3(entradasJogador.x, 0f, entradasJogador.y);
        if (move != Vector3.zero)
        {
            // Rotacionar o personagem para a direção do movimento
            transform.rotation = Quaternion.LookRotation(move);
        }

        // Aplicar movimento e gravidade
        movimento = move * velocidade;
        movimento.y = gravity * Time.deltaTime; // Aplicar gravidade
        character.Move(movimento * Time.deltaTime);
    }
}