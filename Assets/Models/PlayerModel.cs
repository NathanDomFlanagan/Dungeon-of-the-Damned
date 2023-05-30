using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoD;

public class PlayerModel : MonoBehaviour
{
    public PlayerInventory Inventory;
    public PlayerController playerController;
    public PlayerCombat playerCombat;
    public Damageable playerDamage;
    public DeathManager playerDeath;

    public string className;

    private ArmorData armour = null;
    private WeaponData weapon = null;

    //sets which of the abilities are enabled for the specific player class
    private bool enableWallJump;
    private bool enableDash;
    private bool enableWallSlide;
    
    //boolean for when an item is added into or removed from the player equipslots
    public bool updatedStats;

    //all the variables for the characters data which can be changed by items.
    // or conversely changed depending on the players class
    private int amountOfJumps;
    private float charMoveSpeed;
    private int charAttackDmg;
    private float charHealth;
    private float charArmour;
    private float charAttackRange;
    private float charAttackRate;
    private float charJumpForce;
    private bool charTrueDmg;

    private static PlayerModel Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

        Inventory.pmSet(this);

        playerDeath.SetDamagable(playerDamage);
        playerDeath.SetPC(playerController);

        classSelect();
        reloadAbility(); // gives the character access to the walljump and dash if 
        reloadStats();
        
        PlayerPrefs.SetInt("coins", 0); // creates coin count as 0;
        //$$test code to be removed
        AddItem(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Weapons/Axe 2.asset", typeof(WeaponData)));
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

    public Object AddItem(Object data) // checks whether the data inserted is an allowed type to be entered into each of the equip slots
    {
        if (data is ArmorData && data != null)
        {
            updatedStats = true;
            return ArmorAdd((ArmorData)data);
        }
        else if (data is WeaponData && data != null)
        {
            updatedStats = true;
            return WeaponAdd((WeaponData)data);
        }
        else
        {   
            return data;
        }
    }

    private ArmorData ArmorAdd(ArmorData armordata)
    {
        ArmorData returndata = armour;
        armour = armordata;
        return returndata;
    }

    private WeaponData WeaponAdd(WeaponData data)
    {
        WeaponData returndata = weapon;
        weapon = data;
        return returndata;
    }

    private void classSelect()
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
        charArmour = 30;
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
        charArmour = 5;
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

    private void CalculateStats()
    {
        classSelect(); // reapplies class' original stats
        addArmorStats(); // applies the changes from the armor
        addWeaponStats(); // applies the changes from the weapon
    }

    private void addArmorStats()
    {
        if (armour != null) {
            //checks for if the item was changed from its initial value
            if (armour.defense is not 0) { charArmour += armour.defense; }
            if (armour.health is not 0) { charHealth += armour.health; }
            if (armour.movespeed is not 0) { charMoveSpeed *= armour.movespeed; }
            if (armour.jumpforce is not 0) { charJumpForce *= armour.jumpforce; }
            if (armour.jumpmod is not 0) { amountOfJumps += armour.jumpmod; }
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
}
