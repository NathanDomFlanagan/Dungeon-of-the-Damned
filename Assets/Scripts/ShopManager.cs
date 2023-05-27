using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;    
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsSO;
    public Button[] purchaseButton;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsSO[i].SetActive(true);
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
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            if(coins >= shopItemsSO.baseCost)
                purchaseButton[i].interactable = true;
            else
                purchaseButton[i].interactable = false;
        }
    }

    public void PurchaseItem(int buttonNo)
    {
        if(coins >= shopItemsSO[buttonNo].baseCost)
        {
            coins = coins - shopItemsSO[buttonNo].baseCost;
            coinUI.text = "Coins: " = coins.ToString();
            CheckPurchaseable();
        }
    }
    public void LoadPanels()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }
}
