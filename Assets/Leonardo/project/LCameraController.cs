using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCameraController : MonoBehaviour
{
    [Header("Configura��es")]
    public Transform player; // Refer�ncia ao jogador
    public float mouseSensitivity = 2f;
    public float distanceFromPlayer = 5f;
    public float smoothSpeed = 5f;
    public float returnSpeed = 3f;
    public Vector2 pitchMinMax = new Vector2(-20, 80); // Limites verticais

    private float yaw; // Rota��o horizontal (eixo Y)
    private float pitch; // Rota��o vertical (eixo X)
    private Vector3 currentRotation;
    private bool isMouseMoving = false;
    private float mouseTimer = 0f;
    private float mouseInactivityThreshold = 0.5f; // Tempo para retornar ao teclado

    void Start()
    {
        player = Camera.main.GetComponent<LGameController>().player.transform;

        // Inicializa a c�mera atr�s do jogador
        yaw = player.eulerAngles.y;
        pitch = 30f; // �ngulo inicial de inclina��o
    }

    void Update()
    {
        // Controle do mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        isMouseMoving = (Mathf.Abs(mouseX) > 0 || Mathf.Abs(mouseY) > 0);

        if (isMouseMoving)
        {
            mouseTimer = 0f;
            yaw += mouseX * mouseSensitivity;
            pitch -= mouseY * mouseSensitivity; // Inverte o eixo Y se necess�rio
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        }
        else
        {
            mouseTimer += Time.deltaTime;
            // Retorna ao movimento do jogador ap�s inatividade do mouse
            if (mouseTimer >= mouseInactivityThreshold)
            {
                Vector3 playerForward = player.forward;
                float targetYaw = Mathf.Atan2(playerForward.x, playerForward.z) * Mathf.Rad2Deg;
                yaw = Mathf.LerpAngle(yaw, targetYaw, returnSpeed * Time.deltaTime);
            }
        }

        // Atualiza a rota��o suavemente
        currentRotation = Vector3.Slerp(currentRotation, new Vector3(pitch, yaw), smoothSpeed * Time.deltaTime);
        transform.eulerAngles = currentRotation;

        // Posiciona a c�mera atr�s do jogador
        transform.position = player.position - transform.forward * distanceFromPlayer;
    }
}
