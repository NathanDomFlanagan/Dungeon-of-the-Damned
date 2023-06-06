using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpgradeMenuTest
{
    
    // A Test behaves as an ordinary method
    [Test]
    public void GetUpgradableItemsTestSimplePasses()
    {


        UpgradeMenu upgrademenu = new UpgradeMenu();
        upgrademenu.playerInventory = new InventoryManager();
        upgrademenu.inventory = new List<Items>();
        Items epicitem = (Items)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Weapons/sword1.asset", typeof(Items));


        upgrademenu.playerInventory.Add(epicitem);
        upgrademenu.playerInventory.Add(epicitem);
        upgrademenu.GetUpgradableItems();

       
        bool result = upgrademenu.inventory.Count == 2;
        Assert.IsTrue(result, upgrademenu.inventory.Count.ToString());

    }
    [Test]
    public void UpgradeItemTestSimplePasses()
    {

        UpgradeMenu upgrademenu = new UpgradeMenu();
        upgrademenu.inventory = new List<Items>();
        upgrademenu.playerInventory = new InventoryManager();
        upgrademenu.cc = new CoinCounter();
        PlayerPrefs.SetInt("coins", 100);

        Items epicitem = (Items)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Weapons/sword1.asset", typeof(Items));
        upgrademenu.inventory.Add(epicitem);
        upgrademenu.UpgradeItem(0);


        bool result = upgrademenu.inventory[0].damage == epicitem.damage+5;
        Assert.IsTrue(result, upgrademenu.inventory[0].damage.ToString());

    } }
