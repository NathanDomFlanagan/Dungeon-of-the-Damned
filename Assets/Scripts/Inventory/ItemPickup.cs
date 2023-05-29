using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items Item;

    public void Pickup()
    {
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InventoryManager temp = collision.GetComponent<InventoryManager>();
        if (temp.inventorySpace == InventoryManager.MAXINVENTORY)
        {
            return;
        } else
        {
            Pickup();
        }
    }
}
