using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //References
    public Animator animator;

    //Damage amount
    public int attackDmg = 50;

    //Attack Time
    public float AtkRate = 2f;
    float NextAtkTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= NextAtkTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetTrigger("Attack");
                NextAtkTime = Time.time + 1f / AtkRate;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //See if it can be hit
        Damageable dmg = collision.GetComponent<Damageable>();

        if (dmg != null)
        {
            dmg.Hit(attackDmg);
            Debug.Log(collision.name + " hit for " + attackDmg);
        }
    }
}
 