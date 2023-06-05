using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;
    
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        //Sets string to current coin count
        if (coinText != null)
        {
            coinText.text = PlayerPrefs.GetInt("coins").ToString();
        }
    }
    public void AddCoins(int x)
    {
        //Adds coins to coin count
        PlayerPrefs.SetInt("coins", GetCoins()+x);
        //Updates text to display new coin count
        if (coinText != null)
        {
            coinText.text = PlayerPrefs.GetInt("coins").ToString();
        }
    }

    public int GetCoins()
    {
        return PlayerPrefs.GetInt("coins");
    }

    public void RemoveCoins(int amount)
    {
        int currentCoins = GetCoins();
        currentCoins -= amount;
        PlayerPrefs.SetInt("coins", currentCoins);
        if (coinText != null)
        {
            coinText.text = PlayerPrefs.GetInt("coins").ToString();
        }
    }
    public void SetCoins(int amount)
    {
        PlayerPrefs.SetInt("coins", amount);
        if (coinText != null)
        {
            coinText.text = PlayerPrefs.GetInt("coins").ToString();
        }
    }
}