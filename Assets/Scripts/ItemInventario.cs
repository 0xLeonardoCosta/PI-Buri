using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item, menuName", menuName = "Item")]

    public class ItemIventario: ScriptableObject
    {
        [SerializeField] string _nome;
        [SerializeField] int _tipo;
        [SerializeField] Sprite _imageItem;

        public int _dano;

    public string Name
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public int Tipo
    {
        get { return _tipo; }
        set { _tipo = value; }
    }

    public Sprite ImageItem
    {
        get { return _imageItem; }
        set { _imageItem = value; }
    }
}


