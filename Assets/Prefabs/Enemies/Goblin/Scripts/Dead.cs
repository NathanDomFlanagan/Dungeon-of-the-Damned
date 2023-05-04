using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public Damageable dmg;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        dmg = GetComponent<Damageable>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dmg.IsAlive)
        {
            animator.SetBool("IsAlive", false);
            GetComponent<Collider2D>().enabled = false; //Disables enemy collision
            this.enabled = false; //Kills off the enemy
            Destroy(gameObject, 0);
        }
    }
}
