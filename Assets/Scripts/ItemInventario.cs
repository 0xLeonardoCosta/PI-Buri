using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item, menuName", menuName = "Item")]

    public class ItemIventario: ScriptableObject
    {
        public string _nome;
        public int _tipo;
        public Sprite _img;
        public int _dano;
    }



