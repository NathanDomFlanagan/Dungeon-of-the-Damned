using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PrefabDatabase : ScriptableObject
{
    public PrefabSelect[] characterPrefab;
    public int prefabIndex
    {
        get { return characterPrefab.Length; }
    }

    public PrefabSelect getPrefab(int index)
    {
        if(index > characterPrefab.Length)
        {
            return characterPrefab[0];
        } else
        {
            return characterPrefab[index]; 
        }
    }
}
