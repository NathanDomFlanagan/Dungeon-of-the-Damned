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


        //all variables initialised so to not cause problems
        //additive
        [Header("Attack")]
        public int damage = 0;

        //multiplicative
        //it times by the value set by the class
        [Header("Attack Rate")]
        public int attackRate = 0;

        //sets true or false
        [Header("True Damage")]
        public bool trueDamage = false;

        [Header("Discription")]
        public string discription;

        public GameObject modelPrefab;
    }
}