using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class ClassSelectTest
{
    [Test]
    public void SimpleClassSelectTest()
    {
        CharacterSelectManager test = new CharacterSelectManager();
        int testOption = test.option;
        int testVal = 2;
        bool result = (testOption == testVal);
        Assert.IsFalse(result);

        test.nextClass();
        testOption = test.option;
        testVal = 1;
        result = (testOption == testVal);
        Assert.IsTrue(result);

        test.prevClass();
        testOption = test.option;
        testVal = 0;
        result = (testOption == testVal);
        Assert.IsTrue(result);

    }
}
