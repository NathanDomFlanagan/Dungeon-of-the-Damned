using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    //Public static instance so that InventoryManager can be referred
    public static InventoryManager Instance;

    //
    private List<Items> inventory = new List<Items>();
    private List<Items> equipped = new List<Items>();

    public Items item;
    private Items itemdata;
    private bool isActive;

    public Transform itemContent;
    public Transform equipItemContent;
    public Transform statsScreen;

    public GameObject inventoryItem;
    private GameObject tempItem;

    public PlayerModel pModel;
    public static readonly int MAXINVENTORY = 10;
    public int inventorySpace = 0;

    public ItemInventoryController[] invItems;
    public ItemInventoryController[] equipItems;

    void Awake()
    {
        Instance = this;
        pModel = GetComponent<PlayerModel>();
    }

    void Update()
    {
        if(isActive)
        {
            displayStatsText();
        }
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
    
    public void Unequip(Items item)
    {
        equipped.Remove(item);
        pModel.CalculateStats();
        
    }

    private void displayThings()
    {
        displayStats();
        displayStatsText();
        setInvItems();
    }

    public void ListItems()
    {
        foreach (var item in inventory) 
        {
                GameObject obj = Instantiate(inventoryItem, itemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();
                tempItem = obj;


                itemName.text = item.itemName;
                itemIcon.sprite = item.itemIcon;
            
        }
        displayThings();
    }

    public void equipItem(Items item)
    {
        if(equipped.Count >= 2)
        {
            return;
        } else
        {
            equipped.Add(item);
        }
        displayEquippedItems();
        setEquipItems();
    }

    public void displayEquippedItems()
    {
        foreach(var item in equipped)
        {
            Instantiate(inventoryItem, equipItemContent);
            var itemName = inventoryItem.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = inventoryItem.transform.Find("ItemImage").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
    }

    private void setEquipItems()
    {
        equipItems = equipItemContent.GetComponentsInChildren<ItemInventoryController>();
        for(int i =0;i<equipped.Count;i++)
        {
            equipItems[i].AddItem(equipped[i]);
        }
    }

    public void SetActive(bool boo)
    {
        isActive = boo;
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

    public void cleanEquip()
    {
        foreach (Transform item in equipItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    private void displayStats()
    {
        var playerSprite = GameObject.Find("PlayerSprite/sprite").GetComponent<Image>();
        playerSprite.sprite = this.GetComponent<SpriteRenderer>().sprite;

    }

    private void displayStatsText()
    {
            var playerHP = GameObject.Find("PlayerStats/HP").GetComponent<TMP_Text>();
            var playerDmg = GameObject.Find("PlayerStats/Damage").GetComponent<TMP_Text>();
            var playerSpeed = GameObject.Find("PlayerStats/Speed").GetComponent<TMP_Text>();
            var playerArmour = GameObject.Find("PlayerStats/Armour").GetComponent<TMP_Text>();

            float hp = pModel.getPlayerHealth();
            float dmg = pModel.getPlayerDmg();
            float speed = pModel.getPlayerSpeed();
            float armour = pModel.getPlayerArmour();

            playerHP.text = "HP: " + hp.ToString();
            playerDmg.text = "Damage: " + dmg.ToString();
            playerSpeed.text = "Speed: " + speed.ToString();
            playerArmour.text = "Armour: " + armour.ToString();
    }

}
