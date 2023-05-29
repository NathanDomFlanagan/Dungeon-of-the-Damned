using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "Item", menuName = "Item/Create New Item")]
    public class Items : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;
        public int itemId;

        [Header("Item Value")]
        public int itemValue;

        [Header("Description")]
        public string description;

        public ItemType itemType;

        //Defining the item type
        public enum ItemType
        {
        smallArmour,
        bigArmour,
        smallHeal,
        bigHeal,
        smallDmg,
        bigDmg,
        smallSpeed,
        bigSpeed
        }
    }