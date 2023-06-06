using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void InventoryTestSimplePasses()
    {
        //Initializing code

        InventoryManager Inventory = new InventoryManager();
        Items epicitem = (Items)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Weapons/sword1.asset",typeof(Items));

        Inventory.Add(epicitem);

        Items addedItem = Inventory.getItem(0);
        bool result = (epicitem==addedItem);
        Assert.IsTrue(result);

        // Use the Assert class to test conditions
        Inventory.Remove(epicitem);
        int invSize = Inventory.getInventory().Count;
        result = (invSize > Inventory.getInventory().Count);
        Assert.IsFalse(result);
    }

}
