using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Sword", menuName = "Weapon/Sword")]
    public class WeaponData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;

        [Header("Attack")]
        public float damage;

        [Header("Discription")]
        public string discription;

        public GameObject modelPrefab;
    }
}