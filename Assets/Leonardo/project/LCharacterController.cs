using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCharacterController : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f; // Velocidade de rotação do jogador
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    [Header("Referências")]
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cameraTransform; // Atribua a câmera no Inspector

    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();   
        cameraTransform = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        // Verifica se está no chão
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Inputs de movimento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Direção do movimento baseada na câmera
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0;
        moveDirection.Normalize();

        // Move o jogador
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Rotaciona o jogador para a direção do movimento (apenas se estiver se movendo)
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}