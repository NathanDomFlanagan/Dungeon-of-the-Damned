using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PrefabDatabase : ScriptableObject
{
    public GameObject[] characterPrefab;
    public int prefabIndex
    {
        get { return characterPrefab.Length; }
    }

    public GameObject getPrefab(int index)
    {
        if(index > characterPrefab.Length)
        {
            return 0;
        } else
        {
            return characterPrefab[index]; 
        }
    }
}
