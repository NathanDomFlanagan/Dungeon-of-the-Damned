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
        /*Damageable test = new Damageable();
        float testHealth = test.Health;
        float testVal = 90;

        bool result = (testHealth == testVal);
        Assert.IsFalse(result);

        test.Hit(50, true, new Vector2(0, 0));*/

        CharacterSelectManager test = new CharacterSelectManager();
        int testOption = test.option;
        int testVal = 2;

        bool result = (testOption == testVal);
        Assert.IsFalse(result);

        Object db = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Tests/CharacterSpriteDatabse.asset", typeof(CharacterSpriteDatabase));
        test.characterDB = (CharacterSpriteDatabase)db;
        CharacterSelect character;

        test.nextClass();
        testVal = 1;

        result = (testOption == testVal);
        Assert.IsTrue(result);



    }
}
