using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public TextMeshProUGUI _pontos;
    public int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log(col.gameObject.name);
        /*_score = Camera.main.GetComponent<MiniGameController>()._score;
        _pontos = Camera.main.GetComponent<MiniGameController>()._pontos;
        _pontos.text = Camera.main.GetComponent<MiniGameController>()._score + "Pontos";*/
        _score++;
        _pontos.text = "Pontos: " + _score;
        Destroy(col.gameObject);
    }
}
