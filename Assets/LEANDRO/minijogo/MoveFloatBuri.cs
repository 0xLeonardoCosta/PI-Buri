using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveFloatBuri : MonoBehaviour
{
    public TextMeshProUGUI _pontos;

    public float _deslocamentoY;

    public int _score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _deslocamentoY, 0); //hahaa
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("olhaomacacooooooo");
        _score++;
        _pontos.text = "Pontos: " + _score;
        Destroy(col.gameObject);
    }
}
