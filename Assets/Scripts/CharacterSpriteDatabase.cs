using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterSpriteDatabase : ScriptableObject
{
    public CharacterSelect[] character;
    public int characterIndex
    {
        get { return character.Length; }
    }

    public CharacterSelect getCharacter(int index)
    {
        if(index > character.Length)
        {
            return character[0];
        } else
        {
            return character[index];
        }
    }
}
