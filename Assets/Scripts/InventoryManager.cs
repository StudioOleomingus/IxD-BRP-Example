using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> uiItemSlots = new List<GameObject>();
    public List<Item> items = new List<Item>();

    [System.Serializable]
    public class Item
    {
        public string name;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
