using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    GridItem _gridItem;

    // Start is called before the first frame update
    void Start()
    {
        _gridItem = Camera.main.GetComponent<GridItem>(); //dfdf

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemTag"))
        {
           ItemControlInventario _itemObj = collision.GetComponent<ItemControlInventario>();

            for (int i = 0; i < _gridItem._itemArmas.Count; i++)
            {

                {
                   if (_gridItem._itemArmas[i].GetComponent<SlotItem>()._ocupado == false)
                    {
                       _gridItem._itemArmas[i].sprite = _itemObj._itemInventario._img;
                      _gridItem._itemArmas[i].GetComponent<SlotItem>()._ocupado = true;
                        break;
                    }
                }
            }



            Debug.Log(_itemObj._itemInventario._nome);
        }
    }
}