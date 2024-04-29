using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThis : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _lerp;
    private Quaternion _prevPlayerRotation;

    void Start()
    {
        _player = Camera.main.GetComponent<GaaameController>()._player;
        _prevPlayerRotation = _player.rotation;
    }

    void Update()
    {
        transform.position = _player.position;

        // Obter a rota��o do jogador como um quaternion
        Quaternion playerRotation = _player.rotation;

        // Interpolar entre a rota��o anterior e a rota��o atual do jogador com um leve atraso
        Quaternion targetRotation = Quaternion.Lerp(_prevPlayerRotation, playerRotation, _lerp * Time.deltaTime);
        transform.rotation = targetRotation;

        // Atualizar a rota��o anterior para a pr�xima itera��o
        _prevPlayerRotation = targetRotation;
    }
}
