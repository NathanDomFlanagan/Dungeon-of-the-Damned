using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Armour Potion", menuName = "Potion/Armour Potion")]
    public class ArmourPotionData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;
        public int baseCost;

        [Header("Armour Boost")]
        public float armourBoost;

        [Header("Description")]
        public string description;

        public GameObject modelPrefab;
    }
}