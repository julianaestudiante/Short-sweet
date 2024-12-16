using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Weapon,
    Coin
}
[System.Serializable]
public class item_log1 
{
    public ItemType itemType;
    public string name;    // Nombre del objeto
    public Sprite iconSprite;        // Icono del objeto (para la UI)
    public int qty;       // Cantidad del objeto
    public bool isAcumulable;



    public item_log1(ItemType itemType, string name, Sprite iconSprite, int qty, bool isAcumulable)
    {
        this.itemType = itemType;
        this.name = name;
        this.iconSprite = iconSprite;
        this.qty = qty;
        this.isAcumulable = isAcumulable;
    }


}
