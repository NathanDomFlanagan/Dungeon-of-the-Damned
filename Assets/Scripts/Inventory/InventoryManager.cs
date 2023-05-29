using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> inventory = new List<Items>();
    private Items item;

    public Transform itemContent;
    public GameObject inventoryItem;

    public PlayerModel pModel;
    public static readonly int MAXINVENTORY = 10;
    public int inventorySpace = 0;

    public ItemInventoryController[] invItems;

    void Awake()
    {
        Instance = this;
        pModel = GetComponent<PlayerModel>();
    }

    public void Add(Items item)
    {
        if(inventorySpace == MAXINVENTORY)
        {
            return;
        } else
        {
            inventory.Add(item);
            inventorySpace++;
        }
    }

    public void Remove(Items item)
    {
        if (inventorySpace <= 0)
        {
            return;
        } else
        {
            inventory.Remove(item);
            inventorySpace--;
        }
    }

    public void ListItems()
    {
        foreach (var item in inventory)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
        setInvItems();
    }

    private void setInvItems()
    {
        invItems = itemContent.GetComponentsInChildren<ItemInventoryController>();
        for (int i = 0; i < inventory.Count; i++)
        {
            invItems[i].AddItem(inventory[i]);
        }
    }

    public void cleanInventory()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }
}
