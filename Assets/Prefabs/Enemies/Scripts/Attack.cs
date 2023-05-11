using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDmg;
    //determines whether attacks deals true damage or armour reduced damage
    public bool trueDamage; 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //See if it can be hit
        Damageable dmg = collision.GetComponent<Damageable>();
        Animator anim = collision.GetComponent<Animator>();

        if(dmg != null)
        {
            //hits player dealing damage (reduced damage if truedama is false)
            dmg.Hit(attackDmg,trueDamage);
            Debug.Log(collision.name + " hit for " + attackDmg);
        }
    }
}
