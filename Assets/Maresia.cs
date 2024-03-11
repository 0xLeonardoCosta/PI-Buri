using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class Maresia : MonoBehaviour
{
    private Transform _player;

    [SerializeField] GameObject _buriSobeDesce;

    [SerializeField] float _alturaPlataforma, _alturaAtual, _incremento;

    [SerializeField] bool _maresia, foiPraBaixo, vaiprabaixo;

    private void Start()
    {
        _player = Camera.main.GetComponent<GaaameController>()._player;
        transform.position = new Vector3 (_player.position.x, _player.position.y -0.50f, _player.position.z);
        //gameObject.GetComponent<MeshCollider>().enabled = false;
    }

    private void Update()
    {
        if (_maresia == false)
        {
            transform.position = new Vector3(_player.position.x, _player.position.y - 0.5f, _player.position.z);
        }
        else if (_maresia == true && !foiPraBaixo)
        {
            transform.SetParent(_player.transform);
            transform.position = new Vector3(_player.position.x, _player.position.y - _alturaPlataforma, _player.position.z);
            foiPraBaixo = true;
        }
        else if (_maresia && foiPraBaixo)
        {
            transform.SetParent(null);
            _alturaAtual = transform.position.y;
            _buriSobeDesce.gameObject.SetActive(true);
            transform.position = new Vector3(_player.position.x, -_alturaPlataforma, _player.position.z);

            /*
            if (_alturaPlataforma > 1 && _alturaPlataforma < 1.21 && vaiprabaixo == true)
            {
                _alturaPlataforma -= _incremento * Time.deltaTime;
                transform.position = new Vector3(_player.position.x, -_alturaPlataforma, _player.position.z);
                if (_alturaPlataforma < 1f)
                {
                    Debug.Log("EntrouAqui1");
                    _alturaPlataforma = 1f;
                    vaiprabaixo = false;
                }
            }

            if (_alturaPlataforma <= 1.2f || _alturaPlataforma < 1f && vaiprabaixo == false)
            {
                Debug.Log("EntrouAqui2");
                transform.position = new Vector3(_player.position.x, -_alturaPlataforma + (_incremento * Time.deltaTime), _player.position.z);
                if (_alturaPlataforma >= 1.2f)
                {
                    _alturaPlataforma = 1.2f;
                    vaiprabaixo = true;
                }
            }*/
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Agua"))
        {
            Debug.Log(other.name);
            _maresia = true;
        }
    }
}

