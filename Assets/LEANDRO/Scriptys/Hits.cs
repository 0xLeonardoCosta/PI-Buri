using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hits : MonoBehaviour
{
    Animator _ani;
    public bool _isHit = false;
    [SerializeField] public GameObject _pai;
    [SerializeField] Cooontrol_inimigos _inimigos;


    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
        _inimigos=Camera.main.GetComponent<Cooontrol_inimigos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "AtackCol") // se
        {

            _isHit = true;
           Morte();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "AtackCol") // se
        {

            _isHit = false;
            
        }
    }
    void Morte()
    {
        //_pai.gameObject.SetActive(false); // desativar pai
        transform.parent.gameObject.SetActive(false); // desativar pai
        _inimigos.ZerarTime();
    }
}
