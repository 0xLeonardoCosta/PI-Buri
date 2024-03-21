using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Transform _buriLogo, _pos;

    private void Start()
    {
        StartCoroutine(MoverBuriLogo());
    }

    IEnumerator MoverBuriLogo()
    {
        _buriLogo.DOMove(_pos.position, 2f);
        yield return new WaitForSeconds(0f);
    }
}
