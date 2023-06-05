using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectManager : MonoBehaviour
{
    public CharacterSpriteDatabase characterDB;
    public static CharacterSelectManager Instance;

    public int option;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        updateCharacter(option);
        option = 0;
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
            option = characterDB.characterIndex -1;
        }
        updateCharacter(option);
    }

    private void updateCharacter(int option)
    {
        CharacterSelect character = characterDB.getCharacter(option);
        PlayerPrefs.SetString("className",character.className);
        Debug.Log(PlayerPrefs.GetString("className"));
    }

    public int getOption()
    {
        return option;
    }

    public void setCharacterDB(CharacterSpriteDatabase db)
    {
        characterDB = db;
    }
}
