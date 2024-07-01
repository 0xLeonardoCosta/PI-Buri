using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public TextMeshProUGUI _pontos;
    public int _score = 0;
    public int _resultadoContaReal;
    public int _numbProblemas=1;

    public List<Conta> _problemas;
   



    // Start is called before the first frame update
    void Start()
    {
        ChamarQuest();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        // Debug.Log(col.gameObject.name);
        /*_score = Camera.main.GetComponent<MiniGameController>()._score;
        _pontos = Camera.main.GetComponent<MiniGameController>()._pontos;
        _pontos.text = Camera.main.GetComponent<MiniGameController>()._score + "Pontos";*/
        _score++;
        _pontos.text = "Pontos: " + _score;
        collision.GetComponent<projetil>().DestroyItem();
        //Destroy(col.gameObject);
    }

    public void ChamarQuest()
    {
        _problemas[_numbProblemas].gameObject.SetActive(false);
        Debug.Log("desativar "+ _problemas[_numbProblemas].gameObject.name);

        if (_numbProblemas <= _problemas.Count-1)
        {
            _problemas[_numbProblemas].gameObject.SetActive(true);
            _numbProblemas++;
            Debug.Log("ativar " + _problemas[_numbProblemas].gameObject.name);

        }
       
    } 
}
