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

        [Header("Armour Boost")]
        public float armourBoost;

        [Header("Discription")]
        public string discription;

        public GameObject modelPrefab;
    }
}