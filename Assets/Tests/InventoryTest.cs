using System.Collections;
using System.Collections.Generic;
using DoD;
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

        PlayerInventory Inventory = new PlayerInventory();
        Object epicitem = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Weapons/Axe 1.asset", typeof(WeaponData));

        Inventory.AddInventory(epicitem);

        Object addedItem = Inventory.Inventory[0];
        bool result = (epicitem==addedItem);
        Assert.IsTrue(result);

        // Use the Assert class to test conditions
        Inventory.RemoveInventory(1);
        Object foundValue = Inventory.Inventory[0];
        result = (epicitem == foundValue);
        Assert.IsFalse(result);

    }

}
