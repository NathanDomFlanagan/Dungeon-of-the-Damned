using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoD
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Weapon")]
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