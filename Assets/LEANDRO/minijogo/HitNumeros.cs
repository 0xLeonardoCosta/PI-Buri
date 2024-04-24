using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumeros : MonoBehaviour
{
    //Inimigo2D _inimigo2Dd;
    //NewInimigo2D _inimigo2D2;
    public GameObject _partMorte;
    public GameObject _restart;
    public SpriteRenderer _meshe;
    public Collider2D _collider;


    // Start is called before the first frame update
    void Start()
    {
        //_inimigo2Dd = GetComponent<Inimigo2D>();
        //_inimigo2D2 = GetComponent<NewInimigo2D>();
        _collider = GetComponent<Collider2D>();
        //_meshe = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            StartCoroutine(Morte());
            StartCoroutine(Morte2());
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }

    IEnumerator Morte()
    {
        //_inimigo2Dd._checkMove = false;
        _partMorte.SetActive(true);
        //_meshe.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(0.30f);
        gameObject.SetActive(false);
        _partMorte.SetActive(false);
    }

    IEnumerator Morte2()
    {
        //_inimigo2D2._checkMove2 = false;
        _partMorte.SetActive(true);
        //_meshe.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(0.30f);
        gameObject.SetActive(false);
        _partMorte.SetActive(false);
    }



    IEnumerator RestartTime()
    {

        //_meshe.enabled = false;

        _restart.SetActive(true);
        yield return new WaitForSeconds(0.30f);
        _collider.enabled = true;
        yield return new WaitForSeconds(0.15f);
        // _inimigo2Dd._checkMove = true;

    }

    IEnumerator RestartTime2()
    {

        //_meshe.enabled = false;

        _restart.SetActive(true);
        yield return new WaitForSeconds(0.30f);
        _collider.enabled = true;
        yield return new WaitForSeconds(0.15f);
        //_inimigo2D2._checkMove2 = true;

    }

    public void Restart()
    {
        StartCoroutine(RestartTime());
        StartCoroutine(RestartTime2());
    }
}
