using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDmg;
    //determines whether attacks deals true damage or armour reduced damage
    public bool trueDamage; 
    public Vector2 knockback = Vector2.zero;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //See if it can be hit
        Damageable dmg = collision.GetComponent<Damageable>();
        Animator anim = collision.GetComponent<Animator>();

        /*Collider2D collider = collision.GetComponent<Collider>();
        IDamageable damageable = collider.GetComponent<IDamageable>();*/

        if(dmg != null)
        {
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            //hits player dealing damage (reduced damage if truedama is false)
            bool gotHit = dmg.Hit(attackDmg, trueDamage, deliveredKnockback);
            
            if(gotHit)
                Debug.Log(collision.name + " hit for " + attackDmg);
        }
    }
}
