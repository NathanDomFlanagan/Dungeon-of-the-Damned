using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDmg;
    //determines whether attacks deals true damage or armour reduced damage
    public bool trueDamage; 

    void Awake()
    {
       PlayerPrefs.SetInt("canEnemyAttack", 1);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //See if it can be hit
        Damageable dmg = collision.GetComponent<Damageable>();
        if(dmg.IsAlive == false)
        {
            PlayerPrefs.SetInt("canEnemyAttack", 0);
        }
        
        if (dmg != null)
        {
            //hits player dealing damage (reduced damage if truedama is false)
            dmg.Hit(attackDmg,trueDamage);
            Debug.Log(collision.name + " hit for " + attackDmg);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("canEnemyAttack", 1);
    }
}
