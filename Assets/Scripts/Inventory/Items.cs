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

    public bool isArmor = false;
    public bool isWeapon = false;
    public bool isPotion = false;
    public bool isEquipped = false;

    [Header("ONLY CHANGE IF ITEM IS ARMOR")]
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

    [Header("ONLY CHANGE IF ITEM IS WEAPON")]

    [Header("Damage")]
    public int damage = 0;

    [Header("Attack Rate")]
    public int attackRate = 0;

    [Header("True Damage")]
    public bool trueDamage = false;

    //Handles the Attack damage, or amount healed (potions)
    [Header("Item Value Modifier")]
        public int itemValue;

        [Header("Description")]
        public string description;

        public ItemType itemType;

        //Defining the item type
        public enum ItemType
        {
        Armour,
        Heal,
        Speed,
        Damage,
        armourEquip,
        weapon
        }
    }