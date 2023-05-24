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
        PlayerPrefs.SetString("cointext","Coins: " + PlayerPrefs.GetInt("coins").ToString());
        //coinText.text = PlayerPrefs.GetString("cointext");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = PlayerPrefs.GetString("cointext");
    }
    public void AddCoins(int x)
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+x);
        PlayerPrefs.SetString("cointext","Coins: " + PlayerPrefs.GetInt("coins").ToString());
        UnityEngine.Debug.Log(PlayerPrefs.GetString("cointext"));
        coinText.text = PlayerPrefs.GetString("cointext");
    }
}
