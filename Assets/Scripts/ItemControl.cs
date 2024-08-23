using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl: MonoBehaviour
{
    public ItemDados _itemDados; // vsd
    SpriteRenderer _image;

    void Start()
    {
        _image = GetComponent<SpriteRenderer>();
        _image.sprite = _itemDados.ImageItem;
    }
}
