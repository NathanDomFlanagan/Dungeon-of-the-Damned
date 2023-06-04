using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemInventoryController : MonoBehaviour
{
    //Variables
    public static ItemInventoryController Instance;
    public Items item;
    public PlayerModel pModel;
    public bool equipped = false;
    private Items temp = null;
    private bool isUsed = false;

    //Finds the game object with tag "Player" and grabs their PlayerModel component
    void Awake()
    {
        Instance = this;
        pModel = GameObject.FindWithTag("Player").GetComponent<PlayerModel>();
        temp = item;
    }

    void Update()
    {
        if(this.item == null)
        {
            if (temp != null)
            {
                this.item = temp;
            }
        }
        if(isUsed == true)
        {
            RemoveItem();
        }
    }

    //AddsItem is a function that is used to add the data of the items in the List and stores them in an array
    //Mostly seen in InventoryManager SetInventory and SetEquip functions
    //Add is used bool
    public void AddItem(Items newItem)
    {
        item = newItem;
    }

    //Removes Item from the inventory
    public void RemoveItem()
    {
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
    }

    //Unequips the item in the equip slots
    public void UnequipItem()
    {
        if(item.isEquipped == false)
        {
            return;
        } else
        {
            InventoryManager.Instance.Unequip(item);
            Destroy(gameObject);
        }
    }   

    //Switch-case statement for when items are clicked
    public void UseItem()
    {
        switch (item.itemType)
        {
            case Items.ItemType.Armour:
                pModel.AddItem(item);
                Debug.Log("Increased Defense by " + item.defense);
                isUsed= true;
                break;

            case Items.ItemType.Heal:
                pModel.AddItem(item);
                Debug.Log("Healed for " + item.health);
                isUsed = true;
                break;

            case Items.ItemType.Damage:
                pModel.AddItem(item);
                Debug.Log("Increased Damage by " + item.damage);
                isUsed = true;
                break;

            case Items.ItemType.Speed:
                pModel.AddItem(item);
                Debug.Log("Increased Speed by " + item.movespeed);
                isUsed = true;
                break;

            //Special type of case for the equipabble items
            case Items.ItemType.armourEquip:
                if (item.isEquipped == false)
                {
                    if(InventoryManager.Instance.equipSpace == 2)
                    {
                        break;
                    } else 
                    isUsed = true;
                    InventoryManager.Instance.equipItem(item);
                    item.isEquipped = true;
                    pModel.AddItem(item);       //Adds the item stats in the PlayerModel
                }
                break;

            case Items.ItemType.weapon:
                if(item.isEquipped == false)
                {
                    if(InventoryManager.Instance.equipSpace == 2)
                    {
                        break;
                    } else
                    isUsed = true;
                    InventoryManager.Instance.equipItem(item);
                    item.isEquipped = true;
                    pModel.AddItem(item);       //Adds the item stats in the PlayerModel

                }
                break;

            default:
                break;
        }
    }
}
