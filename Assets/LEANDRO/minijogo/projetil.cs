using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class projetil : MonoBehaviour
{
    public int _score = 0;
    public TextMeshProUGUI _pontos;

    // Start is called before the first frame update
    void Start()
    {
        _pontos = Camera.main.GetComponent<MiniGameController>()._pontos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log(col.gameObject.name);
        _score++;
        _pontos.text = "Pontos: " + _score;
        Camera.main.GetComponent<MiniGameController>()._score++;
        
        
        
        Destroy(col.gameObject);
    }
}
