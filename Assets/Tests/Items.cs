using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Item/Create New Item")]
public class Items : ScriptableObject
{
        [Header("Item Information")]
        public Sprite itemIcon;

        public string itemName;
        public int itemId;
        public int baseCost;
        public int upgradeCost = 50;
        public int itemLvl = 1;

        public bool isArmor = false;
        public bool isWeapon = false;
        public bool isPotion = false;
        public bool isEquipped = false;

        [Header("Potion Effect Timer")]
        public float origTime;
        public float timer = 0;
        public bool timerActive = false;

        [Header("ONLY CHANGE IF ITEM IS ARMOR")]
        //additive
        [Header("Defense")]
        public int defense = 0;

        //additive
        [Header("Health")]
        public int health = 0;

        //multiplicative
        //it times by the value set by the class
        [Header("Movement Speed")]
        public int movespeed = 0;

        //multiplicative
        //it times by the value set by the class
        [Header("Jump Height")]
        public int jumpforce = 0;

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
    public void Init()
    {
        itemLvl = 1;
        upgradeCost = 50;
        defense = 0;
        health = 0;
        damage = 0;
    }    

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

    public Items itemData;      //testing if it references
    public void Copy(Items item)
    {
        this.itemIcon = item.itemIcon;
        this.itemName = item.itemName;
        this.itemType = item.itemType;
        this.itemData = item.itemData;
        this.itemId = item.itemId;
        this.damage = item.damage;
        this.attackRate = item.attackRate;
        this.trueDamage = item.trueDamage;
        this.itemValue = item.itemValue;
        this.description = item.description;
        this.baseCost = item.baseCost;
        this.upgradeCost = item.upgradeCost;
        this.itemLvl = item.itemLvl;
        this.isArmor = item.isArmor;
        this.isWeapon = item.isWeapon;
        this.isEquipped = item.isEquipped;
        this.isPotion = item.isPotion;
        this.movespeed = item.movespeed;
        this.jumpmod = item.jumpmod;
        this.jumpforce = item.jumpforce;
    }
    public Items Upgrade(Items item)
    {
        Items upgrade = CreateInstance<Items>();
        upgrade.Copy(item);
        upgrade.upgradeCost = item.upgradeCost + 50;
        upgrade.itemLvl = item.itemLvl + 1;
        upgrade.defense = item.defense + 5;
        upgrade.health = item.health + 5;
        upgrade.damage = item.damage + 10;
        return upgrade;
    }
}

