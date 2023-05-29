using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public DoD.ArmorData[] armour;
    public DoD.WeaponData[] weapon;
    public DoD.ArmourPotionData[] aPotion;
    public DoD.DamagePotionData[] dPotion;
    public DoD.SpeedPotionData[] sPotion;
    public DoD.HealPotionData[] hPotion;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsSO;
    public Button[] purchaseButton;

    // Start is called before the first frame update
    void Start()
    {
        // Activate shop panels based on the total number of items
        for (int i = 0; i < (armour.Length + weapon.Length + aPotion.Length + sPotion.Length + dPotion.Length + hPotion.Length); i++)
        {
            shopPanelsSO[i].SetActive(true);
        }

        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckPurchaseable()
{
    for (int i = 0; i < shopPanels.Length; i++)
    {
        bool isPurchaseable = false;

        // Check if the item type corresponds to the current button
        if (i < armour.Length)
        {
            isPurchaseable = coins >= armour[i].baseCost;
        }
        else if (i < armour.Length + weapon.Length)
        {
            isPurchaseable = coins >= weapon[i - armour.Length].baseCost;
        }
        else if (i < armour.Length + weapon.Length + aPotion.Length)
        {
            isPurchaseable = coins >= aPotion[i - armour.Length - weapon.Length].baseCost;
        }
        else if (i < armour.Length + weapon.Length + aPotion.Length + dPotion.Length)
        {
            isPurchaseable = coins >= dPotion[i - armour.Length - weapon.Length - aPotion.Length].baseCost;
        }
        else if (i < armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length)
        {
            isPurchaseable = coins >= sPotion[i - armour.Length - weapon.Length - aPotion.Length - dPotion.Length].baseCost;
        }
        else if (i < armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length + hPotion.Length)
        {
            isPurchaseable = coins >= hPotion[i - armour.Length - weapon.Length - aPotion.Length - dPotion.Length - sPotion.Length].baseCost;
        }

        purchaseButton[i].interactable = isPurchaseable;
    }
}


    public bool IsItemPurchasable(int index)
    {
        // Check if the item at the given index can be purchased based on available coins
        if (index < armour.Length && coins >= armour[index].baseCost)
        {
            return true;
        }
        else if (index < weapon.Length && coins >= weapon[index].baseCost)
        {
            return true;
        }
        else if (index < aPotion.Length && coins >= aPotion[index].baseCost)
        {
            return true;
        }
        else if (index < dPotion.Length && coins >= dPotion[index].baseCost)
        {
            return true;
        }
        else if (index < sPotion.Length && coins >= sPotion[index].baseCost)
        {
            return true;
        }
        else if (index < hPotion.Length && coins >= hPotion[index].baseCost)
        {
            return true;
        }

        return false;
    }

    public void PurchaseItem(int buttonNo)
    {
        DoD.ArmorData armorData = null;
        DoD.WeaponData weaponData = null;
        DoD.ArmourPotionData aPotionData = null;
        DoD.DamagePotionData dPotionData = null;
        DoD.SpeedPotionData sPotionData = null;
        DoD.HealPotionData hPotionData = null;

        // Check if buttonNo corresponds to an armor item
        if (buttonNo < armour.Length)
        {
            armorData = armour[buttonNo];
        }
        // Check if buttonNo corresponds to a weapon item
        else if (buttonNo < armour.Length + weapon.Length)
        {
            weaponData = weapon[buttonNo - armour.Length];
        }
        // Check if buttonNo corresponds to an armor potion item
        else if (buttonNo < armour.Length + weapon.Length + aPotion.Length)
        {
            aPotionData = aPotion[buttonNo - armour.Length - weapon.Length];
        }
        // Check if buttonNo corresponds to a damage potion item
        else if (buttonNo < armour.Length + weapon.Length + aPotion.Length + dPotion.Length)
        {
            dPotionData = dPotion[buttonNo - armour.Length - weapon.Length - aPotion.Length];
        }
        // Check if buttonNo corresponds to a speed potion item
        else if (buttonNo < armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length)
        {
            sPotionData = sPotion[buttonNo - armour.Length - weapon.Length - aPotion.Length - dPotion.Length];
        }
        // Check if buttonNo corresponds to a heal potion item
        else if (buttonNo < armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length + hPotion.Length)
        {
            hPotionData = hPotion[buttonNo - armour.Length - weapon.Length - aPotion.Length - dPotion.Length - sPotion.Length];
        }

        // Check if the item data is not null and if the player has enough coins
        if (armorData != null && coins >= armorData.baseCost)
        {
            coins -= armorData.baseCost;
        }
        else if (weaponData != null && coins >= weaponData.baseCost)
        {
            coins -= weaponData.baseCost;
        }
        else if (aPotionData != null && coins >= aPotionData.baseCost)
        {
            coins -= aPotionData.baseCost;
        }
        else if (dPotionData != null && coins >= dPotionData.baseCost)
        {
            coins -= dPotionData.baseCost;
        }
        else if (sPotionData != null && coins >= sPotionData.baseCost)
        {
            coins -= sPotionData.baseCost;
        }
        else if (hPotionData != null && coins >= hPotionData.baseCost)
        {
            coins -= hPotionData.baseCost;
        }

        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        // Load item details into the shop panels
        LoadArmourPanels();
        LoadWeaponPanels();
        LoadAPotionPanels();
        LoadDPotionPanels();
        LoadSPotionPanels();
        LoadHPotionPanels();
    }

    private void LoadArmourPanels()
    {
        for (int i = 0; i < armour.Length; i++)
        {
            shopPanels[i].itemName.text = armour[i].itemName;
            shopPanels[i].description.text = armour[i].description;
            shopPanels[i].itemCost.text = "Coins: " + armour[i].baseCost.ToString();
            shopPanels[i].SetItemIcon(armour[i].itemIcon);
        }
    }

    private void LoadWeaponPanels()
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            shopPanels[i + armour.Length].itemName.text = weapon[i].itemName;
            shopPanels[i + armour.Length].description.text = weapon[i].description;
            shopPanels[i + armour.Length].itemCost.text = "Coins: " + weapon[i].baseCost.ToString();
            shopPanels[i + armour.Length].SetItemIcon(weapon[i].itemIcon);
        }
    }

    private void LoadAPotionPanels()
    {
        for (int i = 0; i < aPotion.Length; i++)
        {
            shopPanels[i + armour.Length + weapon.Length].itemName.text = aPotion[i].itemName;
            shopPanels[i + armour.Length + weapon.Length].description.text = aPotion[i].description;
            shopPanels[i + armour.Length + weapon.Length].itemCost.text = "Coins: " + aPotion[i].baseCost.ToString();
            shopPanels[i + armour.Length + weapon.Length].SetItemIcon(aPotion[i].itemIcon);
        }
    }

    private void LoadDPotionPanels()
    {
        for (int i = 0; i < dPotion.Length; i++)
        {
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length].itemName.text = dPotion[i].itemName;
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length].description.text = dPotion[i].description;
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length].itemCost.text = "Coins: " + dPotion[i].baseCost.ToString();
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length].SetItemIcon(dPotion[i].itemIcon);
        }
    }

    private void LoadSPotionPanels()
    {
        for (int i = 0; i < sPotion.Length; i++)
        {
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length].itemName.text = sPotion[i].itemName;
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length].description.text = sPotion[i].description;
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length].itemCost.text = "Coins: " + sPotion[i].baseCost.ToString();
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length].SetItemIcon(sPotion[i].itemIcon);
        }
    }

    private void LoadHPotionPanels()
    {
        for (int i = 0; i < hPotion.Length; i++)
        {
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length].itemName.text = hPotion[i].itemName;
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length].description.text = hPotion[i].description;
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length].itemCost.text = "Coins: " + hPotion[i].baseCost.ToString();
            shopPanels[i + armour.Length + weapon.Length + aPotion.Length + dPotion.Length + sPotion.Length].SetItemIcon(hPotion[i].itemIcon);
        }
    }
}
