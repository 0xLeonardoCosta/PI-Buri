using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class projetil : MonoBehaviour
{
    public int _score = 0;
    public TextMeshProUGUI _pontos;
    [SerializeField] SpriteRenderer _textura;
    [SerializeField] GameObject _partSaida;
    [SerializeField] Collider2D _Collider2D;
    protected MiniGameController _miniGameController;

   

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _pontos = Camera.main.GetComponent<MiniGameController>()._pontos;
        _textura = GetComponent<SpriteRenderer>();
        _Collider2D = GetComponent<Collider2D>();
        _miniGameController = Camera.main.GetComponent<MiniGameController>();



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

        Debug.Log(col.gameObject.name);
        
        Destroy(col.gameObject);
    }

    public virtual void DestroyItem() 
    { 

    }

    protected virtual void ConstroyItem()
    {

    }

    public virtual SpriteRenderer Textura
    {
        get { return _textura; }
        set { _textura = value; }
    }

    public virtual GameObject PartSaida
    {
        get { return _partSaida; }  //get
        set { _partSaida = value; } // set
    }


}
