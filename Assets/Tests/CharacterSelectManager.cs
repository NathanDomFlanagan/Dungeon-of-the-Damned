using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectManager : MonoBehaviour
{
    public CharacterSpriteDatabase characterDB;
    public int option;
    // Start is called before the first frame update
    void Awake()
    {
        option = 0;
    }

    public void nextClass()
    {
        option++;

        if(option >= 3)
        {
            option = 0;
        }
    }

    public void prevClass()
    {
        option--;

        if (option < 0)
        {
            option = 3;
        }
    }
}
