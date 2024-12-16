using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemworld1 : MonoBehaviour
{
    public item_log1 item_Log1;
    public inventory1 playerInventory;     // Referencia al inventario del jugador
    public ItemType itemType;
    public Sprite iconSprite;
    public int qty;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            item_log1 newItem = new item_log1(itemType, name.ToString(), iconSprite, qty, IsAcumulable(itemType));
            playerInventory.AddItem(newItem);
            
                gameObject.SetActive(false);    
               // Destruir el objeto en la escena
            
        }
    }

    private bool IsAcumulable(ItemType itemType)
    {
        return itemType == ItemType.Potion || itemType == ItemType.Coin;
    }
}
