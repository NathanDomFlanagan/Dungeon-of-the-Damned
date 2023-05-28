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
        coinText.text = PlayerPrefs.GetInt("coins").ToString();
    }
    public void AddCoins(int x)
    {
        
        //Adds coins to coin count
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+x);

        //PlayerPrefs.SetString("cointext",PlayerPrefs.GetInt("coins").ToString());
        //Updates text to display new coin count
        coinText.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
