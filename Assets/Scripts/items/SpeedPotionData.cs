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

        [Header("Speed Boost")]
        public float speedBoost;

        [Header("Discription")]
        public string discription;

        public GameObject modelPrefab;
    }
}