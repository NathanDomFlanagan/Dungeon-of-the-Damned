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
    private bool isActive;

    public Transform itemContent;
    public Transform equipItemContent;
    public Transform statsScreen;

    public GameObject inventoryItem;

    public PlayerModel pModel;
    public static readonly int MAXINVENTORY = 10;
    public int inventorySpace = 0;

    public ItemInventoryController[] invItems;

    public bool equip1 = false;
    public bool equip2 = false;

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
        displayStats();
        displayStatsText();
        setInvItems();
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

    public void displayEquip(Items item)
    {
        if(equip1 == false)
        {
            var Armor = GameObject.Find("Armor/Image").GetComponent<Image>();
            Armor.sprite = item.itemIcon;
            equip1 = true;

        }
    }

    public void unequipItem()
    {
        var Armor = GameObject.Find("Armor/Image").GetComponent<Image>();
        Armor.sprite = null;
        equip1 = false;


    }


    public void displayStats()
    {
        var playerSprite = GameObject.Find("PlayerSprite/sprite").GetComponent<Image>();
        playerSprite.sprite = this.GetComponent<SpriteRenderer>().sprite;

    }

    public void displayStatsText()
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
