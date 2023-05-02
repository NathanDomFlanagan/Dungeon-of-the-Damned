using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public ArrayList Inventory;
    public PlayerController playerController;
    public PlayerCombat playerCombat;

    public string className;

    private bool enableWallJump;
    private bool enableDash;
    private bool enableWallSlide;
    private bool updatedStats;

    public int amountOfJumps;
    private float charMoveSpeed;
    private int charAttackDmg;
    private int charHealth;
    private float charAttackRange;
    private float charAttackRate;
    private float charDashCooldown;
    private float charDashSpeed;
    private float charDashDuration;

    private GameObject player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        switch (className)
        {
            case "knight":
                selectKnight();
                break;
            case "lancer":
                selectLancer();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(updatedStats == true)
        {
            //reloads the character controller and character combat with new stats
        }
    }

    private void selectKnight()
    { // sets the base stats and variables for the knight.
        enableWallJump = false;
        enableDash = false;
        enableWallSlide = false;
        updatedStats = false;
        amountOfJumps = 1;
        charMoveSpeed = 10;
        charAttackDmg = 40;
        charAttackRange = 0.5f;
        charAttackRate = 2;
        charHealth = 100;
        charDashCooldown = 10;
        charDashSpeed = 25;

        reloadAbility(); // gives the character access to the walljump and dash if set
        reloadStats();
    }
    private void selectLancer()
    { // sets the base stats and variables for the lancer.
        enableWallJump = false;
        enableDash = true;
        enableWallSlide = false;
        updatedStats = false;
        amountOfJumps = 2;
        charMoveSpeed = 15;
        charAttackDmg = 30;
        charAttackRange = 0.5f;
        charAttackRate = 3;
        charHealth = 100;
        charDashCooldown = 10;
        charDashSpeed = 25;

        reloadAbility(); // gives the character access to the walljump and dash if set
        reloadStats();
    }

    private void reloadAbility() {
        playerController.SetAbilities(enableWallJump,enableDash,enableWallSlide);
    }

    private void reloadStats()
    {
        playerController.SetStats(amountOfJumps, charMoveSpeed, charDashSpeed, charDashCooldown, charDashDuration);
        playerCombat.SetStats(charAttackDmg, charAttackRate, charAttackRange);
    }
}
