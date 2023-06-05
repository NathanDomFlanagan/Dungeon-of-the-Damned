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
    }

    [Test]
    public void OtherClassTest()
    {
        CharacterSelectManager obj = new CharacterSelectManager();
        int optionVal = obj.getOption();
        int origValue = 0;

        bool result = (optionVal == origValue);
        Assert.IsTrue(result);

        obj.nextClass();
        result = (optionVal == origValue);
        Assert.IsFalse(result);

        obj.nextClass();
        result = (optionVal == origValue);
        Assert.IsTrue(result);
    }
}
