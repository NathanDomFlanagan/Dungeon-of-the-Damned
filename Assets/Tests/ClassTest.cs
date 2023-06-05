using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class ClassTest
{
    [Test]
    public void SimpleClassTest()
    {
        //Initializing variables
        GameObject obj = new GameObject();
        obj.AddComponent<CharacterSelectManager>();
        Assert.IsNotNull(obj);

        CharacterSelectManager test = obj.GetComponent < CharacterSelectManager>();

        int optionVal = test.getOption();
        int origValue = 0;

        bool result = (optionVal == origValue);
        Assert.IsTrue(result);

        test.nextClass();
        result = (optionVal == origValue);
        Assert.IsFalse(result);

        test.prevClass();
        result = (optionVal == origValue);
        Assert.IsTrue(result);
    }
}
