using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShopTestScript
{
    [Test]
    public void DeductCoinsOnPurchase()
    {
        // Create a mock shop and player inventory
        ShopManager shopManager = new ShopManager();
        PlayerInventory playerInventory = new PlayerInventory();

        // Set up test data
        int initialCoins = 100;
        int itemCost = 50;
        shopManager.coinCounter.SetCoins(initialCoins);

        // Purchase an item
        shopManager.PurchaseItem(0); // Assuming item 0 is selected for testing

        // Verify the coins are correctly deducted
        int expectedCoins = initialCoins - itemCost;
        int actualCoins = shopManager.coinCounter.GetCoins();
        Assert.AreEqual(expectedCoins, actualCoins, "Coins were not deducted correctly on purchase.");
    }
}
