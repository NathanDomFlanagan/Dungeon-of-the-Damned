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

        [Header("Damage Boost")]
        public float damageBoost;

        [Header("Discription")]
        public string discription;

        public GameObject modelPrefab;
    }
}