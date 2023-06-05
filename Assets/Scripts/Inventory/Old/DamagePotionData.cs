using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Damage Potion", menuName = "Potion/Damage Potion")]
    public class DamagePotionData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;
        public int baseCost;

        [Header("Damage Boost")]
        public float damageBoost;

        [Header("Description")]
        public string description;

        public GameObject modelPrefab;
    }
}