using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemInventoryController : MonoBehaviour
{
    //Variables
    public Items item;
    public PlayerModel pModel;
    public bool equipped = false;

    //Finds the game object with tag "Player" and grabs their PlayerModel component
    void Awake()
    {
        pModel = GameObject.FindWithTag("Player").GetComponent<PlayerModel>();
    }

    //AddsItem is a function that is used to add the data of the items in the List and stores them in an array
    //Mostly seen in InventoryManager SetInventory and SetEquip functions
    public void AddItem(Items newItem)
    {
        item = newItem;
        item.isEquipped = false;
    }

    //Removes Item from the inventory
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    //Unequips the item in the equip slots
    private void UnequipItem()
    {
        InventoryManager.Instance.Unequip(item);
        Destroy(gameObject);
    }   

    //Switch-case statement for when items are clicked
    public void UseItem()
    {
        switch (item.itemType)
        {
            case Items.ItemType.Armour:
                pModel.AddItem(item);
                Debug.Log("Increased Armour by 50");
                break;
            case Items.ItemType.Heal:
                pModel.AddItem(item);
                Debug.Log("Healed for 50");
                break;
            case Items.ItemType.Damage:
                pModel.AddItem(item);
                break;
            case Items.ItemType.Speed:
                pModel.AddItem(item);
                break;

            //Special type of case for the equipabble items
            case Items.ItemType.armourEquip:
                if (item.isEquipped == false)   //Checks if the item is equipped or not
                {
                    //Equips the item in the equip item List
                    InventoryManager.Instance.equipItem(item);
                    pModel.AddItem(item);       //Adds the item stats in the PlayerModel
                    item.isEquipped = true;     //Sets isEquipped to true
                }
                break;
        }
        RemoveItem();
    }
}
