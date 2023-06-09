using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
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
    private bool isKnocked = false;
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

            PlayerPrefs.SetInt("isPlayerAlive", 1);
            //If health drops below 0, character is dead
            if(_Health <= 0f)
            {
                _Health = 0f;
                IsAlive = false;
                
                if (gameObject.tag == "Player")
                {
                    UnityEngine.Debug.Log("player death");
                    PlayerPrefs.SetInt("isPlayerAlive", 0);
                }
            }

            if (_Health >= _maxHealth)
            {
                _Health = _maxHealth;
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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                isKnocked = false;
                timeSinceHit = 0f;
            }

            timeSinceHit += Time.deltaTime;
        }
        //Hit(10); //Testing to see if it works
    }

    //needs to reset the health to the max
    public void Respawn()
    {
        Health = maxHealth;
        IsAlive = true;
    }

    public void Hit(int dmg, bool trueDamage, Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            //if trueDamage, then deals full damage amount
            if (trueDamage)
            {
                Health -= dmg;
                UnityEngine.Debug.Log("Hit for " + dmg + " true damage. Health is now "+Health);
                

            }
            //else deals reduced damage
            else
            {
                //reduces damage by armour percentage
                Health -= dmg * (1 - (armour / 100));
                UnityEngine.Debug.Log("Hit for " + dmg * (1 - (armour / 100)) + ". Health is now " + Health);

            }
            UnityEngine.Debug.Log("Knocked Back "+knockback.x+" "+knockback.y);
            rb.AddForce(knockback*rb.mass, ForceMode2D.Impulse);
            isKnocked = true;
            isInvincible = true;
        }
    }

    //required to be able to set the players stats so a value
    public void SetStats(float charhp, float chararm)
    {// sets the players help and armour to the values for the class
        maxHealth = charhp;
        armour = chararm;
    }

    public bool getIsKnocked()
    {
        return isKnocked;
    }
}

