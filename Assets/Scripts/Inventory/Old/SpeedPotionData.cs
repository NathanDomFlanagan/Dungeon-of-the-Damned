using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Speed Potion", menuName = "Potion/Speed Potion")]
    public class SpeedPotionData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;
        public int baseCost;

        [Header("Speed Boost")]
        public float speedBoost;

        [Header("Description")]
        public string description;

        public GameObject modelPrefab;
    }
}