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

        // Obter a rotação do jogador como um quaternion
        Quaternion playerRotation = _player.rotation;

        // Interpolar entre a rotação anterior e a rotação atual do jogador com um leve atraso
        Quaternion targetRotation = Quaternion.Lerp(_prevPlayerRotation, playerRotation, _lerp * Time.deltaTime);
        transform.rotation = targetRotation;

        // Atualizar a rotação anterior para a próxima iteração
        _prevPlayerRotation = targetRotation;
    }
}
