using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<GameObject> Items = new List<GameObject>();

    public Transform itemContent;
    public GameObject inventoryItem;

    void Awake()
    {
        Instance = this;
    }

    public void Add(GameObject item)
    {
        Items.Add(item);
    }

    public void Remove(GameObject item)
    {
        Items.Remove(item);
    }

    /*public void ListItems()
    {
        foreach(Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
    }*/
}