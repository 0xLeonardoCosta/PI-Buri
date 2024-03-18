using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] List<GameObject> _BtMenu;

    public void Pause()
    {
        StartCoroutine(AbrirMenuPause());
    }
    public void FecharMenu()
    {
        StartCoroutine(FecharMenuPause());
    }

    IEnumerator AbrirMenuPause()
    {
        _pauseMenu.transform.DOScale(1.5f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        _pauseMenu.transform.DOScale(1f, 0.2f);

        for (int i = 0; i < _BtMenu.Count; i++)
        {
            _BtMenu[i].transform.DOScale(1.5f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            _BtMenu[i].transform.DOScale(2.9f, 0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.01f;
    }

    IEnumerator FecharMenuPause()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < _BtMenu.Count; i++)
        {
            _BtMenu[i].transform.DOScale(1.5f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            _BtMenu[i].transform.DOScale(0f, 0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        _pauseMenu.transform.DOScale(0f, 0.2f);
    }
}
