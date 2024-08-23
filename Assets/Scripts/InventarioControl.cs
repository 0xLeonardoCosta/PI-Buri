using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioControl : MonoBehaviour
{
    public List<SlotControl>  _SlotArmas = new List<SlotControl>();
    public PlayerItens _playerItens;

    public void EquiparPlayerArma(SlotControl slotControl)
    {
        _playerItens._itemDados = slotControl._itemDados;
        _playerItens._spriteRenderer.sprite = slotControl._itemDados.ImageItem;
    }

    public void RemoverPlayerArma(SlotControl slotControl)
    {
        slotControl.ImageSlot(null);
        slotControl.CheckSlot = false;
        _playerItens._spriteRenderer.sprite = null;

        slotControl._itemDados = null;
        _playerItens._itemDados = null;

    }


}

