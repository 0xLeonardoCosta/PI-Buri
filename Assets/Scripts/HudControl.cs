using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudControl : MonoBehaviour
{
    [SerializeField] List <MenuControl> _menuControl;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _menuControl.Count; i++)
        {
            _menuControl[i].transform.localScale = Vector3.zero;
            _menuControl[i].gameObject.SetActive(false);
        }

        _menuControl[0].gameObject.SetActive(true);
        _menuControl[0].ItensOff();
        _menuControl[0].transform.DOScale(1, .25f);
        _menuControl[0].ChamarMenu();
    }

    public void ChamarMEnuControl (int value)
    {
        for (int i = 0; i < _menuControl.Count; i++)
        {
            _menuControl[i].transform.localScale = Vector3.zero;
            _menuControl[i].ItensOff();
            _menuControl[i].gameObject.SetActive(false);
        }

        _menuControl[value].gameObject.SetActive(true);
        _menuControl[value].transform.DOScale(1, .25f);
        _menuControl[value].ChamarMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
