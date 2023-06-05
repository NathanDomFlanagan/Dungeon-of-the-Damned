using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public CoinCounter cc;
    public TMP_Text coinUI;
    public InventoryManager playerInventory;
    public List<Items> inventory;
    public ShopTemplate[] inventoryPanels;
    public GameObject[] inventoryPanelsSO;
    public Button[] upgradeButton;
    public const int MAXLEVEL =5;
    public Items items;

    void Awake()
    {
        refreshUpgrades();
    }

    public void refreshUpgrades()
    {
        UnityEngine.Debug.Log("Upgrades Ready");
        GetUpgradableItems();
        // Activate shop panels based on the total number of items
        for (int i = 0; i < inventoryPanelsSO.Length ; i++)
        {
            if (i<inventory.Count)
            {
                inventoryPanelsSO[i].SetActive(true);
            }
            else
            {
                i = inventoryPanelsSO.Length;
            }
        }
        LoadPanels();
        CheckUpgradeCost();
        coinUI.text = "Coins: " + cc.GetCoins().ToString(); // Update the coinUI text
    }
    public void GetUpgradableItems()
    {
        inventory.Clear();
        foreach (Items item in playerInventory.getInventory())
        {
            UnityEngine.Debug.Log(item.itemName);
            if (item.itemType.ToString() == "armourEquip" || item.itemType.ToString() == "weapon")
            {
                inventory.Add(item);
                UnityEngine.Debug.Log(item.itemName);
            }
        }
    }
    public void CheckUpgradeCost()
    {
        for (int i = 0; i < inventoryPanelsSO.Length; i++)
        {
            if(i < inventory.Count)
            {
                upgradeButton[i].interactable = (cc.GetCoins() >= inventory[i].upgradeCost && inventory[i].itemLvl < MAXLEVEL);
            } else
            {
                i = inventoryPanelsSO.Length;
            }
        }
    }

    public void UpgradeItem(int buttonNo)
    {
        Items item = inventory[buttonNo];
        if (cc.GetCoins() >= item.upgradeCost )
        {
            cc.RemoveCoins(item.upgradeCost);
            playerInventory.Remove(item);
            Items upgradeditem = item.Upgrade(item);
            inventory[buttonNo] = upgradeditem;
            playerInventory.Add(upgradeditem);
            CheckUpgradeCost();
            LoadPanelChange();
            coinUI.text = "Coins: " + cc.GetCoins().ToString(); // Update the coinUI text
        }

    }
    

    public void LoadPanels()
    {
        for (int i = 0; i < (inventory.Count); i++)
        {
            if (i < inventoryPanels.Length)
            {

                inventoryPanels[i].itemName.text = inventory[i].itemName;
                inventoryPanels[i].itemLvl.text = "Lvl: " + inventory[i].itemLvl;
                inventoryPanels[i].description.text = inventory[i].description;
                inventoryPanels[i].itemCost.text = "Coins: " + inventory[i].upgradeCost.ToString();
                inventoryPanels[i].SetItemIcon(inventory[i].itemIcon);
            }
            else
            {
                i = inventoryPanels.Length;
            }
        }
    }
    public void LoadPanelChange()
    {
        for (int i = 0; i < (inventory.Count); i++)
        {
            if (i < inventoryPanels.Length)
            {
                inventoryPanels[i].itemLvl.text = "Lvl: " + inventory[i].itemLvl;
                inventoryPanels[i].itemCost.text = "Coins: " + inventory[i].upgradeCost.ToString();
            }
            else
            {
                i = inventoryPanels.Length;
            }
        }
    }
}
