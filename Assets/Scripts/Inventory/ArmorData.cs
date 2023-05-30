using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Armor", menuName = "Armor/Armor")]
    public class ArmorData : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;

        //additive
        [Header("Defense")]
        public float defense = 0;

        //additive
        [Header("Health")]
        public float health = 0;

        //multiplicative
        //it times by the value set by the class
        [Header("Movement Speed")]
        public float movespeed = 0;

        //multiplicative
        //it times by the value set by the class
        [Header("Jump Height")]
        public float jumpforce = 0;

        //additive
        [Header("Jump Modifier")]
        public int jumpmod = 0;

        [Header("Description")]
        public string description;
    }