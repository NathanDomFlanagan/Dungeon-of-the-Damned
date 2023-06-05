using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShopTestScript
{    
    [Test]
    public void TestAddCoins()
    {
        // Arrange
        CoinCounter coinCounter = new GameObject().AddComponent<CoinCounter>(); // Create an instance of CoinCounter
        coinCounter.SetCoins(100); // Set the initial coins to 100

        int coinsToAdd = 50; // Number of coins to add

        // Act
        coinCounter.AddCoins(coinsToAdd); // Add coins

        // Assert
        int expectedCoins = 100 + coinsToAdd; // Calculate the expected number of coins
        int actualCoins = coinCounter.GetCoins(); // Get the actual number of coins

        Assert.AreEqual(expectedCoins, actualCoins); // Check if the expected and actual coins match
    }
}   
