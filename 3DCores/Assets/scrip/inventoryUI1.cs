using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI1 : MonoBehaviour
{
    public inventory1 inventory;       // Referencia al inventario
    public Transform itemsParent;     // El padre de los slots de la UI
    public GameObject itemSlotPrefab; // Prefab de un slot de inventario  
    public void UpdateUI()   //Método para actualizar la UI
    {
        // Limpiar slots anteriores
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }
        // Crear un nuevo slot para cada objeto en el inventario
        foreach (item_log1 item in inventory.items)
        {

            GameObject newItemSlot = Instantiate(itemSlotPrefab, itemsParent);
            newItemSlot.GetComponentInChildren<TMP_Text>().text = item.name + (item.isAcumulable? item.qty: ("")); 
            newItemSlot.GetComponentInChildren<Image>().sprite = item.iconSprite;
        }
    }
}
