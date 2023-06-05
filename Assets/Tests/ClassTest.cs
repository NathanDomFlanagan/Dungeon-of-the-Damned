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
        CharacterSelectManager obj = new CharacterSelectManager();
        CharacterSpriteDatabase temp = (CharacterSpriteDatabase)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Tests/CharacterSpriteDatabse.asset", typeof(CharacterSpriteDatabase));
        obj.setCharacterDB(temp);

        int val = obj.getOption();
        int testVal = 2;
        
        bool result = (val == testVal);
        Assert.IsFalse(result);

        obj.nextClass();
        result = (val != testVal);
        Assert.IsTrue(result);
    }   
}
