using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Heavy Armor", menuName = "Armor/Heavey Armor")]
    public class ArmorData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;

        [Header("Defense")]
        public float defense;

        public GameObject modelPrefab;
    }
}