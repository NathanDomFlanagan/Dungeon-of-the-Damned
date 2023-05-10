using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDmg;

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //See if it can be hit
        Damageable dmg = collision.GetComponent<Damageable>();
        Animator anim = collision.GetComponent<Animator>();

        if(dmg != null)
        {
            dmg.Hit(attackDmg);
            Debug.Log(collision.name + " hit for " + attackDmg);
        }
    }
}
