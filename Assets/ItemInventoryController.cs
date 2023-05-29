using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryController : MonoBehaviour
{
    private Items item;
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
        Destroy(gameObject);
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Items.ItemType.smallArmour:
                pModel.incArmour(10);
                Debug.Log("Increased Armour by 10");
                break;
            case Items.ItemType.bigArmour:
                pModel.incArmour(50);
                Debug.Log("Increased Armour by 50");
                break;
            case Items.ItemType.smallHeal:
                pModel.Heal(10);
                Debug.Log("Healed for 10");
                break;
            case Items.ItemType.bigHeal:
                pModel.Heal(50);
                Debug.Log("Healed for 50");
                break;
        }
        RemoveItem();
    }
}
