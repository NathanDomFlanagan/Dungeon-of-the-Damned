using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpgradeGearTest
{
    // A Test behaves as an ordinary method
    [SetUp]
    public void getGearItem()
    {
        //Object weapon = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Inventory/Weapons/axe_1_[32x32].asset", typeof(Items));
        //Object armour = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Inventory/Weapons/axe_1_[32x32].asset", typeof(Items));
    }
    [Test]
    public void UpgradeWeaponTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    public void UpgradeArmourTestSimplePasses() { 
        
    }

}
