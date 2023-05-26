using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDmg;
    //determines whether attacks deals true damage or armour reduced damage
    public bool trueDamage;
    private Vector2 knockbackforce = new Vector2(10f, 5f);


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
            Vector2 knockback = getKnockBack(collision);
            dmg.Hit(attackDmg,trueDamage,knockback);
            Debug.Log(collision.name + " hit for " + attackDmg);
        }
    }
    Vector2 getKnockBack(Collider2D collision)
    {
        if ((collision.transform.position.x - transform.position.x) < 0)
        {
            return new Vector2(-knockbackforce.x, knockbackforce.y);
        }
        else
        {
            return new Vector2(knockbackforce.x, knockbackforce.y);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("canEnemyAttack", 1);
    }
}
