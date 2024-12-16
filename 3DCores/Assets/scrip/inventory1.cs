using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory1 : MonoBehaviour
{
    public List<item_log1> items = new List<item_log1>(); // Lista de objetos del inventario
    public inventoryUI1 updateInventario; // actualiza el inventario 
    public int maxItem = 3; // maximo de items 
    public inventory1 playerInventory;     // Referencia al inventario del jugador

    public bool AddItem(item_log1 newItem)
    {
        if (newItem.isAcumulable)
        {
            item_log1 item = items.Find(i => i.name == newItem.name); // Buscar si ya existe el objeto en el inventario
            if (item != null)
            {
                item.qty += newItem.qty;  // Si el objeto ya existe, simplemente aumenta la cantidad
            }
            else
            {
                if (items.Count < maxItem)
                {
                    items.Add(newItem);  // Si no, lo añade como un nuevo objeto
                }

                else
                {
                    Debug.Log("Inventario lleno, no puedes añadir más ítems.");
                    return false;

                }
            }
        }
        else // si no es acumulable
        {
            if (!items.Exists(i => i.name == newItem.name))
            {
                if (items.Count < maxItem)
                {
                    items.Add(newItem);  // Si no, lo añade como un nuevo objeto
                }

                else
                {
                    Debug.Log("Inventario lleno, no puedes añadir más ítems.");
                    return false;

                }
            }
            else
            {
                Debug.Log("Inventario lleno, no puedes añadir más ítems.");
                return false;
            }
        }


        // Podemos actualizar la UI aquí, si es necesario
        Debug.Log("Añadido: " + newItem.name);
        updateInventario.UpdateUI();
        return true;
    }


    // Método para eliminar un objeto del inventario
    public void RemoveItem(string itemName)
    {
        item_log1 item = items.Find(i => i.name == itemName);
        if (item != null)
        {
            items.Remove(item);
            Debug.Log("Eliminado: " + item.name);
        }
        else
        {
            Debug.Log("El objeto no existe en el inventario.");
        }
        updateInventario.UpdateUI();
    }
    public void UseItem(string itemName)
    {
        item_log1 item = items.Find(i => i.name == itemName);
        if (item != null)
        {
            switch (item.itemType)
            {
                case ItemType.Potion:
                    item.qty--;
                    if (item.qty <= 0)
                    {
                        playerInventory.RemoveItem(itemName);
                    }
                    break;
                case ItemType.Coin:
                    Debug.Log("Monedas recogidas.");
                    break;
                case ItemType.Weapon:
                    Debug.Log("Has equipado el arma: " + itemName);
                    break;
                default:
                    Debug.Log("Este ítem no tiene uso.");
                    break;
            }
        }
        updateInventario.UpdateUI();

    }


}
