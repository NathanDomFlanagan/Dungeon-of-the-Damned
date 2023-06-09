using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeadAnimation : MonoBehaviour
{
    public Damageable dmg;
    public Animator animator;
    public CoinCounter cc;
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        dmg = GetComponent<Damageable>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CoinCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dmg.IsAlive)
        {
            animator.SetBool("IsAlive", false);            
            UnityEngine.Debug.Log("Dead");
            cc.AddCoins(coins); 
            this.enabled = false; //Kills off the enemy
        }
    }
    void deathAnimationFinished()
    {
        //GetComponent<Collider2D>().enabled = false; //Disables enemy collision
       
        Destroy(gameObject, 0);
    }
}
