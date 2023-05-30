using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemInventoryController : MonoBehaviour
{
    public Items item;
    public PlayerModel pModel;

    void Awake()
    {
        pModel = GameObject.FindWithTag("Player").GetComponent<PlayerModel>();
    }

    //This is done to prevent error where it doesnt detect the item (essentially making a duplicate of the player's inventory so that it knows what item type it is)
    public void AddItem(Items newItem)
    {
        item = newItem;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        if (item.itemType == Items.ItemType.armourEquip && InventoryManager.Instance.equip1 == false)
        {
            InventoryManager.Instance.displayEquip(item);
        }
        Destroy(gameObject);
    }

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
            case Items.ItemType.armourEquip:
                pModel.AddItem(item);
                break;
        }
        RemoveItem();
    }
}
