using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectManager : MonoBehaviour
{
    public CharacterSpriteDatabase characterDB;

    public int option = 0;
    // Start is called before the first frame update
    void Awake()
    {
        updateCharacter(option);
    }

    public void nextClass()
    {
        option++;

        if(option >= characterDB.characterIndex)
        {
            option = 0;
        }
        updateCharacter(option);
    }

    public void prevClass()
    {
        option--;

        if (option <= 0)
        {
            option = characterDB.characterIndex  -1;
        }
        updateCharacter(option);
    }

    private void updateCharacter(int option)
    {
        CharacterSelect character = characterDB.getCharacter(option);
        PlayerPrefs.SetString("className",character.className);
        Debug.Log(PlayerPrefs.GetString("className"));
    }
}
