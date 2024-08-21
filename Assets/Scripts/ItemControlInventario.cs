using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControlInventario : MonoBehaviour
{
    public ItemIventario _itemInventario; // vsd
    SpriteRenderer _image;

    void Start()
    {
        _image = GetComponent<SpriteRenderer>();
        _image.sprite = _itemInventario.ImageItem;
    }
}
