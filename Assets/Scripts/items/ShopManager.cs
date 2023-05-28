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
        for(int i = 0; i < (armour.Length + weapon.Length + aPotion.Length + sPotion.Length + dPotion.Length + hPotion.Length); i++)
            shopPanelsSO[i].SetActive(true);
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        //CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void CheckPurchaseable()
    {
        for(int i = 0; i < armour.Length || i < weapon.Length || i < aPotion.Length || i < sPotion.Length || i < dPotion.Length || i < hPotion.Length; i++)
        {
            if(coins >= armour[i].baseCost || coins >= weapon[i].baseCost || coins >= aPotion[i].baseCost || coins >= sPotion[i].baseCost || coins >= dPotion[i].baseCost || coins >= hPotion[i].baseCost)
                purchaseButton[i].interactable = true;
            else
                purchaseButton[i].interactable = false;
        }
    }*/

    /*public void PurchaseItem(int buttonNo)
    {
        if(coins >= armour[buttonNo].baseCost)
        {
            coins = coins - armour[buttonNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
        if(coins >= weapon[buttonNo].baseCost)
        {
            coins = coins - weapon[buttonNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
        if(coins >= aPotion[buttonNo].baseCost)
        {
            coins = coins - aPotion[buttonNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
        if(coins >= sPotion[buttonNo].baseCost)
        {
            coins = coins - sPotion[buttonNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
        if(coins >= dPotion[buttonNo].baseCost)
        {
            coins = coins - dPotion[buttonNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
        if(coins >= hPotion[buttonNo].baseCost)
        {
            coins = coins - hPotion[buttonNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
    }*/

    public void LoadPanels()
    {
        for(int i = 0; i < armour.Length; i++)
        {
            shopPanels[i].itemName.text = armour[i].itemName;
            shopPanels[i].description.text = armour[i].description;
            //shopPanels[i].itemIcon.Sprite = armour[i].itemIcon;
            shopPanels[i].itemCost.text = "Coins: " + armour[i].baseCost.ToString();
        }
        for(int i = 0; i < weapon.Length; i++)
        {
            shopPanels[i].itemName.text = weapon[i].itemName;
            shopPanels[i].description.text = weapon[i].description;
            shopPanels[i].itemCost.text = "Coins: " + weapon[i].baseCost.ToString();
        }
        for(int i = 0; i < aPotion.Length; i++)
        {
            shopPanels[i].itemName.text = aPotion[i].itemName;
            shopPanels[i].description.text = aPotion[i].description;
            shopPanels[i].itemCost.text = "Coins: " + aPotion[i].baseCost.ToString();
        }
        for(int i = 0; i < sPotion.Length; i++)
        {
            shopPanels[i].itemName.text = sPotion[i].itemName;
            shopPanels[i].description.text = sPotion[i].description;
            shopPanels[i].itemCost.text = "Coins: " + sPotion[i].baseCost.ToString();
        }
        for(int i = 0; i < dPotion.Length; i++)
        {
            shopPanels[i].itemName.text = dPotion[i].itemName;
            shopPanels[i].description.text = dPotion[i].description;
            shopPanels[i].itemCost.text = "Coins: " + dPotion[i].baseCost.ToString();
        }
        for(int i = 0; i < hPotion.Length; i++)
        {
            shopPanels[i].itemName.text = hPotion[i].itemName;
            shopPanels[i].description.text = hPotion[i].description;
            shopPanels[i].itemCost.text = "Coins: " + hPotion[i].baseCost.ToString();
        }
    }
}
