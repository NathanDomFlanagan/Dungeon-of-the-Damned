using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Animator animator;
    //EnemyAI enemy;

    [SerializeField]
    private float _maxHealth = 100;

    
    public float armour; //armour value between 0-100

    public float maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private float _Health = 100;

    [SerializeField]
    private bool isInvincible = false;
    private float timeSinceHit = 0f;
    public float invincibilityTime = 0.25f;

    public float Health
    {
        get
        {
            return _Health;
        }
        set
        {
            _Health = value;

            //If health drops below 0, character is dead
            if(_Health <= 0f)
            {
                _Health = 0f;
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    public bool IsAlive
    {
        get 
        { 
            return _isAlive; 
        }
        set 
        { 
            _isAlive = value; 
            animator.SetBool("isAlive",value);
            UnityEngine.Debug.Log("isAlive set " + value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0f;
            }

            timeSinceHit += Time.deltaTime;
        }
        //Hit(10); //Testing to see if it works
    }

    public void Hit(int dmg, bool trueDamage)
    {
        if(IsAlive && !isInvincible)
        {
            animator.SetTrigger("Hurt");
            //if trueDamage, then deals full damage amount
            if (trueDamage) { 
                Health -= dmg;
                UnityEngine.Debug.Log("Hit for " + dmg + " true damage. Health is now "+Health);
                
            }
            //else deals reduced damage
            else { 
                //reduces damage by armour percentage
                Health -= dmg * (1-(armour / 100));
                UnityEngine.Debug.Log("Hit for " + dmg * (1 - (armour / 100)) + ". Health is now " + Health);

            }
            isInvincible = true;
        }
    }

    //required to be able to set the players stats so a value
    public void SetStats(float charhp, float chararm)
    {// sets the players help and armour to the values for the class
        maxHealth = charhp;
        armour = chararm;
    }
}

