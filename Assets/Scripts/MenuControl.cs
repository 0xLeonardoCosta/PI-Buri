using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] List<Transform> _itensMenu;

    // Start is called before the first frame update

    private IEnumerator TimeItens()
    {
        //yield return new WaitForSeconds(1);

        for (int i = 0; i < _itensMenu.Count; i++)
        {
            yield return new WaitForSeconds(.25f);
            _itensMenu[i].DOScale(1.5f, .25f);
            yield return new WaitForSeconds(.25f);
            _itensMenu[i].DOScale(1f, 0.25f);
        }
        //_itensMenu[0].GetComponent<Button>().Select();

    }

    public void ChamarMenu()
    {
        _itensMenu[0].GetComponent<Button>().Select();
        StartCoroutine(TimeItens());
    }

    public void ItensOff()
    {
        for (int i = 0; i < _itensMenu.Count; i++)
        {
            _itensMenu[i].localScale = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
