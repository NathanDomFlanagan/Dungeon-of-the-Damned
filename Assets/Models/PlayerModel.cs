using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoD;

public class PlayerModel : MonoBehaviour
{
    public InventoryManager inventoryManager; 
    public PlayerController playerController;
    public PlayerCombat playerCombat;
    public Damageable playerDamage;

    public string className;

    private Items armor = null;
    private Items weapon = null;
    private Items other = null;

    //sets which of the abilities are enabled for the specific player class
    private bool enableWallJump;
    private bool enableDash;
    private bool enableWallSlide;
    
    //boolean for when an item is added into or removed from the player equipslots
    public bool updatedStats;

    //all the variables for the characters data which can be changed by items.
    // or conversely changed depending on the players class
    private int amountOfJumps;
    public float charMoveSpeed;
    public int charAttackDmg;
    public float charHealth;
    public float charArmour;
    private float charAttackRange;
    private float charAttackRate;
    private float charJumpForce;
    private bool charTrueDmg;

    private static PlayerModel Instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        inventoryManager = GetComponent<InventoryManager>();
        classSelect();
        reloadAbility(); // gives the character access to the walljump and dash if 
        reloadStats();

    }

    // Update is called once per frame
    void Update()
    {
        if(updatedStats == true)
        {
            //reloads the character controller and character combat with new stats
            CalculateStats();
            reloadStats();
        }
    }

    public Items AddItem(Items data) // checks whether the data inserted is an allowed type to be entered into each of the equip slots
    {
        if (data!=null && data.isArmor == true)
        {
            updatedStats = true;
            return ArmorAdd(data);
        }
        else if (data != null &&data.isWeapon == true)
        {
            updatedStats = true;
            return WeaponAdd(data);
        }
        else if (data!=null && data.isPotion == true)
        {
            updatedStats = true;
            return StatsAdd(data);
        }
        else
        {   
            return data;
        }
    }

    private Items ArmorAdd(Items armordata)
    {
        Items returndata = armor;
        armor = armordata;
        return returndata;
    }

    private Items WeaponAdd(Items data)
    {
        Items returndata = weapon;
        weapon = data;
        return returndata;
    }

    private Items StatsAdd(Items data)
    {
        Items returndata = other;
        other = data;
        return returndata;
    }

    public void classSelect()
    {
        switch (className)
        {
            case "knight":
                selectKnight();
                break;
            case "lancer":
                selectLancer();
                break;
            case "archer":
                selectArcher();
                break;
        }
    }

    private void selectKnight()
    { // sets the base stats and variables for the knight.
        enableWallJump = false;
        enableDash = true;
        enableWallSlide = false;
        updatedStats = false;
        amountOfJumps = 1;
        charMoveSpeed = 10;
        charAttackDmg = 40;
        charAttackRange = 0.5f;
        charAttackRate = 2;
        charHealth = 100;
        charArmour = 0;
        charJumpForce = 16;
        charTrueDmg = false;
    }
    private void selectLancer()
    { // sets the base stats and variables for the lancer.
        enableWallJump = false;
        enableDash = true;
        enableWallSlide = false;
        updatedStats = false;
        amountOfJumps = 2;
        charMoveSpeed = 12;
        charAttackDmg = 30;
        charAttackRange = 0.5f;
        charAttackRate = 3;
        charHealth = 100;
        charArmour = 0;
        charJumpForce = 18;
        charTrueDmg = false;
    }
    private void selectArcher()
    { // sets the base stats and variables for the knight.
        enableWallJump = false;
        enableDash = true;
        enableWallSlide = false;
        updatedStats = false;
        amountOfJumps = 2;
        charMoveSpeed = 15;
        charAttackDmg = 10;
        charAttackRange = 0.5f;
        charAttackRate = 2;
        charHealth = 100;
        charArmour = 0;
        charJumpForce = 18;
        charTrueDmg = true;
    }

    public void CalculateStats()
    {
        classSelect(); // reapplies class' original stats
        addArmorStats(); // applies the changes from the armor
        addWeaponStats(); // applies the changes from the weapon
        addPotionStats();
        updatedStats = false;
    }

    private void addArmorStats()
    {
        if (armor != null) {
            //checks for if the item was changed from its initial value
            if (armor.defense is not 0) { charArmour += armor.defense; }
            if (armor.health is not 0) { charHealth += armor.health; }
            if (armor.movespeed is not 0) { charMoveSpeed += armor.movespeed; }
            if (armor.jumpforce is not 0) { charJumpForce += armor.jumpforce; }
            if (armor.jumpmod is not 0) { amountOfJumps += armor.jumpmod; }
        }
    }

    private void addWeaponStats()
    {
        if (weapon != null)
        {
            //checks to see if the item was changed from initial value
            if (weapon.damage is not 0) { charAttackDmg += weapon.damage; }
            if (weapon.attackRate is not 0) { charAttackRate *= weapon.attackRate; }
            if (!charTrueDmg) // if the character does not already have true damage by default
                              //check if the weapon add it to the player
            {
                charTrueDmg = weapon.trueDamage;
            }
        }
    }

    private void addPotionStats()
    {
        if(other!=null)
        {
            if(other.itemValue is not 0)
            {
                if (other.itemType == Items.ItemType.Heal) { charHealth += other.itemValue; HealthbarFill temp = transform.GetChild(2).GetComponent<HealthbarFill>(); }
                if (other.itemType == Items.ItemType.Damage) { charAttackDmg += other.itemValue; }
                if (other.itemType == Items.ItemType.Armour) { charArmour += other.itemValue; }
                if (other.itemType == Items.ItemType.Speed) { charMoveSpeed += other.itemValue; }
            }
        }
    }

    private void reloadAbility() 
    {
        playerController.SetAbilities(enableWallJump,enableDash,enableWallSlide);
    }

    private void reloadStats()
    {
        playerController.SetStats(amountOfJumps, charMoveSpeed, charJumpForce);
        playerCombat.SetStats(charAttackDmg, charAttackRate, charAttackRange, charTrueDmg);
        playerDamage.SetStats(charHealth, charArmour);
    }

    //Returns stats 

    public float getPlayerHealth()
    {
        return charHealth;
    }

    public float getPlayerDmg()
    {
        return charAttackDmg;
    }

    public float getPlayerSpeed()
    {
        return charMoveSpeed;
    }

    public float getPlayerArmour()
    {
        return charArmour;
    }

    public void setPlayerArmour(float value)
    {
        charArmour = value;
    }

}
