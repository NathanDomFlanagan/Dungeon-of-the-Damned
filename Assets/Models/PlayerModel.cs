using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public ArrayList Inventory;
    public PlayerController playerController;
    public PlayerCombat playerCombat;

    private bool enableWallJump;
    private bool enableDash;
    private bool enableWallSlide;
    private bool updatedStats;

    private int amountOfJumps;
    private int charMoveSpeed;
    private int charAttackDmg;
    private int charHealth;
    private float charAttackRange;
    private int charAttackRate;
    private int charDashCooldown;

    private GameObject player;
    

    PlayerModel(string className)//when called it will provide the name of the class
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

        reloadStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

        reloadAbility(); // gives the character access to the walljump and dash if set
        reloadStats();
    }
    private void selectLancer()
    { // sets the base stats and variables for the lancer.

    }

    private void reloadAbility() {
        playerController.setAbilities(enableWallJump,enableDash,enableWallSlide);
    }

    private void reloadStats()
    {

    }
}
