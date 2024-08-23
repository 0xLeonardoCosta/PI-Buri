using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    public InventarioControl _control;
    public ItemDados _itemDados;
    public SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _control = Camera.main.GetComponent<InventarioControl>(); //dfdf

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ItemTag"))
        {
           ItemControl itemcontrol = other.GetComponent<ItemControl>();

            for (int i = 0; i < _control._SlotArmas.Count; i++)
            {

                {
                   if (_control._SlotArmas[i].GetComponent<SlotItem>()._ocupado == false)
                    {
                        _control._SlotArmas[i].CheckSlot = true;
                        _control._SlotArmas[i].ImageSlot(itemcontrol._itemDados.ImageItem);
                        _control._SlotArmas[i].DadosSlot(itemcontrol._itemDados);
                        break;
                    }
                }
            }
        }
    }

   
}


