using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioControl : MonoBehaviour
{
    public List<SlotControl>  _SlotArmas = new List<SlotControl>();
    public PlayerItens _playerItens;
    public GameObject _baladeira;

    public void EquiparPlayerArma(SlotControl slotControl)
    {
        if (slotControl._itemDados.Tipo == 1)//baladeira
        {
            AtivarBaladeira(true);
        }
        else
        {
            _playerItens._itemDados = slotControl._itemDados;
            _playerItens._spriteRenderer.sprite = slotControl._itemDados.ImageItem;
        }
      
    }

    public void RemoverPlayerArma(SlotControl slotControl)
    {
        if (slotControl._itemDados.Tipo == 1)//baladeira
        {
            AtivarBaladeira(false);
        }
        else
        {
            slotControl.ImageSlot(null);
            slotControl.CheckSlot = false;
            _playerItens._spriteRenderer.sprite = null;

            slotControl._itemDados = null;
            _playerItens._itemDados = null;
        }
        

    }

    public void AtivarBaladeira(bool value)
    {
        _baladeira.SetActive(value);
    }


}

