using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "Item", menuName = "Item/Create New Item")]
    public class PotionData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;
        public int itemId;

        [Header("Item Value")]
        public int itemValue;

        [Header("Discription")]
        public string description;

        //public GameObject modelPrefab;
    }