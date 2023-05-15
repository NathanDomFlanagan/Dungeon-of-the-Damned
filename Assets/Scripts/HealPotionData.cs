using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Heal Potion", menuName = "Potion/Heal Potion")]
    public class HealPotionData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;

        [Header("Heal")]
        public float heal;

        [Header("Discription")]
        public string discription;

        public GameObject modelPrefab;
    }
}