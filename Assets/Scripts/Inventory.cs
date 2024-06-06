using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> inventoryItems = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        inventoryItems.Add(item);
        Debug.Log("Item added to inventory: " + item.name);
    }

    public void RemoveItem(GameObject item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log("Item removed from inventory: " + item.name);
        }
        else
        {
            Debug.Log("Item not found in inventory: " + item.name);
        }


    }

    public string GetInventoryText()
    {
        if (inventoryItems.Count == 0)
        {
            return "Inventory is empty";
        }

        string inventoryText = "Inventory contains:\n";
        foreach (GameObject item in inventoryItems)
        {
            inventoryText += item.name + "\n";
        }
        return inventoryText;
    }

    
    
}

