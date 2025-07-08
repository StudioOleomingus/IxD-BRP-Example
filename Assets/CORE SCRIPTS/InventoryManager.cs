using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private HashSet<string> inventory = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(string itemName)
    {
        if (HasItem(itemName))
            return;

        inventory.Add(itemName);
        Debug.Log($"{itemName} added to inventory");
    }

    public bool HasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        inventory.Remove(itemName);
        Debug.Log($"{itemName} removed from inventory");
    }
}
