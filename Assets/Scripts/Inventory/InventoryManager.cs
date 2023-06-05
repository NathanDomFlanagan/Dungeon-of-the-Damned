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

    //Creates two different lists for inventroy and equipped items
    private List<Items> inventory = new List<Items>();
    private List<Items> equipped = new List<Items>();

    //Private variables
    private Items item;
    private bool isActive;

    //Transforms to where item boxes should be instantiated or where text should be displayed
    public Transform itemContent;
    public Transform equipItemContent;
    public Transform statsScreen;

    //GameObject for instantiating
    public GameObject inventoryItem;

    //PlayerModel reference
    private PlayerModel pModel;

    //Max inventory Amount and inventory counter
    public static readonly int MAXINVENTORY = 10;
    public static readonly int MAXEQUIP = 2;
    public int inventorySpace = 0;
    public int equipSpace = 0;

    //Private Data arrays
    private ItemInventoryController[] invItems;
    private ItemInventoryController[] equipItems;

    //On Awake, initializes I.M instance to this
    //Also grabs the local PlayerModel component
    void Awake()
    {
        Instance = this;
        pModel = GetComponent<PlayerModel>();
    }

    //Updates the player's stats but only updates when isActive is true
    void Update()
    {
        if(isActive)
        {
            displayStatsText();
            if(equipItems.Length > 0)
            {
                List<ItemInventoryController> temp = new List<ItemInventoryController>(equipItems);
                temp = temp.Where(ItemInventoryController => ItemInventoryController != null).ToList();
                equipItems = temp.ToArray();
                for (int i = 0; i < equipped.Count; i++)
                {
                    //Stores the data according to the positions of the items in the equipped list
                    equipItems[i].AddItem(equipped[i]);

                }
            }
            if(invItems.Length > 0)
            {
                List<ItemInventoryController> temp = new List<ItemInventoryController>(invItems);
                temp = temp.Where(ItemInventoryController => ItemInventoryController != null).ToList();
                invItems = temp.ToArray();
                for (int i = 0; i < inventory.Count; i++)
                {
                    invItems[i].AddItem(inventory[i]);
                }
            }
        }
    }

    public void ClearInventory()
    {
        //For clearing whole inventory
        foreach(Items item in inventory)
        {
            Destroy(item);
        }

        //For clearing equipped
        foreach(Items item in equipped)
        {
            Destroy(item);
        }
    }

    //Function that adds Items objects to the inventory list
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

    //Function that removes Items objects from the inventory list
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

    //Function that stores the Items objects to the equipped List
    public void equipItem(Items item)
    {
        if (equipSpace == MAXEQUIP)
        {
            return;
        }
        else
        {
            cleanEquip();
            equipped.Add(item);
            displayEquippedItems();
            setEquipItems();
        }
        equipSpace++;
        item.isEquipped = true;
        //Calls the functions to display and set item data
    }

    //Function that unequipes Item objects from the equipped list
    public void Unequip(Items item)
    {
        this.Add(item);
        this.ListItems();
        if (equipped.Count <= 0)
        {
             return;
        }
        else
        {
            equipped.Remove(item);
            if(item.itemType == Items.ItemType.armourEquip)
            {
                pModel.unequipArmour();
            } else if(item.itemType == Items.ItemType.weapon)
            {
                pModel.unequipWeapon();
            } else
            {
                return;
            }
        }
        equipSpace--;
        pModel.CalculateStats();
        item.isEquipped = false;
    }

    //Function that calls other functions for listitems()
    private void displayThings()
    {
        displayStats();
        displayStatsText();
        setInvItems();
    }

    //Displays the items in the inventory when inventory is opened
    public void ListItems()
    {
        cleanInventory();

        //Goes through each object in the inventory
        foreach (var item in inventory) 
        {
            //Creates a game object to instantiate an inventoryItem in the inventory itemContent
                GameObject obj = Instantiate(inventoryItem, itemContent);

            //Finds the Text and Image Components
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();

            //Assigns their values
                itemName.text = item.itemName;
                itemIcon.sprite = item.itemIcon;
            
        }
        displayThings();    //Calls the function from earlier
    }

    //Displays the currently equipped items
    public void displayEquippedItems()
    {
        foreach (var item in equipped)
        {
            GameObject obj = Instantiate(inventoryItem, equipItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
        setEquipItems();
    }

    //Boolean that sets whether or not isActive is true or false
    public void SetActive(bool boo)
    {
        isActive = boo;
    }

    //Same as setEquipItems, but does it for the inventory List items
    private void setInvItems()
    {
        invItems = itemContent.GetComponentsInChildren<ItemInventoryController>();
        for (int i = 0; i < inventory.Count; i++)
        {
            invItems[i].AddItem(inventory[i]);
        }
    }

    //Sets the currently equipped item's data according to what's in the inventory List
    private void setEquipItems()
    {
        //The array gets all the ItemInventoryControllers from the equipItemContent's children
        equipItems = equipItemContent.GetComponentsInChildren<ItemInventoryController>();

        //Iterates through the entire List
        for (int i = 0; i < equipped.Count; i++)
        {
            //Stores the data according to the positions of the items in the equipped list
            equipItems[i].AddItem(equipped[i]);
            
        }
    }

    //Cleans the arrays upon closing the inventory canvas
    //Done so that data about what object is there or not can be easily updated
    public void cleanInventory()
    {
        //Goes through the entire itemContent
        foreach (Transform item in itemContent)
        {
            //Destroys every gameObejct
            Destroy(item.gameObject);
        }
    }

    //Same function as above but from the equipped List
    public void cleanEquip()
    {
        foreach (Transform item in equipItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    //Displays the player's sprite on the stat screen
    private void displayStats()
    {
        var playerSprite = GameObject.Find("PlayerSprite/sprite").GetComponent<Image>();
        playerSprite.sprite = this.GetComponent<SpriteRenderer>().sprite;

    }

    //Displays the player's stats in the text section
    private void displayStatsText()
    {
        //Everything here is the same for each variable
        //Finds the GameObject under a specific child and grabs the required component
            var playerHP = GameObject.Find("PlayerStats/HP").GetComponent<TMP_Text>();
            var playerDmg = GameObject.Find("PlayerStats/Damage").GetComponent<TMP_Text>();
            var playerSpeed = GameObject.Find("PlayerStats/Speed").GetComponent<TMP_Text>();
            var playerArmour = GameObject.Find("PlayerStats/Armour").GetComponent<TMP_Text>();

        //Gets the current player's stats from the PlayerModel
            float hp = pModel.getPlayerHealth();
            float dmg = pModel.getPlayerDmg();
            float speed = pModel.getPlayerSpeed();
            float armour = pModel.getPlayerArmour();

        //Assigns the text accordingly
            playerHP.text = "HP: " + hp.ToString();
            playerDmg.text = "Damage: " + dmg.ToString();
            playerSpeed.text = "Speed: " + speed.ToString();
            playerArmour.text = "Armour: " + armour.ToString();
    }

}
