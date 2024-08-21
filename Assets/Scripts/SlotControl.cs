using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotControl : MonoBehaviour
{
    [SerializeField] bool _checkSlot;//oioiogbghgh
    [SerializeField] Image _imgItem;
    ItemIventario _itemInventario;
    Button _btSlot;
    [SerializeField] List<Button> _bts;



    private void Start()
    {
        _btSlot = GetComponent<Button>();

        for (int i = 0; i < _bts.Count; i++)
        {
            _bts[i].transform.localScale = Vector3.zero;
            _bts[i].enabled = false;
        }
    }

    public bool CheckSlot
    {
        get { return _checkSlot; }
        set { _checkSlot = value; }
    }

    public void ImageSlot(Sprite image)
    {
        _imgItem.sprite = image;
    }

    public void ItemInventarioSlot(ItemIventario ItemInventariodados)
    {
        _itemInventario = ItemInventariodados;
    }

    public void BtsOn(bool on)
    {


        for (int i = 0; i < _bts.Count; i++)
        {
            if (on == true)
            {
                _btSlot.enabled = false;
                //_bts[i].transform.DOScale(1, .25f);
                //_bts[i].enabled = true;
            }

            else
            {
                _btSlot.enabled = true;
                //_bts[i].transform.DOScale(0, .25f);
               // _bts[i].enabled = false;
            }
        }
    }
}
