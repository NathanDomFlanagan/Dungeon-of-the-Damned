using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class Damageabletest
{
    [Test]
    public void SimpleDamageTest()
    {
        Damageable obj = new Damageable();

        float test = obj.maxHealth;
        float testVal = 0;

        bool result = (test == testVal);
        Assert.IsFalse(result);

        obj.SetStats(10, 20);
        test = obj.maxHealth;
        testVal = 10;
        result = (test == testVal);
        Assert.IsTrue(result);

        test = obj.armour;
        testVal = 100;
        result = (test == testVal);
        Assert.IsFalse(result);

    }   


}
